using AIS_Library.Database;
using AIS_Library.Helpers;
using AIS_Library.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_Library.Forms.Librarian
{
    public partial class BookForm : Form
    {
        private readonly string _originalIsbn;
        private bool _hasImage = false;

        // Храним ПОЛНЫЕ списки данных в памяти
        private List<ListItem> _allAuthors = new List<ListItem>();
        private List<ListItem> _allGenres = new List<ListItem>();

        // Храним ID выбранных элементов (чтобы не терять галочки при поиске)
        private HashSet<int> _selectedAuthorIds = new HashSet<int>();
        private HashSet<int> _selectedGenreIds = new HashSet<int>();

        // Флаг, чтобы не срабатывало событие ItemCheck при программном заполнении
        private bool _isProgrammaticChange = false;

        // КОНСТРУКТОР ДОБАВЛЕНИЯ
        public BookForm()
        {
            InitializeComponent();
            // 1. Ставим заглушку
            pbCover.Image = ImageHelper.GeneratePlaceholder(pbCover.Width, pbCover.Height, "Изображение обложки книги");

            // 2. Флага нет
            _hasImage = false;

            nudYear.Maximum = 2100; // Нельзя выбрать год больше текущего стрелочками
            _originalIsbn = null;
            this.Text = "Новая книга";
            nudYear.Value = DateTime.Now.Year;

            SetupSearchFields();
            LoadDictionaries();
        }

        // КОНСТРУКТОР РЕДАКТИРОВАНИЯ
        public BookForm(Book book)
        {
            InitializeComponent();
            nudYear.Maximum = 2100; // Нельзя выбрать год больше текущего стрелочками
            _originalIsbn = book.Isbn;
            this.Text = "Редактирование книги";

            SetupSearchFields();
            LoadDictionaries();
            FillData(book.Isbn);
        }

        private void SetupSearchFields()
        {
            // Настройка умного поиска для Издателя
            cmbPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // 1. ЗАГРУЗКА ДАННЫХ В ПАМЯТЬ
        private void LoadDictionaries()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                // А. Издательства
                // А. Издательства: запрашиваем еще и city
                using (var cmd = new NpgsqlCommand("SELECT publisher_id, name, city FROM publishers ORDER BY name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        // Проверяем, есть ли город (он может быть NULL, если вы это разрешили, или пустой строкой)
                        string city = reader.IsDBNull(2) ? "" : reader.GetString(2);

                        // Формируем красивое название для списка
                        string displayName = string.IsNullOrEmpty(city)
                            ? name
                            : $"{name} ({city})";

                        cmbPublisher.Items.Add(new ListItem
                        {
                            Id = id,
                            Name = displayName // Теперь в списке будет "Милка (Москва)" и "Милка (Казань)"
                        });
                    }
                }

                // Б. Авторы
                using (var cmd = new NpgsqlCommand("SELECT author_id, surname || ' ' || first_name || ' ' || COALESCE(patronymic, '') FROM authors ORDER BY surname", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _allAuthors.Add(new ListItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }

                // В. Жанры
                using (var cmd = new NpgsqlCommand("SELECT genre_id, name FROM genres ORDER BY name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _allGenres.Add(new ListItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            // Первичное заполнение списков
            UpdateList(clbAuthors, _allAuthors, _selectedAuthorIds);
            UpdateList(clbGenres, _allGenres, _selectedGenreIds);
        }


        private void UpdateList(CheckedListBox clb, List<ListItem> allItems, HashSet<int> selectedIds, string searchText = "")
        {
            _isProgrammaticChange = true;
            clb.BeginUpdate();
            clb.Items.Clear();

            var filteredItems = allItems
                .Where(item => item.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            foreach (var item in filteredItems)
            {
                bool isChecked = selectedIds.Contains(item.Id);
                clb.Items.Add(item, isChecked);
            }

            clb.EndUpdate();
            _isProgrammaticChange = false;
        }

        // 2. ЗАПОЛНЕНИЕ ДАННЫХ ПРИ РЕДАКТИРОВАНИИ
        private void FillData(string isbn)
        {
      

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                // А. Основные поля
                string query = "SELECT isbn, title, publication_year, bbk, author_mark, page_count, publisher_id, cover_image FROM books WHERE isbn = @isbn";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("isbn", isbn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIsbn.Text = reader.GetString(0);
                            txtTitle.Text = reader.GetString(1);

                            // ГОД: Если NULL ставим галочку, иначе pначение
                            if (reader.IsDBNull(2))
                            {
                                chkNoYear.Checked = true;
                                nudYear.Value = DateTime.Now.Year; // Просто дефолтное значение
                            }
                            else
                            {
                                chkNoYear.Checked = false;
                                nudYear.Value = reader.GetInt32(2);
                            }

                            txtBbk.Text = reader.GetString(3);
                            txtAuthorMark.Text = reader.GetString(4);
                            nudPages.Value = reader.GetInt32(5);

                            // ИЗДАТЕЛЬСТВО: Если NULL -> ничего не выбираем
                            if (reader.IsDBNull(6))
                            {
                                cmbPublisher.SelectedItem = null;
                                cmbPublisher.Text = ""; // Очищаем текст
                            }
                            else
                            {
                                int pubId = reader.GetInt32(6);
                                foreach (ListItem item in cmbPublisher.Items)
                                {
                                    if (item.Id == pubId) { cmbPublisher.SelectedItem = item; break; }
                                }
                            }

                            if (!reader.IsDBNull(7))
                            {
                                // Если картинка есть в базе
                                pbCover.Image = ImageHelper.BytesToImage((byte[])reader[7]);
                                _hasImage = true; 
                            }
                            else
                            {
                                // Если в базе NULL
                                pbCover.Image = ImageHelper.GeneratePlaceholder(pbCover.Width, pbCover.Height, "Нет обложки");
                                _hasImage = false; 
                            }
                        }
                    }
                }

                // Б. Грузим ID авторов и жанров (без изменений)
                CheckRelatedItems(conn, "SELECT author_id FROM book_authors WHERE book_isbn = @isbn", isbn, _selectedAuthorIds);
                CheckRelatedItems(conn, "SELECT genre_id FROM book_genres WHERE book_isbn = @isbn", isbn, _selectedGenreIds);
            }

            UpdateList(clbAuthors, _allAuthors, _selectedAuthorIds, txtSearchAuthor.Text.Trim());
            UpdateList(clbGenres, _allGenres, _selectedGenreIds, txtSearchGenre.Text.Trim());
        }

        // Вспомогательный метод заполнения HashSet
        private void CheckRelatedItems(NpgsqlConnection conn, string query, string isbn, HashSet<int> selectedSet)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("isbn", isbn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) selectedSet.Add(reader.GetInt32(0));
                }
            }
        }


        private void txtSearchAuthor_TextChanged(object sender, EventArgs e)
        {
            UpdateList(clbAuthors, _allAuthors, _selectedAuthorIds, txtSearchAuthor.Text.Trim());
        }

        private void txtSearchGenre_TextChanged(object sender, EventArgs e)
        {
            UpdateList(clbGenres, _allGenres, _selectedGenreIds, txtSearchGenre.Text.Trim());
        }


        private void clbAuthors_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isProgrammaticChange) return;

            var item = (ListItem)clbAuthors.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
                _selectedAuthorIds.Add(item.Id);
            else
                _selectedAuthorIds.Remove(item.Id);
        }

        private void clbGenres_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isProgrammaticChange) return;

            var item = (ListItem)clbGenres.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
                _selectedGenreIds.Add(item.Id);
            else
                _selectedGenreIds.Remove(item.Id);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(nudPages.Text))
            {
                MessageBox.Show("Укажите количество страниц!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // 1. СБОР ДАННЫХ
            string isbn = txtIsbn.Text.Trim();
            string title = txtTitle.Text.Trim();
            string bbk = txtBbk.Text.Trim();
            string authorMark = txtAuthorMark.Text.Trim();
            int pages = (int)nudPages.Value;

            // Подготовка ГОДА
            object yearVal = chkNoYear.Checked ? DBNull.Value : (int)nudYear.Value;

            // Подготовка ИЗДАТЕЛЯ
            var publisherItem = (ListItem)cmbPublisher.SelectedItem;
            object pubVal = publisherItem == null ? DBNull.Value : publisherItem.Id;

            // 2. ВАЛИДАЦИЯ
            if (string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(bbk) || string.IsNullOrEmpty(authorMark))
            {
                MessageBox.Show("Заполните обязательные поля (ISBN, Название, ББК, Авторский знак)!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

  
            if (pages <= 0)
            {
                MessageBox.Show("Количество страниц должно быть больше 0!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Проверка жанров
            if (_selectedGenreIds.Count == 0)
            {
                MessageBox.Show("Укажите жанр книги!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Проверка года (только если год указан)
            if (!chkNoYear.Checked && (int)yearVal > DateTime.Now.Year)
            {
                MessageBox.Show($"Год издания не может быть больше текущего!", "Внимание");
                this.DialogResult = DialogResult.None; // Не забываем блокировать закрытие
                return;
            }

            string question = _originalIsbn == null
                ? $"Добавить книгу '{title}'?"
                : $"Сохранить изменения для книги '{title}'?";

            if (MessageBox.Show(question, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }


            object coverVal = DBNull.Value; // По умолчанию NULL

            // Конвертируем только если флаг true (реальное фото)
            if (_hasImage && pbCover.Image != null)
            {
                coverVal = ImageHelper.ImageToBytes(pbCover.Image);
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (_originalIsbn == null) // INSERT
                        {
                            string sqlBook = @"INSERT INTO books (isbn, title, publication_year, bbk, author_mark, page_count, publisher_id, cover_image) 
                               VALUES (@isbn, @title, @year, @bbk, @mark, @pages, @pubId, @img)";
                            using (var cmd = new NpgsqlCommand(sqlBook, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("isbn", isbn);
                                cmd.Parameters.AddWithValue("title", title);
                                cmd.Parameters.AddWithValue("year", yearVal);
                                cmd.Parameters.AddWithValue("bbk", bbk);
                                cmd.Parameters.AddWithValue("mark", authorMark);
                                cmd.Parameters.AddWithValue("pages", pages);
                                cmd.Parameters.AddWithValue("pubId", pubVal);
                                cmd.Parameters.AddWithValue("img", coverVal);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else // UPDATE
                        {
                            string sqlBook = @"UPDATE books SET isbn=@newIsbn, title=@title, publication_year=@year, bbk=@bbk, author_mark=@mark, 
                               page_count=@pages, publisher_id=@pubId, cover_image=@img 
                               WHERE isbn=@oldIsbn";
                            using (var cmd = new NpgsqlCommand(sqlBook, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("newIsbn", isbn);
                                cmd.Parameters.AddWithValue("oldIsbn", _originalIsbn);
                                cmd.Parameters.AddWithValue("title", title);
                                cmd.Parameters.AddWithValue("year", yearVal);
                                cmd.Parameters.AddWithValue("bbk", bbk);
                                cmd.Parameters.AddWithValue("mark", authorMark);
                                cmd.Parameters.AddWithValue("pages", pages);
                                cmd.Parameters.AddWithValue("pubId", pubVal);
                                cmd.Parameters.AddWithValue("img", coverVal);
                                cmd.ExecuteNonQuery();
                            }

                            new NpgsqlCommand($"DELETE FROM book_authors WHERE book_isbn = '{isbn}'", conn) { Transaction = transaction }.ExecuteNonQuery();
                            new NpgsqlCommand($"DELETE FROM book_genres WHERE book_isbn = '{isbn}'", conn) { Transaction = transaction }.ExecuteNonQuery();
                        }

                        // АВТОРЫ
                        foreach (int authorId in _selectedAuthorIds)
                        {
                            string sqlLink = "INSERT INTO book_authors (book_isbn, author_id) VALUES (@isbn, @id)";
                            using (var cmd = new NpgsqlCommand(sqlLink, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("isbn", isbn);
                                cmd.Parameters.AddWithValue("id", authorId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // ЖАНРЫ
                        foreach (int genreId in _selectedGenreIds)
                        {
                            string sqlLink = "INSERT INTO book_genres (book_isbn, genre_id) VALUES (@isbn, @id)";
                            using (var cmd = new NpgsqlCommand(sqlLink, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("isbn", isbn);
                                cmd.Parameters.AddWithValue("id", genreId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (PostgresException ex)
                    {
                        transaction.Rollback();
                        this.DialogResult = DialogResult.None;
                        if (ex.SqlState == "23505") MessageBox.Show("ISBN занят!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show(ex.MessageText, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        this.DialogResult = DialogResult.None;
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }
        // КНОПКИ ФОТО
        private void btnLoadCover_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Картинки|*.jpg;*.png;*.jpeg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbCover.Image = Image.FromFile(ofd.FileName);
                    _hasImage = true; // Теперь у нас есть реальное фото
                }
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            // Ставим заглушку визуально
            pbCover.Image = ImageHelper.GeneratePlaceholder(pbCover.Width, pbCover.Height, "Изображение обложки книги");

            // Логически фото нет
            _hasImage = false;
        }

        private void chkNoYear_CheckedChanged(object sender, EventArgs e)
        {
            // Если "Без года" выбрано, блокируем поле с цифрами
            nudYear.Enabled = !chkNoYear.Checked;
        }
    }
}