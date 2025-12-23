using AIS_Library.Database;
using AIS_Library.Forms.General;
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
using LibModel = AIS_Library.Models.Reader;


namespace AIS_Library.Forms.Librarian
{
    public partial class LibrarianMainForm : Form
    {
        private int? _currentReaderId = null;
        public LibrarianMainForm()
        {
            InitializeComponent();

            this.Text = $"АИС Библиотека | Сотрудник: {UserInfo.Login}";

            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReaders);

            LoadReaders();


            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridBooks);
            LoadBooks();


            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridCirculationReaders);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReaderBooks);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReaderFines);

            dtpFineStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFineEnd.Value = DateTime.Now;


            cboFineStatus.SelectedIndex = 1;


            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridAllFines);
            LoadAllFines();

            dtpWriteOffStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpWriteOffEnd.Value = DateTime.Now;

            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridWriteOffs);
            LoadWriteOffs();

            LoadReservations();

            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReservations);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReports);

            cboReportType.SelectedIndex = 0; // Выбираем первый пункт по умолчанию
            dtpReportStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 1 число текущего месяца
            dtpReportEnd.Value = DateTime.Now;

        }


        private void LoadReaders(string searchText = "")
        {
            List<Reader> readers = new List<Reader>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string query = @"SELECT ticket_number, surname, first_name, patronymic, date_of_birth, 
                                passport_series, passport_number, address, phone, registration_date, photo, is_active 
                         FROM readers";


                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" WHERE CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @search
                                   OR phone ILIKE @search 
                                   OR CAST(ticket_number AS TEXT) ILIKE @search
                                   OR passport_number ILIKE @search";
                }


                query += " ORDER BY is_active DESC, surname";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            readers.Add(new Reader
                            {
                                TicketNumber = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Patronymic = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                DateOfBirth = reader.GetDateTime(4),
                                PassportSeries = reader.GetString(5),
                                PassportNumber = reader.GetString(6),
                                Address = reader.GetString(7),
                                Phone = reader.GetString(8),
                                RegistrationDate = reader.GetDateTime(9),


                                Photo = null,

                                IsActive = reader.GetBoolean(11) // Читаем статус
                            });
                        }
                    }
                }
            }
            gridReaders.DataSource = null;
            gridReaders.DataSource = readers;

            // Настройка колонок
            if (gridReaders.Columns["TicketNumber"] != null) gridReaders.Columns["TicketNumber"].HeaderText = "№ Билета";
            if (gridReaders.Columns["Surname"] != null) gridReaders.Columns["Surname"].HeaderText = "Фамилия";
            if (gridReaders.Columns["FirstName"] != null) gridReaders.Columns["FirstName"].HeaderText = "Имя";
            if (gridReaders.Columns["Patronymic"] != null) gridReaders.Columns["Patronymic"].HeaderText = "Отчество";
            if (gridReaders.Columns["Phone"] != null) gridReaders.Columns["Phone"].HeaderText = "Телефон";

            // Скрываем технические или длинные поля, оставляем только важное для списка
            if (gridReaders.Columns["PassportSeries"] != null) gridReaders.Columns["PassportSeries"].Visible = false;
            if (gridReaders.Columns["PassportNumber"] != null) gridReaders.Columns["PassportNumber"].Visible = false;
            if (gridReaders.Columns["Address"] != null) gridReaders.Columns["Address"].Visible = false;
            if (gridReaders.Columns["DateOfBirth"] != null) gridReaders.Columns["DateOfBirth"].Visible = false;
            if (gridReaders.Columns["Photo"] != null) gridReaders.Columns["Photo"].Visible = false;
            if (gridReaders.Columns["FullName"] != null) gridReaders.Columns["FullName"].Visible = false;
            if (gridReaders.Columns["PassportFull"] != null) gridReaders.Columns["PassportFull"].Visible = false;
            if (gridReaders.Columns["RegistrationDate"] != null)
            {
                gridReaders.Columns["RegistrationDate"].Visible = true; // Делаем видимой
                gridReaders.Columns["RegistrationDate"].HeaderText = "Дата регистрации";
         
                gridReaders.Columns["RegistrationDate"].DefaultCellStyle.Format = "d";
            }

            if (gridReaders.Columns["StatusText"] != null) gridReaders.Columns["StatusText"].HeaderText = "Статус";
            if (gridReaders.Columns["IsActive"] != null) gridReaders.Columns["IsActive"].Visible = false;
        }

        private void txtSearchReader_TextChanged(object sender, EventArgs e)
        {
            LoadReaders(txtSearchReader.Text.Trim());
        }

        private void btnAddReader_Click(object sender, EventArgs e)
        {
            using (var form = new ReaderForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReaders();
                    MessageBox.Show("Читатель успешно зарегистрирован!");
                }
            }
        }

        private void btnEditReader_Click(object sender, EventArgs e)
        {
            if (gridReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }

            var selected = (Reader)gridReaders.SelectedRows[0].DataBoundItem;


            selected.Photo = LoadReaderPhoto(selected.TicketNumber);

            using (var form = new ReaderForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReaders();
                    MessageBox.Show("Данные читателя обновлены.");
                }
            }
        }

        private byte[] LoadReaderPhoto(int ticketNumber)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT photo FROM readers WHERE ticket_number = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", ticketNumber);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (byte[])result;
                    }
                }
            }
            return null;
        }



        private void LoadBooks(string search = "")
        {
            List<Book> books = new List<Book>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT isbn, title, authors, publisher_name, publication_year, genres, total_copies, available_copies, is_active 
                         FROM view_book_catalog";


                if (!string.IsNullOrEmpty(search))
                {
                    query += @" WHERE title ILIKE @s 
                           OR authors ILIKE @s 
                           OR isbn ILIKE @s 
                           OR genres ILIKE @s 
                           OR publisher_name ILIKE @s
                           OR CAST(publication_year AS TEXT) ILIKE @s";
                }

                query += " ORDER BY is_active DESC, title";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("s", $"%{search}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                Isbn = reader.GetString(0),
                                Title = reader.GetString(1),

                                // Авторы (там уже может быть 'Б.а.' из View, или строка авторов)
                                Authors = reader.GetString(2),

                                // Издательство (там уже может быть 'Б.и.' из View)
                                PublisherName = reader.GetString(3),

                                // Год (может быть NULL)
                                PublicationYear = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),

                                // Жанры (могут быть пустой строкой, если NULL)
                                Genres = reader.IsDBNull(5) ? "" : reader.GetString(5),

                                TotalCopies = reader.GetInt32(6),
                                AvailableCopies = reader.GetInt32(7),
                                IsActive = reader.GetBoolean(8)
                            });
                        }
                    }
                }
            }

            gridBooks.DataSource = null;
            gridBooks.DataSource = books;

            // Настройка колонок
            if (gridBooks.Columns["Isbn"] != null) gridBooks.Columns["Isbn"].HeaderText = "ISBN";
            if (gridBooks.Columns["Title"] != null) gridBooks.Columns["Title"].HeaderText = "Название";
            if (gridBooks.Columns["Authors"] != null) gridBooks.Columns["Authors"].HeaderText = "Авторы";
            if (gridBooks.Columns["PublisherName"] != null) gridBooks.Columns["PublisherName"].HeaderText = "Издательство";
            if (gridBooks.Columns["PublicationYear"] != null) gridBooks.Columns["PublicationYear"].HeaderText = "Год";
            if (gridBooks.Columns["Genres"] != null) gridBooks.Columns["Genres"].HeaderText = "Жанры";
            if (gridBooks.Columns["TotalCopies"] != null) gridBooks.Columns["TotalCopies"].HeaderText = "Всего экз.";
            if (gridBooks.Columns["AvailableCopies"] != null) gridBooks.Columns["AvailableCopies"].HeaderText = "В наличии";
            if (gridBooks.Columns["StatusText"] != null) gridBooks.Columns["StatusText"].HeaderText = "Статус";
            if (gridBooks.Columns["IsActive"] != null) gridBooks.Columns["IsActive"].Visible = false;

            // Скрываем технические поля
            string[] hideCols = { "Bbk", "AuthorMark", "PageCount", "CoverImage", "PublisherId" };
            foreach (var col in hideCols)
            {
                if (gridBooks.Columns[col] != null) gridBooks.Columns[col].Visible = false;
            }



        }
        // Поиск
        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearchBook.Text.Trim());
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new BookForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                    MessageBox.Show("Книга добавлена в каталог!");
                }
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            var selectedBook = (Book)gridBooks.SelectedRows[0].DataBoundItem;

            using (var form = new BookForm(selectedBook))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                    MessageBox.Show("Карточка книги обновлена.");
                }
            }
        }

        private void gridBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                if (gridBooks.Columns[e.ColumnIndex].DataPropertyName == "PublicationYear")
                {

                    if (e.Value == null)
                    {
                        e.Value = "Б.г."; // Подменяем текст на "Б.г."
                        e.FormattingApplied = true; // Говорим таблице, что мы сами отформатировали ячейку
                    }
                }
            }
        }

        private void btnCopies_Click(object sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу из списка!");
                return;
            }

            var selectedBook = (Book)gridBooks.SelectedRows[0].DataBoundItem;


            using (var form = new BookCopiesForm(selectedBook))
            {
                form.ShowDialog();

                LoadBooks(txtSearchBook.Text.Trim());
            }
        }


        private void txtCirculationReaderSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtCirculationReaderSearch.Text.Trim();
            if (search.Length < 1) { gridCirculationReaders.DataSource = null; return; }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                ticket_number, 
                CONCAT_WS(' ', surname, first_name, patronymic) AS full_name,
                phone, 
                photo 
            FROM readers 
            WHERE is_active = TRUE  -- <--- ВОТ ЭТО ГЛАВНОЕ ИЗМЕНЕНИЕ
              AND (CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @s 
                   OR ticket_number::text LIKE @s)
            ORDER BY surname 
            LIMIT 20";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("s", $"%{search}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridCirculationReaders.DataSource = dt;
                }
            }


            if (gridCirculationReaders.Columns["ticket_number"] != null)
            {
                gridCirculationReaders.Columns["ticket_number"].HeaderText = "№";
                gridCirculationReaders.Columns["ticket_number"].Width = 50; // Узкая колонка
            }

            if (gridCirculationReaders.Columns["full_name"] != null)
            {
                gridCirculationReaders.Columns["full_name"].HeaderText = "ФИО Читателя";
            }

            // Скрываем лишнее
            if (gridCirculationReaders.Columns["phone"] != null) gridCirculationReaders.Columns["phone"].Visible = false;
            if (gridCirculationReaders.Columns["photo"] != null) gridCirculationReaders.Columns["photo"].Visible = false;
        }




        private void UpdateReaderBooks()
        {
            if (_currentReaderId == null) return;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // Используем наше новое VIEW
                string query = @"SELECT lending_id, book_title, copy_inventory_number, lend_date, due_date, overdue_days 
                         FROM view_current_lendings 
                         WHERE reader_ticket_number = @id 
                         ORDER BY due_date";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", _currentReaderId);
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridReaderBooks.DataSource = dt;
                }
            }

            if (gridReaderBooks.Columns["lending_id"] != null) gridReaderBooks.Columns["lending_id"].Visible = false;
            if (gridReaderBooks.Columns["book_title"] != null) gridReaderBooks.Columns["book_title"].HeaderText = "Книга";
            if (gridReaderBooks.Columns["copy_inventory_number"] != null) gridReaderBooks.Columns["copy_inventory_number"].HeaderText = "Инв. №";
            if (gridReaderBooks.Columns["lend_date"] != null) gridReaderBooks.Columns["lend_date"].HeaderText = "Выдана";
            if (gridReaderBooks.Columns["due_date"] != null) gridReaderBooks.Columns["due_date"].HeaderText = "Вернуть до";
            if (gridReaderBooks.Columns["overdue_days"] != null) gridReaderBooks.Columns["overdue_days"].Visible = false; // Используем для раскраски
        }



        private void gridCirculationReaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gridCirculationReaders.SelectedRows.Count > 0)
            {
                var row = gridCirculationReaders.Rows[e.RowIndex];


                _currentReaderId = Convert.ToInt32(row.Cells["ticket_number"].Value);
                string fullName = row.Cells["full_name"].Value.ToString(); // Готовое ФИО
                string phone = row.Cells["phone"].Value.ToString();

                // Отображаем инфо внизу
                lblCirculationName.Text = fullName;
                lblCirculationInfo.Text = $"Билет №{_currentReaderId}\nТел: {phone}";

                // Отображаем фото
                pbCirculationPhoto.Image = null;
                object photoObj = row.Cells["photo"].Value;


                if (photoObj != DBNull.Value && photoObj != null)
                {
                    byte[] bytes = (byte[])photoObj;
                    if (bytes.Length > 0)
                    {
                        pbCirculationPhoto.Image = ImageHelper.BytesToImage(bytes);
                    }
                }

                // Если фото нет — ГЕНЕРИРУЕМ ЗАГЛУШКУ
                if (pbCirculationPhoto.Image == null)
                {

                    pbCirculationPhoto.Image = ImageHelper.GeneratePlaceholder(pbCirculationPhoto.Width, pbCirculationPhoto.Height, "Фото читателя");
                }

                // Разблокируем правую часть и грузим книги
                UpdateReaderBooks();
                txtInv.Enabled = true;
                btnIssueBook.Enabled = true;
                LoadReaderFines(_currentReaderId.Value);
            }
        }

        private void gridReaderBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                int overdueIndex = gridReaderBooks.Columns["overdue_days"].Index;
                var val = gridReaderBooks.Rows[e.RowIndex].Cells[overdueIndex].Value;

                if (val != null && val != DBNull.Value && Convert.ToInt32(val) > 0)
                {

                    e.CellStyle.BackColor = Color.MistyRose;
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {

            if (gridReaderBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для возврата!", "Внимание");
                return;
            }

            var row = gridReaderBooks.SelectedRows[0];
            int lendingId = Convert.ToInt32(row.Cells["lending_id"].Value);
            string title = row.Cells["book_title"].Value.ToString();


            if (MessageBox.Show($"Оформить возврат книги \"{title}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {

                    int overdueDays = 0;
                    string message = "";

                    using (var cmd = new NpgsqlCommand("CALL sp_return_book(@id, @msg, @days)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", lendingId);

                        var outMsg = new NpgsqlParameter("msg", NpgsqlTypes.NpgsqlDbType.Text)
                        {
                            Direction = ParameterDirection.InputOutput,
                            Value = DBNull.Value
                        };
                        cmd.Parameters.Add(outMsg);

                        var outDays = new NpgsqlParameter("days", NpgsqlTypes.NpgsqlDbType.Integer)
                        {
                            Direction = ParameterDirection.InputOutput,
                            Value = DBNull.Value
                        };
                        cmd.Parameters.Add(outDays);

                        cmd.ExecuteNonQuery();

                        message = outMsg.Value.ToString();
                        overdueDays = Convert.ToInt32(outDays.Value);
                    }

                    if (overdueDays > 0)
                    {
                        MessageBox.Show($"{message}\n\nСейчас откроется окно оформления штрафа за просрочку.",
                            "Внимание: Просрочка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Открываем форму штрафа
                        using (var fineForm = new FineForm(lendingId, overdueDays))
                        {
                            fineForm.ShowDialog();
                        }
                    }


                    if (MessageBox.Show("Имеются ли у книги повреждения (порванные страницы, пометки)?\n\nНажмите 'Да', чтобы оформить штраф за ПОРЧУ.",
                        "Проверка состояния книги", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var damageForm = new FineForm(lendingId, 2, true))
                        {
                            damageForm.ShowDialog();
                        }
                    }

                    UpdateReaderBooks();
                    if (_currentReaderId.HasValue) LoadReaderFines(_currentReaderId.Value);


                    MessageBox.Show("Оформление возврата книги прошло успешно.", "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show(ex.MessageText, "Ошибка возврата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void btnIssueBook_Click(object sender, EventArgs e)
        {

            if (_currentReaderId == null) { MessageBox.Show("Выберите читателя!"); return; }
            if (string.IsNullOrEmpty(txtInv.Text)) { MessageBox.Show("Введите инвентарный номер!"); return; }
            if (!int.TryParse(txtInv.Text, out int invNum)) { MessageBox.Show("Номер должен быть числом!"); return; }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {

                    using (var cmd = new NpgsqlCommand("CALL sp_issue_book(@inv, @reader, @lib)", conn))
                    {
                        cmd.Parameters.AddWithValue("inv", invNum);
                        cmd.Parameters.AddWithValue("reader", _currentReaderId);
                        cmd.Parameters.AddWithValue("lib", AIS_Library.Models.UserInfo.LibrarianId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Книга успешно выдана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateReaderBooks();
                    txtInv.Clear();
                    txtInv.Focus();
                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(ex.MessageText, "Ошибка выдачи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void btnFindBook_Click(object sender, EventArgs e)
        {

            using (var form = new BookSelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Если выбрали книгу - вставляем номер в поле
                    txtInv.Text = form.SelectedInventoryNumber.ToString();
                }
            }

        }

        private void btnExtendBook_Click(object sender, EventArgs e)
        {
            if (gridReaderBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу в списке 'Книги на руках'!", "Внимание");
                return;
            }

            int lendingId = Convert.ToInt32(gridReaderBooks.SelectedRows[0].Cells["lending_id"].Value);
            string bookTitle = gridReaderBooks.SelectedRows[0].Cells["book_title"].Value.ToString();

            if (MessageBox.Show($"Продлить книгу \"{bookTitle}\" на 30 дней?", "Продление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {

                    using (var cmd = new NpgsqlCommand("CALL sp_extend_book(@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", lendingId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Срок возврата успешно продлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    UpdateReaderBooks();
                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(ex.MessageText, "Ошибка продления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void btnLostBook_Click(object sender, EventArgs e)
        {
            if (gridReaderBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу!", "Внимание");
                return;
            }

            var row = gridReaderBooks.SelectedRows[0];
            int lendingId = Convert.ToInt32(row.Cells["lending_id"].Value);
            int invNumber = Convert.ToInt32(row.Cells["copy_inventory_number"].Value);
            string title = row.Cells["book_title"].Value.ToString();
            DateTime dueDate = Convert.ToDateTime(row.Cells["due_date"].Value);

            if (MessageBox.Show($"Вы действительно хотите оформить УТЕРЮ книги \"{title}\"?",
        "Подтверждение утери", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 1. ПРОСРОЧКА
            if (DateTime.Now.Date > dueDate.Date)
            {
                int days = (DateTime.Now.Date - dueDate.Date).Days;
                string msg = $"Книга просрочена на {days} дн.\nНеобходимо оформить штраф за просрочку.";

                if (MessageBox.Show(msg, "Просрочка", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    using (var overdueForm = new FineForm(lendingId, days))
                    {
                        if (overdueForm.ShowDialog() != DialogResult.OK) return;
                    }
                }
                else
                {
                    return;
                }
            }

            // 2. УТЕРЯ
            using (var lossForm = new FineForm(lendingId, 3, true))
            {
                if (lossForm.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("Теперь необходимо списать утерянный экземпляр.",
                        "Следующий шаг", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. СПИСАНИЕ ЭКЗЕМПЛЯРА (Обязательный цикл)
                    bool isWriteOffCompleted = false;

                    while (!isWriteOffCompleted)
                    {
                        using (var writeOffForm = new WriteOffForm(invNumber, title, "Утрата"))
                        {
                            if (writeOffForm.ShowDialog() == DialogResult.OK)
                            {
                                isWriteOffCompleted = true;
                                string payStatus = lossForm.WasPaid ? "оплачен" : "оформлен (долг)";

                                MessageBox.Show($"Процесс завершен:\n1. Штраф за утерю {payStatus}.\n2. Книга списана.",
                                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Защита от закрытия окна без списания
                                var retry = MessageBox.Show(
                                   "ВНИМАНИЕ! Вы оформили штраф, но не списали книгу.\nЭто приведет к ошибкам в учете.\n\n" +
                                   "Нажмите 'Повтор', чтобы завершить списание.",
                                   "Ошибка процесса", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                                if (retry == DialogResult.Cancel) break;
                            }
                        }
                    }

     
                    UpdateReaderBooks();
                    if (_currentReaderId.HasValue) LoadReaderFines(_currentReaderId.Value);
                }
            }
        }
        private void LoadReaderFines(int ticketNumber)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string query = @"SELECT fine_id, issue_date, article_name, amount, comment 
                         FROM view_unpaid_fines 
                         WHERE reader_ticket_number = @id 
                         ORDER BY issue_date";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", ticketNumber);
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridReaderFines.DataSource = dt;
                }
            }

            // Настройка колонок
            if (gridReaderFines.Columns["fine_id"] != null) gridReaderFines.Columns["fine_id"].Visible = false;

            if (gridReaderFines.Columns["issue_date"] != null)
                gridReaderFines.Columns["issue_date"].HeaderText = "Дата";

            if (gridReaderFines.Columns["article_name"] != null)
                gridReaderFines.Columns["article_name"].HeaderText = "Нарушение";

            // === ИЗМЕНЕНИЕ ЗДЕСЬ ===
            if (gridReaderFines.Columns["amount"] != null)
            {
                gridReaderFines.Columns["amount"].HeaderText = "Сумма";
                gridReaderFines.Columns["amount"].DefaultCellStyle.Format = "C2"; // Формат валюты (руб.)
            }

            if (gridReaderFines.Columns["comment"] != null)
                gridReaderFines.Columns["comment"].HeaderText = "Заметки"; // Тут будут дни просрочки
        }

        private void btnPayFine_Click(object sender, EventArgs e)
        {
            if (gridReaderFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите штраф для оплаты!", "Внимание");
                return;
            }

            var row = gridReaderFines.SelectedRows[0];
            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            string article = row.Cells["article_name"].Value.ToString();


            if (gridReaderFines.Columns.Contains("is_paid") && row.Cells["is_paid"].Value != DBNull.Value)
            {
                bool isAlreadyPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);
                if (isAlreadyPaid)
                {
                    MessageBox.Show("Этот штраф уже помечен как оплаченный!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            if (MessageBox.Show($"Принять оплату по штрафу \"{article}\"?",
                "Оплата штрафа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {


                    using (var cmd = new NpgsqlCommand("CALL sp_pay_fine(@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", fineId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Штраф успешно погашен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем таблицу штрафов
                    LoadReaderFines(_currentReaderId.Value);
                }
                catch (PostgresException ex)
                {
                    // Если процедура вернет ошибку "Этот штраф уже был оплачен ранее"
                    MessageBox.Show(ex.MessageText, "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Всё равно обновляем таблицу, чтобы увидеть актуальный статус
                    LoadReaderFines(_currentReaderId.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            if (gridReaderFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите штраф, чтобы добавить к нему заметку.", "Внимание");
                return;
            }


            var row = gridReaderFines.SelectedRows[0];
            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            string currentComment = row.Cells["comment"].Value?.ToString() ?? "";


            using (var form = new NoteForm(currentComment))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    using (var conn = DbHelper.GetConnection())
                    {
                        conn.Open();
                        try
                        {
                            string sql = "UPDATE fines SET comment = @com WHERE fine_id = @id";
                            using (var cmd = new NpgsqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("com", form.NoteText);
                                cmd.Parameters.AddWithValue("id", fineId);
                                cmd.ExecuteNonQuery();
                            }


                            LoadReaderFines(_currentReaderId.Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из системы?", "Выход",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.Restart();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var form = new ChangeSelfPasswordForm())
            {
                form.ShowDialog();

            }
        }

        private void LoadAllFines()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT fine_id, issue_date, payment_date, ticket_number, reader_fullname, book_title, article_name, amount, is_paid, comment 
                         FROM view_all_fines_extended 
                         WHERE issue_date BETWEEN @start AND @end";


                string search = txtFilterFineReader.Text.Trim();
                if (!string.IsNullOrEmpty(search))
                {

                    query += @" AND (reader_fullname ILIKE @search 
                              OR book_title ILIKE @search
                              OR article_name ILIKE @search
                              OR CAST(ticket_number AS TEXT) LIKE @search)";
                }


                int statusIndex = cboFineStatus.SelectedIndex;
                if (statusIndex == 1) query += " AND is_paid = FALSE";
                if (statusIndex == 2) query += " AND is_paid = TRUE";

                query += " ORDER BY issue_date DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("start", dtpFineStart.Value.Date);
                    cmd.Parameters.AddWithValue("end", dtpFineEnd.Value.Date);
                    if (!string.IsNullOrEmpty(search)) cmd.Parameters.AddWithValue("search", $"%{search}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridAllFines.DataSource = dt;


                    decimal total = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        total += Convert.ToDecimal(row["amount"]);
                    }
                    lblTotalFines.Text = $"Итого по списку: {total:C2}";
                }
            }


            if (gridAllFines.Columns["fine_id"] != null) gridAllFines.Columns["fine_id"].Visible = false;

            if (gridAllFines.Columns["issue_date"] != null)
                gridAllFines.Columns["issue_date"].HeaderText = "Выписан";


            if (gridAllFines.Columns["payment_date"] != null)
            {
                gridAllFines.Columns["payment_date"].HeaderText = "Дата оплаты";

            }
            if (gridAllFines.Columns["ticket_number"] != null) gridAllFines.Columns["ticket_number"].HeaderText = "№ Билета";
            if (gridAllFines.Columns["reader_fullname"] != null) gridAllFines.Columns["reader_fullname"].HeaderText = "Читатель";

            if (gridAllFines.Columns["book_title"] != null)

                gridAllFines.Columns["book_title"].HeaderText = "Книга";

            if (gridAllFines.Columns["article_name"] != null) gridAllFines.Columns["article_name"].HeaderText = "Нарушение";

            if (gridAllFines.Columns["amount"] != null)
            {
                gridAllFines.Columns["amount"].HeaderText = "Сумма";
                gridAllFines.Columns["amount"].DefaultCellStyle.Format = "C2";
            }

            if (gridAllFines.Columns["is_paid"] != null)
            {
                gridAllFines.Columns["is_paid"].HeaderText = "Статус оплаты";

            }

            if (gridAllFines.Columns["comment"] != null) gridAllFines.Columns["comment"].HeaderText = "Заметка";
        }

        private void btnFilterFines_Click(object sender, EventArgs e)
        {
            LoadAllFines();
        }

        private void gridAllFines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var row = gridAllFines.Rows[e.RowIndex];
                bool isPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);

                if (!isPaid)
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void btnGlobalPay_Click(object sender, EventArgs e)
        {
            if (gridAllFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите штраф для оплаты!", "Внимание");
                return;
            }

            var row = gridAllFines.SelectedRows[0];


            bool isPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);
            if (isPaid)
            {
                MessageBox.Show("Этот штраф уже оплачен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            string reader = row.Cells["reader_fullname"].Value.ToString();
            string amount = row.Cells["amount"].Value.ToString();


            if (MessageBox.Show($"Принять оплату {amount} от читателя {reader}?",
                "Касса", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {

                    using (var cmd = new NpgsqlCommand("CALL sp_pay_fine(@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", fineId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Оплата успешно принята.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadAllFines();
                }
                catch (PostgresException ex)
                {

                    MessageBox.Show(ex.MessageText, "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadAllFines();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void btnGlobalNote_Click(object sender, EventArgs e)
        {
            if (gridAllFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для редактирования заметки.");
                return;
            }

            var row = gridAllFines.SelectedRows[0];
            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            string currentComment = row.Cells["comment"].Value?.ToString() ?? "";


            using (var form = new NoteForm(currentComment))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var conn = DbHelper.GetConnection())
                    {
                        conn.Open();
                        string sql = "UPDATE fines SET comment = @com WHERE fine_id = @id";
                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("com", form.NoteText);
                            cmd.Parameters.AddWithValue("id", fineId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadAllFines();
                }
            }
        }

        private void txtFilterFineReader_TextChanged(object sender, EventArgs e)
        {
            LoadAllFines();
        }




        private void LoadWriteOffs()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT write_off_id, write_off_date, inventory_number, book_title, reason, librarian_name, cost 
                         FROM view_write_offs_full
                         WHERE write_off_date BETWEEN @start AND @end";


                if (!string.IsNullOrEmpty(txtSearWriteOff.Text))
                {

                    query += @" AND (
                            book_title ILIKE @search OR 
                            reason ILIKE @search OR 
                            librarian_name ILIKE @search OR 
                            CAST(inventory_number AS TEXT) LIKE @search
                        )";
                }

                query += " ORDER BY write_off_date DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("start", dtpWriteOffStart.Value.Date);
                    cmd.Parameters.AddWithValue("end", dtpWriteOffEnd.Value.Date);

                    if (!string.IsNullOrEmpty(txtSearWriteOff.Text))
                        cmd.Parameters.AddWithValue("search", $"%{txtSearWriteOff.Text.Trim()}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridWriteOffs.DataSource = dt;
                }
            }


            if (gridWriteOffs.Columns["write_off_id"] != null) gridWriteOffs.Columns["write_off_id"].Visible = false;

            if (gridWriteOffs.Columns["write_off_date"] != null)
                gridWriteOffs.Columns["write_off_date"].HeaderText = "Дата";

            if (gridWriteOffs.Columns["inventory_number"] != null)
                gridWriteOffs.Columns["inventory_number"].HeaderText = "Инв. №";

            if (gridWriteOffs.Columns["book_title"] != null)
                gridWriteOffs.Columns["book_title"].HeaderText = "Книга";

            if (gridWriteOffs.Columns["reason"] != null)
                gridWriteOffs.Columns["reason"].HeaderText = "Причина";

            if (gridWriteOffs.Columns["librarian_name"] != null)
                gridWriteOffs.Columns["librarian_name"].HeaderText = "Сотрудник";

            if (gridWriteOffs.Columns["cost"] != null)
            {
                gridWriteOffs.Columns["cost"].HeaderText = "Цена";
                gridWriteOffs.Columns["cost"].DefaultCellStyle.Format = "C2";
            }


            decimal totalSum = 0;

            // Считаем сумму
            foreach (DataRow row in ((DataTable)gridWriteOffs.DataSource).Rows)
            {
                if (row["cost"] != DBNull.Value)
                {
                    totalSum += Convert.ToDecimal(row["cost"]);
                }
            }


            int count = gridWriteOffs.Rows.Count;


            lbWriteOffs.Text = $"Списано книг: {count} шт.  |  Общая сумма ущерба: {totalSum:C2}";
        }


        private void btnFilterWriteOff_Click(object sender, EventArgs e)
        {
            LoadWriteOffs();
        }

        private void txtSearWriteOff_TextChanged(object sender, EventArgs e)
        {
            LoadWriteOffs();
        }

        private void btnHistoryReader_Click(object sender, EventArgs e)
        {
            if (gridReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите читателя из списка.", "Внимание");
                return;
            }

            var selectedReader = (Reader)gridReaders.SelectedRows[0].DataBoundItem;


            string fullName = $"{selectedReader.Surname} {selectedReader.FirstName} {selectedReader.Patronymic}".Trim();

            using (var form = new ReaderHistoryForm(selectedReader.TicketNumber, fullName))
            {
                form.ShowDialog();
            }
        }

        private void btnAnnulFine_Click(object sender, EventArgs e)
        {
            // 1. Проверка выбора
            if (gridAllFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите штраф для аннулирования.", "Внимание");
                return;
            }

            var row = gridAllFines.SelectedRows[0];
            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            string article = row.Cells["article_name"].Value.ToString();
            string reader = row.Cells["reader_fullname"].Value.ToString();
            bool isPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);

            // 2. Проверка оплаты
            if (isPaid)
            {
                MessageBox.Show("Этот штраф уже оплачен. Аннулирование невозможно.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. АДМИН
            using (var authForm = new AIS_Library.Forms.General.AdminAuthForm())
            {
                if (authForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Действие отменено. Права администратора не подтверждены.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // 4. ЛОГИКА АННУЛИРОВАНИЯ
            bool restoreBook = false;

            if (article.Contains("Утеря"))
            {
                // Сценарий Утери: спрашиваем, что делать с книгой
                using (var choiceForm = new AIS_Library.Forms.Admin.AnnulmentChoiceForm())
                {
                    if (choiceForm.ShowDialog() != DialogResult.OK) return;
                    restoreBook = choiceForm.ShouldRestoreBook;
                }
            }
            else
            {
                // Сценарий Просрочки/Порчи
                if (MessageBox.Show($"Администратор подтвердил действие.\n\nАннулировать штраф \"{article}\" для читателя {reader}?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            // 5. ВЫПОЛНЕНИЕ
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("CALL sp_admin_annul_fine(@id, @restore)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", fineId);
                        cmd.Parameters.AddWithValue("restore", restoreBook);
                        cmd.ExecuteNonQuery();
                    }


                    string msg = "Штраф успешно аннулирован (подтверждено администратором).";

                    if (article.Contains("Утеря"))
                    {
                        if (restoreBook)
                        {
                            msg += "\n\nЭкземпляр восстановлен на баланс (статус 'В наличии').";
                        }
                        else
                        {
                            //
                            msg += "\n\nСтарый экземпляр остался в статусе 'Списан' (так как он утерян).";
                            msg += "\n\nВАЖНО: Принесенную взамен книгу необходимо оформить как новое поступление:";
                            msg += "\n1. Если книга уже есть в каталоге — через кнопку 'Поставка'.";
                            msg += "\n2. Если это новая книга — через кнопку 'Добавить книгу'.";
                        }
                    }

                    MessageBox.Show(msg, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllFines();
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show(ex.MessageText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (gridReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }

            var selected = (Reader)gridReaders.SelectedRows[0].DataBoundItem;
            string action = selected.IsActive ? "отправить в архив" : "восстановить";

            if (MessageBox.Show($"Вы уверены, что хотите {action} читателя {selected.Surname}?",
                "Изменение статуса", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    try
                    {
                        using (var cmd = new NpgsqlCommand("CALL sp_change_reader_status(@id)", conn))
                        {
                            cmd.Parameters.AddWithValue("id", selected.TicketNumber);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Статус успешно изменен.", "Успех");
                        LoadReaders(txtSearchReader.Text.Trim());
                    }
                    catch (PostgresException ex)
                    {

                        MessageBox.Show(ex.MessageText, "Отклонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void btnArchiveBook_Click(object sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            var selected = (Book)gridBooks.SelectedRows[0].DataBoundItem;
            string action = selected.IsActive ? "отправить в архив" : "восстановить в каталоге";

            if (MessageBox.Show($"Вы уверены, что хотите {action} книгу \"{selected.Title}\"?",
                "Изменение статуса", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    try
                    {
                        using (var cmd = new NpgsqlCommand("CALL sp_change_book_status(@isbn)", conn))
                        {
                            cmd.Parameters.AddWithValue("isbn", selected.Isbn);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Статус книги изменен.");
                        LoadBooks(txtSearchBook.Text.Trim());
                    }
                    catch (PostgresException ex)
                    {

                        MessageBox.Show(ex.MessageText, "Невозможно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void btnEditAmount_Click(object sender, EventArgs e)
        {
            if (gridAllFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите штраф!", "Внимание");
                return;
            }

            var row = gridAllFines.SelectedRows[0];
            string articleName = row.Cells["article_name"].Value.ToString();
            bool isPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);

            if (isPaid)
            {
                MessageBox.Show("Нельзя менять сумму оплаченного штрафа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Др. поверка
            if (!articleName.Contains("Порча"))
            {
                MessageBox.Show($"Изменение суммы для нарушения \"{articleName}\" запрещено.\n" +
                                "Разрешено менять только штраф за Порчу книги.",
                                "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // АДМИН
            using (var authForm = new AIS_Library.Forms.General.AdminAuthForm())
            {
                if (authForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Изменение суммы требует подтверждения администратора.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Админ - ок, меняем сумму
            int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
            decimal currentAmount = Convert.ToDecimal(row.Cells["amount"].Value);

            using (var form = new AIS_Library.Forms.General.ChangeAmountForm(currentAmount))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var conn = DbHelper.GetConnection())
                    {
                        conn.Open();
                        try
                        {
                            using (var cmd = new NpgsqlCommand("CALL sp_update_fine_amount(@id, @amount)", conn))
                            {
                                cmd.Parameters.AddWithValue("id", fineId);
                                cmd.Parameters.AddWithValue("amount", form.NewAmount);
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Сумма штрафа обновлена (подтверждено администратором).", "Успех");
                            LoadAllFines(); // Обновляем таблицу
                        }
                        catch (PostgresException ex)
                        {
                            MessageBox.Show(ex.MessageText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
                    }
                }
            }
        }


        private void LoadReservations()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM view_reservations_info WHERE 1=1";

                // Фильтр статуса
                if (cboResStatus.SelectedIndex == 1) query += " AND status_text = 'Активна'";
                if (cboResStatus.SelectedIndex == 2) query += " AND status_text = 'Неактивна'";

                // Поиск
                if (!string.IsNullOrEmpty(txtSearchReservation.Text))
                {
                    // Добавляем поиск по телефону и сотруднику
                    query += @" AND (
                            reader_name ILIKE @s 
                            OR book_title ILIKE @s 
                            OR phone ILIKE @s             -- Поиск по телефону
                            OR librarian_name ILIKE @s    -- Поиск по сотруднику
                        )";
                }

                query += @" ORDER BY 
                    CASE WHEN status_text = 'Активна' THEN 0 ELSE 1 END, 
                    reservation_date DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(txtSearchReservation.Text))
                        cmd.Parameters.AddWithValue("s", $"%{txtSearchReservation.Text.Trim()}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridReservations.DataSource = dt;
                }
            }


            if (gridReservations.Columns["reservation_id"] != null) gridReservations.Columns["reservation_id"].Visible = false;
            if (gridReservations.Columns["isbn"] != null) gridReservations.Columns["isbn"].Visible = false;
            if (gridReservations.Columns["reader_ticket_number"] != null) gridReservations.Columns["reader_ticket_number"].Visible = false;

            if (gridReservations.Columns["reservation_status"] != null) gridReservations.Columns["reservation_status"].Visible = false;

            if (gridReservations.Columns["reservation_date"] != null) gridReservations.Columns["reservation_date"].HeaderText = "Дата брони";
            if (gridReservations.Columns["expiry_date"] != null) gridReservations.Columns["expiry_date"].HeaderText = "Истекает";
            if (gridReservations.Columns["status_text"] != null) gridReservations.Columns["status_text"].HeaderText = "Статус";
            if (gridReservations.Columns["book_title"] != null) gridReservations.Columns["book_title"].HeaderText = "Книга";
            if (gridReservations.Columns["reader_name"] != null) gridReservations.Columns["reader_name"].HeaderText = "Читатель";

            if (gridReservations.Columns["phone"] != null)
            {
                gridReservations.Columns["phone"].HeaderText = "Телефон";

            }


            if (gridReservations.Columns["librarian_name"] != null) gridReservations.Columns["librarian_name"].HeaderText = "Сотрудник";


        }
        private void btnCancelReservation_Click(object sender, EventArgs e)
        {

            if (gridReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите бронь для отмены!", "Внимание");
                return;
            }

            var row = gridReservations.SelectedRows[0];


            string currentStatus = row.Cells["status_text"].Value.ToString();

            if (currentStatus != "Активна")
            {
                MessageBox.Show($"Эта бронь уже находится в статусе \"{currentStatus}\".",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int id = Convert.ToInt32(row.Cells["reservation_id"].Value);

            if (MessageBox.Show("Вы уверены, что хотите отменить эту бронь?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    try
                    {
                        using (var cmd = new NpgsqlCommand("UPDATE reservations SET reservation_status = FALSE WHERE reservation_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Бронь успешно отменена.", "Успех");
                        LoadReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void btnGoToIssue_Click(object sender, EventArgs e)
        {
            if (gridReservations.SelectedRows.Count == 0) return;

            var row = gridReservations.SelectedRows[0];
            string status = row.Cells["status_text"].Value.ToString();

            if (status != "Активна")
            {
                MessageBox.Show("Можно выдать только по АКТИВНОЙ брони.", "Внимание");
                return;
            }

            int ticketNum = Convert.ToInt32(row.Cells["reader_ticket_number"].Value);
            string bookTitle = row.Cells["book_title"].Value.ToString();

            // 1. Переключаемся на вкладку "Выдача"

            tabControl1.SelectedTab = tabControl1.TabPages["tabIssue"];

            // 2. Заполняем поле поиска читателя и ищем его
            txtCirculationReaderSearch.Text = ticketNum.ToString();

            MessageBox.Show($"Читатель найден.\n\nТеперь найдите книгу \"{bookTitle}\" и нажмите 'Выдать'.\n\n(Бронь закроется автоматически при выдаче).",
                "Выдача по брони", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            using (var form = new CreateReservationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }

        }

        private void txtSearchReservation_TextChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void cboResStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void gridReservations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridReservations.Rows[e.RowIndex];

                if (gridReservations.Columns.Contains("status_text") && row.Cells["status_text"].Value != null)
                {
                    string status = row.Cells["status_text"].Value.ToString();

                    if (status == "Активна")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                }
            }

        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = cboReportType.SelectedIndex;
            // 1 (Должники) и 4 (Фонд) - это моментальные отчеты, даты не нужны
            bool isPeriodRequired = (type != 1 && type != 4);

            dtpReportStart.Enabled = isPeriodRequired;
            dtpReportEnd.Enabled = isPeriodRequired;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            int reportType = cboReportType.SelectedIndex;
            DateTime dateStart = dtpReportStart.Value.Date;
            DateTime dateEnd = dtpReportEnd.Value.Date;

            string query = "";

            switch (reportType)
            {
                case 0: // Читательская активность (НОВОЕ для библиотекаря)
                    query = "SELECT * FROM get_report_reader_activity(@start, @end)";
                    break;

                case 1: // Список должников
                    query = "SELECT * FROM get_report_debtors()";
                    break;

                case 2: // Популярные книги
                    query = "SELECT * FROM get_report_popular_books(@start, @end)";
                    break;

                case 3: // Неоплаченные штрафы
                    query = "SELECT * FROM get_report_unpaid_fines_list(@start, @end)";
                    break;

                case 4: // Состояние фонда
                    query = "SELECT * FROM get_report_fund_state()";
                    break;

                case 5: // Акты списания
                    query = "SELECT * FROM get_report_write_offs_list(@start, @end)";
                    break;

                case 6: // Журнал поставок
                    query = "SELECT * FROM get_report_deliveries_list(@start, @end)";
                    break;

                default:
                    MessageBox.Show("Выберите тип отчета.");
                    return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Параметры дат нужны всем, КРОМЕ 1 (Должники) и 4 (Фонд)
                        if (reportType != 1 && reportType != 4)
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("start", NpgsqlTypes.NpgsqlDbType.Date) { Value = dateStart });
                            cmd.Parameters.Add(new NpgsqlParameter("end", NpgsqlTypes.NpgsqlDbType.Date) { Value = dateEnd });
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            gridReports.DataSource = dt;
                            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReports);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("За выбранный период данных не найдено.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при формировании отчета: " + ex.Message);
                }
            }
        }


        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // 1. Проверка: есть ли данные
            if (gridReports.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportTitle = cboReportType.Text;
            string periodInfo = "";

            // 2. Логика Периода:
            // Если календари активны — формируем строку периода.
            // Если нет (например, "Состояние фонда") — оставляем строку пустой.
            if (dtpReportStart.Enabled)
            {
                periodInfo = $"Период: с {dtpReportStart.Value.ToShortDateString()} по {dtpReportEnd.Value.ToShortDateString()}";
            }

            // 3. Логика Подписи
            // Нам нужно узнать, кто именно нажал кнопку.
            string employeeName = "Сотрудник";

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
               
                    // Это значит: Фамилия + Пробел + Имя + Пробел + (Отчество или пустота)
                    string sql = "SELECT surname || ' ' || first_name || ' ' || COALESCE(patronymic, '') FROM librarians WHERE tabel_number = @id";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", UserInfo.LibrarianId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            employeeName = result.ToString().Trim(); // Trim уберет лишний пробел, если отчества нет
                        }
                    }
                }
                catch
                {
                    // Игнорируем ошибки
                }
            }

            string signature = $"Отчёт сформировал(а): {employeeName}";

            // 4. Диалог сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файл (Excel) (*.csv)|*.csv|Текстовый файл (*.txt)|*.txt|Документ Word (*.doc)|*.doc";

            string cleanTitle = reportTitle.Replace(" ", "_");
            sfd.FileName = $"{cleanTitle}_{DateTime.Now:dd.MM.yyyy}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();

                    // Передаем (Имя файла, Заголовок, Период, Подпись)
                    switch (ext)
                    {
                        case ".csv":
                            ExportToCsv(sfd.FileName, reportTitle, periodInfo, signature);
                            break;
                        case ".txt":
                            ExportToTxt(sfd.FileName, reportTitle, periodInfo, signature);
                            break;
                        case ".doc":
                            ExportToWord(sfd.FileName, reportTitle, periodInfo, signature);
                            break;
                    }

                    MessageBox.Show("Отчет успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ExportToCsv(string filename, string title, string period, string signature)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine(title);
            if (!string.IsNullOrEmpty(period)) sb.AppendLine(period);
            sb.AppendLine(signature);
            sb.AppendLine($"Дата формирования:;{DateTime.Now.ToShortDateString()}");
            sb.AppendLine();

            for (int i = 0; i < gridReports.Columns.Count; i++)
            {
                sb.Append(gridReports.Columns[i].HeaderText + ";");
            }
            sb.AppendLine();

            foreach (DataGridViewRow row in gridReports.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < gridReports.Columns.Count; i++)
                    {
                        string header = gridReports.Columns[i].HeaderText;
                        object rawValue = row.Cells[i].Value;
                        string cellValue = "";

                        if (rawValue is DateTime dt) cellValue = dt.ToShortDateString();
                        else cellValue = rawValue?.ToString() ?? "";

                        cellValue = cellValue.Replace(";", ",").Replace("\r", "").Replace("\n", " ");

                        if (header.Contains("ИНН") || header.Contains("Телефон") || header.Contains("ISBN") ||
                            header.Contains("Билет") || header.Contains("номер"))
                        {
                            sb.Append($"=\"{cellValue}\";");
                        }
                        else
                        {
                            sb.Append(cellValue + ";");
                        }
                    }
                    sb.AppendLine();
                }
            }

            System.IO.File.WriteAllText(filename, sb.ToString(), System.Text.Encoding.UTF8);
        }

        private void ExportToTxt(string filename, string title, string period, string signature)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                sw.WriteLine(new string('=', 50));
                sw.WriteLine($"ОТЧЕТ:  {title.ToUpper()}");
                if (!string.IsNullOrEmpty(period)) sw.WriteLine($"ПЕРИОД: {period.Replace("Период: ", "")}");
                sw.WriteLine(signature);
                sw.WriteLine($"ДАТА:   {DateTime.Now.ToShortDateString()}");
                sw.WriteLine(new string('=', 50));
                sw.WriteLine();

                int[] colWidths = new int[gridReports.Columns.Count];
                for (int i = 0; i < gridReports.Columns.Count; i++)
                    colWidths[i] = gridReports.Columns[i].HeaderText.Length;

                foreach (DataGridViewRow row in gridReports.Rows)
                {
                    for (int i = 0; i < gridReports.Columns.Count; i++)
                    {
                        object rawValue = row.Cells[i].Value;
                        string val = "";
                        if (rawValue is DateTime dt) val = dt.ToShortDateString();
                        else val = rawValue?.ToString() ?? "";

                        if (val.Length > colWidths[i]) colWidths[i] = val.Length;
                    }
                }
                for (int i = 0; i < colWidths.Length; i++) colWidths[i] += 2;

                for (int i = 0; i < gridReports.Columns.Count; i++)
                {
                    sw.Write(gridReports.Columns[i].HeaderText.PadRight(colWidths[i]));
                }
                sw.WriteLine();

                for (int i = 0; i < gridReports.Columns.Count; i++)
                {
                    sw.Write(new string('-', colWidths[i] - 1) + " ");
                }
                sw.WriteLine();

                foreach (DataGridViewRow row in gridReports.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < gridReports.Columns.Count; i++)
                        {
                            object rawValue = row.Cells[i].Value;
                            string val = "";
                            if (rawValue is DateTime dt) val = dt.ToShortDateString();
                            else val = rawValue?.ToString() ?? "";

                            sw.Write(val.PadRight(colWidths[i]));
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        private void ExportToWord(string filename, string title, string period, string signature)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<html><body>");

          
            sb.Append($"<h1 style='text-align:center; font-family:\"Times New Roman\"'>{title}</h1>");


            if (!string.IsNullOrEmpty(period))
            {
                sb.Append($"<h3 style='text-align:center; font-family:\"Times New Roman\"'>{period}</h3>");
            }


            sb.Append($"<p style='text-align:center; font-family:\"Times New Roman\"'>Дата формирования: {DateTime.Now.ToShortDateString()}</p>");


            sb.Append($"<p style='text-align:center; font-family:\"Times New Roman\"'>{signature}</p>");

            sb.Append("<br>");


            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%; font-family:Arial'>");


            sb.Append("<tr style='background-color: #d9d9d9; font-weight: bold;'>");
            foreach (DataGridViewColumn col in gridReports.Columns)
            {
                sb.Append($"<td>{col.HeaderText}</td>");
            }
            sb.Append("</tr>");

            // Строки данных
            foreach (DataGridViewRow row in gridReports.Rows)
            {
                if (!row.IsNewRow)
                {
                    sb.Append("<tr>");
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        object rawValue = cell.Value;
                        string val = "";

                        if (rawValue is DateTime dt)
                            val = dt.ToShortDateString();
                        else
                            val = rawValue?.ToString() ?? "";

                        sb.Append($"<td>{val}</td>");
                    }
                    sb.Append("</tr>");
                }
            }

            sb.Append("</table>");
            sb.Append("</body></html>");

            System.IO.File.WriteAllText(filename, sb.ToString(), System.Text.Encoding.UTF8);
        }
    }
}



