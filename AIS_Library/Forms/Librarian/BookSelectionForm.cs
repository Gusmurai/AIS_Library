using AIS_Library.Database;
using AIS_Library.Helpers;
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
    public partial class BookSelectionForm : Form
    {
        public int SelectedInventoryNumber { get; private set; }

        public string SelectedBookTitle { get; private set; }
        public string SelectedBookIsbn { get; private set; }
        public BookSelectionForm()
        {
            InitializeComponent();

            this.Text = "Выбор книги для выдачи";

            // Применяем стили
            StyleHelper.ConfigureGrid(gridBooks);
            StyleHelper.ConfigureGrid(gridCopies);

            LoadBooks();

        }

        // 1. ЗАГРУЗКА СПИСКА КНИГ (Как в каталоге)
        private void LoadBooks(string search = "")
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

              

                string query = @"SELECT 
                            isbn, 
                            title, 
                            COALESCE(authors, 'Б.а.') as authors, 
                            COALESCE(CAST(publication_year AS TEXT), 'Б.г.') as publication_year, 
                            available_copies 
                         FROM view_book_catalog 
                         WHERE available_copies > 0 
                           AND is_active = TRUE";

                if (!string.IsNullOrEmpty(search))
                {
                    query += " AND (title ILIKE @s OR authors ILIKE @s OR isbn ILIKE @s)";
                }
                query += " ORDER BY title";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(search)) cmd.Parameters.AddWithValue("s", $"%{search}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridBooks.DataSource = dt;
                }
            }

    
            if (gridBooks.Columns["isbn"] != null) gridBooks.Columns["isbn"].Visible = false;
            if (gridBooks.Columns["title"] != null) gridBooks.Columns["title"].HeaderText = "Название";
            if (gridBooks.Columns["authors"] != null) gridBooks.Columns["authors"].HeaderText = "Авторы";
            if (gridBooks.Columns["publication_year"] != null) gridBooks.Columns["publication_year"].HeaderText = "Год";
            if (gridBooks.Columns["available_copies"] != null) gridBooks.Columns["available_copies"].HeaderText = "Доступно";
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text.Trim());
            gridCopies.DataSource = null; // Очищаем список копий при новом поиске

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ConfirmSelection();
        }

        private void gridCopies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmSelection();
        }


        private void ConfirmSelection()
        {
            // Проверка выбора экземпляра (справа)
            if (gridCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите конкретный экземпляр (справа)!", "Внимание");
                return;
            }

            // 1. Запоминаем Инвентарный номер (из правой таблицы)
            SelectedInventoryNumber = Convert.ToInt32(gridCopies.SelectedRows[0].Cells["inventory_number"].Value);

            // 2. 
        
            if (gridBooks.SelectedRows.Count > 0)
            {
                var bookRow = gridBooks.SelectedRows[0];
                SelectedBookIsbn = bookRow.Cells["isbn"].Value.ToString();
                SelectedBookTitle = bookRow.Cells["title"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gridBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string isbn = gridBooks.Rows[e.RowIndex].Cells["isbn"].Value.ToString();

            txtSearchCopy.Clear(); // Очищаем старый поиск номера

            // 1. Грузим таблицу экземпляров справа
            LoadAvailableCopies(isbn);

            // 2. Грузим красивую карточку снизу
            LoadBookDetails(isbn);

        }

        private void LoadAvailableCopies(string isbn)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // Загружаем ТОЛЬКО те, что "В наличии"
                string query = @"SELECT inventory_number, cost 
                                 FROM view_copies_status
                                 WHERE isbn = @isbn AND status = 'В наличии'
                                 ORDER BY inventory_number";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("isbn", isbn);
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridCopies.DataSource = dt;
                }
            }

            if (gridCopies.Columns["inventory_number"] != null) gridCopies.Columns["inventory_number"].HeaderText = "Инв. №";
            if (gridCopies.Columns["cost"] != null) gridCopies.Columns["cost"].HeaderText = "Цена";
        }


        private void LoadBookDetails(string isbn)
        {
            // Очистка
            pbBookCover.Image = null;
            lblTitle.Text = "";
            lblAuthors.Text = "";
            lblPubInfo.Text = "";
            lblISBN.Text = "";
            lblCodes.Text = "";

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                b.title,              
                b.publication_year,   
                b.bbk,                
                b.author_mark,        
                b.cover_image,        
                p.name AS publisher_name, 
                b.page_count,         
                
                -- === ИЗМЕНЕНИЕ ЗДЕСЬ: Полное ФИО (Фамилия Имя Отчество) ===
                (SELECT STRING_AGG(a.surname || ' ' || a.first_name || ' ' || COALESCE(a.patronymic, ''), ', ') 
                 FROM book_authors ba 
                 JOIN authors a ON ba.author_id = a.author_id 
                 WHERE ba.book_isbn = b.isbn) as authors_list, 
                 
                (SELECT STRING_AGG(g.name, ', ') 
                 FROM book_genres bg 
                 JOIN genres g ON bg.genre_id = g.genre_id 
                 WHERE bg.book_isbn = b.isbn) as genres_list
            FROM books b
            LEFT JOIN publishers p ON b.publisher_id = p.publisher_id
            WHERE b.isbn = @isbn";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("isbn", isbn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Название
                            lblTitle.Text = reader.GetString(0);

                            // Авторы (Полное ФИО)
                            string authors = reader.IsDBNull(7) || string.IsNullOrWhiteSpace(reader.GetString(7))
                                             ? "Б.а."
                                             : reader.GetString(7);
                            lblAuthors.Text = authors;

                            // Инфо об издании
                            string pub = reader.IsDBNull(5) ? "Б.и." : reader.GetString(5);
                            string year = reader.IsDBNull(1) ? "Б.г." : reader.GetInt32(1).ToString() + " г.";
                            string pages = reader.IsDBNull(6) ? "" : ", " + reader.GetInt32(6).ToString() + " стр.";
                            string genres = reader.IsDBNull(8) ? "-" : reader.GetString(8);

                            lblPubInfo.Text = $"{pub}, {year}{pages}  |  Жанр: {genres}";

                            // ISBN и Коды
                            lblISBN.Text = $"ISBN: {isbn}";
                            string bbk = reader.IsDBNull(2) ? "-" : reader.GetString(2);
                            string mark = reader.IsDBNull(3) ? "-" : reader.GetString(3);
                            lblCodes.Text = $"ББК: {bbk}   |   Авт. знак: {mark}";

                            // Картинка
                            if (!reader.IsDBNull(4))
                            {
                                byte[] imgBytes = (byte[])reader[4];
                                using (var ms = new System.IO.MemoryStream(imgBytes))
                                {
                                    pbBookCover.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }


                            // 3. Если картинки всё ещё нет (в БД пусто или сбой) — ГЕНЕРИРУЕМ ЗАГЛУШКУ
                            if (pbBookCover.Image == null)
                            {
                                // Генерируем картинку с текстом "Нет обложки" под размер рамки
                                pbBookCover.Image = ImageHelper.GeneratePlaceholder(pbBookCover.Width, pbBookCover.Height, "Изображение обложки книги");
                            }




                        }
                    }
                }
            }
        }

        private void txtSearchCopy_TextChanged(object sender, EventArgs e)
        {
            // Проверяем, есть ли данные в таблице
            if (gridCopies.DataSource is DataTable dt)
            {
                string search = txtSearchCopy.Text.Trim();

                try
                {
                    if (string.IsNullOrEmpty(search))
                    {
                        // Если поиск пустой - сбрасываем фильтр (показываем всё)
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        // Фильтруем по колонке inventory_number
                        // Convert(..., 'System.String') нужно, так как в базе это число, а LIKE работает со строками
                        dt.DefaultView.RowFilter = $"Convert(inventory_number, 'System.String') LIKE '%{search}%'";
                    }
                }
                catch (Exception ex)
                {
                    // Игнорируем ошибки фильтрации (например, если ввели спецсимволы)
                }
            }
        }
    }
}
        