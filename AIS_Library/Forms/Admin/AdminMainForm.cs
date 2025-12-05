using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;
using AIS_Library.Database;
using AIS_Library.Models;
using Publisher = AIS_Library.Models.Publisher; // Указываем, что используем наш класс
using LibModel = AIS_Library.Models.Librarian;
using AIS_Library.Forms.General;
namespace AIS_Library.Forms.Admin
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();



            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridGenres);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridPublishers);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridAuthors);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridSuppliers);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridFines);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridLibrarians);
            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReports);

            // 2. Кнопки (пример для одной вкладки)
            AIS_Library.Helpers.StyleHelper.ConfigureButton(btnAddGenre);
            AIS_Library.Helpers.StyleHelper.ConfigureButton(btnEditGenre);
            AIS_Library.Helpers.StyleHelper.ConfigureButton(btnDeleteGenre);

            // Загружаем данные при открытии формы
            LoadGenres();
            LoadPublishers();
            LoadAuthors();
            LoadSuppliers();
            LoadFines();
            LoadLibrarians();

            // Настройка отчетов
            cboReportType.SelectedIndex = 0; // Выбираем первый пункт по умолчанию
            dtpReportStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 1 число текущего месяца
            dtpReportEnd.Value = DateTime.Now;
        }

        // ==========================================
        // ВКЛАДКА 1: ЖАНРЫ
        // ==========================================

        private void LoadGenres(string searchText = "") // Параметр по умолчанию пустой
        {
            List<Genre> genres = new List<Genre>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT genre_id, name, description FROM genres";

                // Если в поиске что-то есть, добавляем фильтр
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Ищем совпадение в Названии ИЛИ Описании
                    query += " WHERE name ILIKE @search OR description ILIKE @search";
                }

                query += " ORDER BY name";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        // Добавляем % с обеих сторон для поиска подстроки (любая часть слова)
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(new Genre
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            gridGenres.DataSource = null;
            gridGenres.DataSource = genres;

            // Скрываем/настраиваем колонки
            if (gridGenres.Columns["Id"] != null) gridGenres.Columns["Id"].Visible = false;
            if (gridGenres.Columns["Name"] != null) gridGenres.Columns["Name"].HeaderText = "Название";
            if (gridGenres.Columns["Description"] != null) gridGenres.Columns["Description"].HeaderText = "Описание";
        }
        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            using (var form = new GenreForm()) // Вызываем пустой конструктор
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGenres(); // Просто обновляем таблицу
                    MessageBox.Show("Жанр добавлен!");
                }
            }
        }

        private void btnEditGenre_Click(object sender, EventArgs e)
        {
            if (gridGenres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите жанр!");
                return;
            }
            var selected = (Genre)gridGenres.SelectedRows[0].DataBoundItem;

            using (var form = new GenreForm(selected)) // Передаем данные
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGenres();
                    MessageBox.Show("Жанр обновлен!");
                }
            }
        }
        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            if (gridGenres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите жанр для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedGenre = (Genre)gridGenres.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Вы уверены, что хотите удалить жанр '{selectedGenre.Name}'?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand("DELETE FROM genres WHERE genre_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", selectedGenre.Id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Жанр удален.");
                        LoadGenres();

                    }
                    catch (PostgresException ex)
                    {
                        // Теперь мы просто показываем текст ошибки, который пришел из БД (из триггера)
                        // Postgres сам скажет: "Нельзя удалить жанр 'Роман', он используется в книгах..."
                        MessageBox.Show(ex.MessageText, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }


    
        private void gridGenres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gridGenres.SelectedRows.Count > 0)
            {
                var selected = (Genre)gridGenres.SelectedRows[0].DataBoundItem;

            }
        }


        // ==========================================
        // ВКЛАДКА 2: ИЗДАТЕЛЬСТВА
        // ==========================================

        private void LoadPublishers(string searchText = "")
        {
            List<Publisher> publishers = new List<Publisher>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT publisher_id, name, city FROM publishers";

                if (!string.IsNullOrEmpty(searchText))
                {
                    query += " WHERE name ILIKE @search OR city ILIKE @search";
                }

                query += " ORDER BY name";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            publishers.Add(new Publisher
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                City = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            gridPublishers.DataSource = null;
            gridPublishers.DataSource = publishers;

            if (gridPublishers.Columns["Id"] != null) gridPublishers.Columns["Id"].Visible = false;
            if (gridPublishers.Columns["Name"] != null) gridPublishers.Columns["Name"].HeaderText = "Название";
            if (gridPublishers.Columns["City"] != null) gridPublishers.Columns["City"].HeaderText = "Город";
        }

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            using (var form = new PublisherForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPublishers();
                    MessageBox.Show("Издательство добавлено!");
                }
            }
        }


        private void btnEditPublish_Click(object sender, EventArgs e)
        {
            if (gridPublishers.SelectedRows.Count == 0) { MessageBox.Show("Выберите строку!"); return; }
            var selected = (Publisher)gridPublishers.SelectedRows[0].DataBoundItem;

            using (var form = new PublisherForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPublishers();
                    MessageBox.Show("Издательство обновлено!");
                }
            }
        }
        private void btnDeletePublisher_Click(object sender, EventArgs e)
        {
            if (gridPublishers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите издательство для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (Publisher)gridPublishers.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить издательство '{selected.Name}' (г. {selected.City})?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand("DELETE FROM publishers WHERE publisher_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", selected.Id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Издательство удалено.");
                        LoadPublishers();

                    }
                    catch (PostgresException ex)
                    {
                        // Выводим сообщение из триггера
                        MessageBox.Show(ex.MessageText, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }



        // ==========================================
        // ВКЛАДКА 3: АВТОРЫ
        // ==========================================

        private void LoadAuthors(string searchText = "")
        {
            List<Author> authors = new List<Author>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT author_id, surname, first_name, patronymic, date_of_birth FROM authors";

                if (!string.IsNullOrEmpty(searchText))
                {
                    // CONCAT_WS(' ', ...) склеивает поля через пробел
                    // Получается строка вида "Фамилия Имя Отчество"
                    query += @" WHERE surname ILIKE @search 
                           OR first_name ILIKE @search 
                           OR patronymic ILIKE @search
                           OR CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @search";
                }

                query += " ORDER BY surname";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authors.Add(new Author
                            {
                                Id = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Patronymic = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                DateOfBirth = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            gridAuthors.DataSource = null;
            gridAuthors.DataSource = authors;

            if (gridAuthors.Columns["Id"] != null) gridAuthors.Columns["Id"].Visible = false;
            if (gridAuthors.Columns["Surname"] != null) gridAuthors.Columns["Surname"].HeaderText = "Фамилия";
            if (gridAuthors.Columns["FirstName"] != null) gridAuthors.Columns["FirstName"].HeaderText = "Имя";
            if (gridAuthors.Columns["Patronymic"] != null) gridAuthors.Columns["Patronymic"].HeaderText = "Отчество";
            if (gridAuthors.Columns["DateOfBirth"] != null) gridAuthors.Columns["DateOfBirth"].HeaderText = "Дата рождения";
            if (gridAuthors.Columns["FullName"] != null) gridAuthors.Columns["FullName"].Visible = false;
        }



        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            using (var form = new AuthorForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAuthors();
                    MessageBox.Show("Автор добавлен!");
                }
            }
        }



        private void btnEditAuthor_Click(object sender, EventArgs e)
        {
            if (gridAuthors.SelectedRows.Count == 0) { MessageBox.Show("Выберите строку!"); return; }
            var selected = (Author)gridAuthors.SelectedRows[0].DataBoundItem;

            using (var form = new AuthorForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAuthors();
                    MessageBox.Show("Автор обновлен!");
                }
            }
        }
        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (gridAuthors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите автора для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (Author)gridAuthors.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить автора '{selected.FullName}'?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand("DELETE FROM authors WHERE author_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", selected.Id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Автор удален.");
                        LoadAuthors();

                    }
                    catch (PostgresException ex)
                    {
                        // Выводим сообщение из триггера
                        MessageBox.Show(ex.MessageText, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }



        // ==========================================
        // ВКЛАДКА 4: ПОСТАВЩИКИ
        // ==========================================

        private void LoadSuppliers(string searchText = "")
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT inn, name, address, phone, email FROM suppliers";

                // === ДОБАВЛЕНО: Расширенный поиск ===
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" WHERE name ILIKE @search 
                           OR inn ILIKE @search 
                           OR address ILIKE @search 
                           OR phone ILIKE @search 
                           OR email ILIKE @search";
                }

                query += " ORDER BY name";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                Inn = reader.GetString(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Email = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            gridSuppliers.DataSource = null;
            gridSuppliers.DataSource = suppliers;

            if (gridSuppliers.Columns["Inn"] != null) gridSuppliers.Columns["Inn"].HeaderText = "ИНН";
            if (gridSuppliers.Columns["Name"] != null) gridSuppliers.Columns["Name"].HeaderText = "Название";
            if (gridSuppliers.Columns["Address"] != null) gridSuppliers.Columns["Address"].HeaderText = "Адрес";
            if (gridSuppliers.Columns["Phone"] != null) gridSuppliers.Columns["Phone"].HeaderText = "Телефон";
            if (gridSuppliers.Columns["Email"] != null) gridSuppliers.Columns["Email"].HeaderText = "Email";
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (var form = new SupplierForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();
                    MessageBox.Show("Поставщик добавлен!");
                }
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (gridSuppliers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите поставщика!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (Supplier)gridSuppliers.SelectedRows[0].DataBoundItem;

            using (var form = new SupplierForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();
                    MessageBox.Show("Поставщик обновлен!");
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (gridSuppliers.SelectedRows.Count == 0) return;
            var selected = (Supplier)gridSuppliers.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить поставщика '{selected.Name}'?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand("DELETE FROM suppliers WHERE inn = @inn", conn))
                        {
                            cmd.Parameters.AddWithValue("inn", selected.Inn);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Поставщик удален.");
                        LoadSuppliers();

                    }
                    catch (PostgresException ex)
                    {
                        // 23503 - есть связанные данные (поставки)
                        if (ex.SqlState == "23503") MessageBox.Show("Нельзя удалить поставщика, есть зарегистрированные поставки книг.");
                        else MessageBox.Show(ex.MessageText);
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
                }
            }

        }



        // ==========================================
        // ВКЛАДКА 5: ШТРАФЫ
        // ==========================================

        private void LoadFines(string searchText = "")
        {
            List<FineArticle> fines = new List<FineArticle>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT article_id, name, description, base_amount FROM fine_articles";

                // === ДОБАВЛЕНО: Фильтрация ===
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += " WHERE name ILIKE @search OR description ILIKE @search";
                }

                query += " ORDER BY article_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // === ДОБАВЛЕНО: Параметр поиска ===
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fines.Add(new FineArticle
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                BaseAmount = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            gridFines.DataSource = null;
            gridFines.DataSource = fines;

            if (gridFines.Columns["Id"] != null) gridFines.Columns["Id"].Visible = false;
            if (gridFines.Columns["Name"] != null) gridFines.Columns["Name"].HeaderText = "Название";
            if (gridFines.Columns["Description"] != null) gridFines.Columns["Description"].HeaderText = "Описание";
            if (gridFines.Columns["BaseAmount"] != null) gridFines.Columns["BaseAmount"].HeaderText = "Сумма (руб)";
        }



        private void btnAddFine_Click(object sender, EventArgs e)
        {
            using (var form = new FineArticleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadFines();
                    MessageBox.Show("Статья добавлена!");
                }
            }
        }



        private void btnEditFine_Click(object sender, EventArgs e)
        {
            if (gridFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите статью!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = (FineArticle)gridFines.SelectedRows[0].DataBoundItem;

            using (var form = new FineArticleForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadFines();
                    MessageBox.Show("Статья обновлена!");
                }
            }
        }
        private void btnDeleteFine_Click(object sender, EventArgs e)
        {
            if (gridFines.SelectedRows.Count == 0) return;
            var selected = (FineArticle)gridFines.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить статью '{selected.Name}'?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand("DELETE FROM fine_articles WHERE article_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", selected.Id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Статья удалена.");
                        LoadFines();

                    }
                    catch (PostgresException ex)
                    {
                        // Нельзя удалить, если уже выписаны штрафы по этой статье
                        if (ex.SqlState == "23503") MessageBox.Show("Нельзя удалить статью, по ней уже были выписаны штрафы.");
                        else MessageBox.Show(ex.MessageText);
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
                }
            }

        }

        private void LoadLibrarians(string searchText = "")
        {
            List<LibModel> librarians = new List<LibModel>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT tabel_number, surname, first_name, patronymic, phone, user_login, is_active 
                         FROM librarians";

                if (!string.IsNullOrEmpty(searchText))
                {
                    // Добавили CONCAT_WS в начало
                    query += @" WHERE CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @search
                           OR surname ILIKE @search 
                           OR first_name ILIKE @search 
                           OR phone ILIKE @search 
                           OR user_login ILIKE @search
                           OR CAST(tabel_number AS TEXT) ILIKE @search";
                }

                query += " ORDER BY surname";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{searchText}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            librarians.Add(new LibModel
                            {
                                TabelNumber = reader.GetInt32(0),
                                Surname = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                Patronymic = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Phone = reader.GetString(4),
                                UserLogin = reader.GetString(5),
                                IsActive = reader.GetBoolean(6)
                            });
                        }
                    }
                }
            }
            gridLibrarians.DataSource = null;
            gridLibrarians.DataSource = librarians;

            // Настройка колонок
            if (gridLibrarians.Columns["TabelNumber"] != null) gridLibrarians.Columns["TabelNumber"].HeaderText = "Таб. №";
            if (gridLibrarians.Columns["Surname"] != null) gridLibrarians.Columns["Surname"].HeaderText = "Фамилия";
            if (gridLibrarians.Columns["FirstName"] != null) gridLibrarians.Columns["FirstName"].HeaderText = "Имя";
            if (gridLibrarians.Columns["Patronymic"] != null) gridLibrarians.Columns["Patronymic"].HeaderText = "Отчество";
            if (gridLibrarians.Columns["Phone"] != null) gridLibrarians.Columns["Phone"].HeaderText = "Телефон";
            if (gridLibrarians.Columns["UserLogin"] != null) gridLibrarians.Columns["UserLogin"].HeaderText = "Логин";

            if (gridLibrarians.Columns["FullName"] != null) gridLibrarians.Columns["FullName"].Visible = false;
            if (gridLibrarians.Columns["IsActive"] != null) gridLibrarians.Columns["IsActive"].Visible = false;
            if (gridLibrarians.Columns["StatusText"] != null) gridLibrarians.Columns["StatusText"].HeaderText = "Статус";
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из системы?", "Выход",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Этот метод закрывает текущее приложение и запускает его заново
                // Откроется LoginForm, так как она прописана в Program.cs
                Application.Restart();
            }
        }

        private void btnAddLibrarian_Click(object sender, EventArgs e)
        {
            using (var form = new LibrarianForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadLibrarians();
                    MessageBox.Show("Сотрудник добавлен!");
                }
            }

        }

        private void btnEditLibrarian_Click(object sender, EventArgs e)
        {
            if (gridLibrarians.SelectedRows.Count == 0) { MessageBox.Show("Выберите сотрудника!"); return; }

            var selected = (LibModel)gridLibrarians.SelectedRows[0].DataBoundItem;

            using (var form = new LibrarianForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadLibrarians();
                    MessageBox.Show("Данные сотрудника обновлены!");
                }
            }
        }

        private void btnDeleteLibrarian_Click(object sender, EventArgs e)
        {
            if (gridLibrarians.SelectedRows.Count == 0) { MessageBox.Show("Выберите сотрудника!"); return; }

            var selected = (LibModel)gridLibrarians.SelectedRows[0].DataBoundItem;

            // Нельзя уволить самого себя
            if (selected.UserLogin == UserInfo.Login)
            {
                MessageBox.Show("Вы не можете изменить статус самому себе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Определяем действие: если работает -> увольняем, если уволен -> восстанавливаем
            bool newStatus = !selected.IsActive;
            string actionWord = newStatus ? "восстановить" : "уволить";

            if (MessageBox.Show($"Вы уверены, что хотите {actionWord} сотрудника {selected.Surname}?",
                "Изменение статуса", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        // Обновляем только статус
                        using (var cmd = new NpgsqlCommand("UPDATE librarians SET is_active = @status WHERE tabel_number = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("status", newStatus);
                            cmd.Parameters.AddWithValue("id", selected.TabelNumber);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Статус сотрудника изменен: {(newStatus ? "Работает" : "Уволен")}.");
                        LoadLibrarians();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var form = new ChangeSelfPasswordForm())
            {
                form.ShowDialog();
               
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            int reportType = cboReportType.SelectedIndex;

            // Берем только дату, время не нужно
            DateTime dateStart = dtpReportStart.Value.Date;
            DateTime dateEnd = dtpReportEnd.Value.Date;

            string query = "";

            // Теперь мы просто вызываем функции
            switch (reportType)
            {
                case 0: // Эффективность сотрудников
                    query = "SELECT * FROM get_report_librarian_efficiency(@start, @end)";
                    break;

                case 1: // Список должников (параметры не нужны, но передача не сломает)
                    query = "SELECT * FROM get_report_debtors()";
                    break;

                case 2: // Популярные книги
                    query = "SELECT * FROM get_report_popular_books(@start, @end)";
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
                        
                        if (reportType != 1) // Для отчета "Должники" параметры не обязательны, но и не мешают
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("start", NpgsqlTypes.NpgsqlDbType.Date) { Value = dateStart });
                            cmd.Parameters.Add(new NpgsqlParameter("end", NpgsqlTypes.NpgsqlDbType.Date) { Value = dateEnd });
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            gridReports.DataSource = dt;
                            gridReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        private void ExportToCsv(string filename, string title, string period)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine(title);
            sb.AppendLine(period);
            sb.AppendLine($"Дата формирования:;{DateTime.Now}");
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
                        // === ИЗМЕНЕНИЕ ЗДЕСЬ ===
                        object rawValue = row.Cells[i].Value;
                        string cellValue = "";

                        if (rawValue is DateTime dt)
                            cellValue = dt.ToShortDateString();
                        else
                            cellValue = rawValue?.ToString() ?? "";

                        // Чистка для CSV
                        cellValue = cellValue.Replace(";", ",").Replace("\r", "").Replace("\n", " ");
                        sb.Append(cellValue + ";");
                    }
                    sb.AppendLine();
                }
            }

            System.IO.File.WriteAllText(filename, sb.ToString(), System.Text.Encoding.UTF8);
        }
        private void ExportToTxt(string filename, string title, string period)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                sw.WriteLine(new string('=', 50));
                sw.WriteLine($"ОТЧЕТ:  {title.ToUpper()}");
                sw.WriteLine($"ПЕРИОД: {period.Replace("Период: ", "")}");
                sw.WriteLine($"ДАТА:   {DateTime.Now}");
                sw.WriteLine(new string('=', 50));
                sw.WriteLine();

                // Вычисление ширины
                int[] colWidths = new int[gridReports.Columns.Count];
                for (int i = 0; i < gridReports.Columns.Count; i++) colWidths[i] = gridReports.Columns[i].HeaderText.Length;

                foreach (DataGridViewRow row in gridReports.Rows)
                {
                    for (int i = 0; i < gridReports.Columns.Count; i++)
                    {
                        
                        object rawValue = row.Cells[i].Value;
                        string val = "";

                        // Если это дата - убираем время
                        if (rawValue is DateTime dt)
                            val = dt.ToShortDateString();
                        else
                            val = rawValue?.ToString() ?? "";

                        if (val.Length > colWidths[i]) colWidths[i] = val.Length;
                    }
                }
                for (int i = 0; i < colWidths.Length; i++) colWidths[i] += 2;

                // Заголовки
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

                // Данные
                foreach (DataGridViewRow row in gridReports.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < gridReports.Columns.Count; i++)
                        {
                            // === ИЗМЕНЕНИЕ ЗДЕСЬ (То же самое, что выше) ===
                            object rawValue = row.Cells[i].Value;
                            string val = "";

                            if (rawValue is DateTime dt)
                                val = dt.ToShortDateString(); // Только дата (дд.мм.гггг)
                            else
                                val = rawValue?.ToString() ?? "";

                            sw.Write(val.PadRight(colWidths[i]));
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
        private void ExportToWord(string filename, string title, string period)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<html><body>");
            sb.Append($"<h1 style='text-align:center'>{title}</h1>");
            sb.Append($"<h3 style='text-align:center'>{period}</h3>");
            sb.Append($"<p style='text-align:center; color:#555; font-size:10pt'>Дата формирования: {DateTime.Now}</p>");
            sb.Append("<br>");

            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%'>");

            sb.Append("<tr style='background-color: #d9d9d9; font-weight: bold;'>");
            foreach (DataGridViewColumn col in gridReports.Columns)
            {
                sb.Append($"<td>{col.HeaderText}</td>");
            }
            sb.Append("</tr>");

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
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (gridReports.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportTitle = cboReportType.Text;

            // Формируем строку периода
            string periodInfo = $"Период: с {dtpReportStart.Value.ToShortDateString()} по {dtpReportEnd.Value.ToShortDateString()}";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файл (Excel) (*.csv)|*.csv|Текстовый файл (*.txt)|*.txt|Документ Word (*.doc)|*.doc";
            string cleanTitle = reportTitle.Replace(" ", "_");
            sfd.FileName = $"{cleanTitle}_{DateTime.Now:dd.MM.yyyy}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();

                    // Передаем periodInfo в каждый метод
                    switch (ext)
                    {
                        case ".csv":
                            ExportToCsv(sfd.FileName, reportTitle, periodInfo);
                            break;
                        case ".txt":
                            ExportToTxt(sfd.FileName, reportTitle, periodInfo);
                            break;
                        case ".doc":
                            ExportToWord(sfd.FileName, reportTitle, periodInfo);
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

        private void txtSearchGenre_TextChanged(object sender, EventArgs e)
        {
            LoadGenres(txtSearchGenre.Text.Trim());
        }

        private void txtSearchPublisher_TextChanged(object sender, EventArgs e)
        {
            LoadPublishers(txtSearchPublisher.Text.Trim());
        }

        private void txtSearchAuthor_TextChanged(object sender, EventArgs e)
        {
            LoadAuthors(txtSearchAuthor.Text.Trim());
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers(txtSearchSupplier.Text.Trim());
        }

        private void txtSearchFine_TextChanged(object sender, EventArgs e)
        {
            LoadFines(txtSearchFine.Text.Trim());
        }

        private void txtSearchLibrarian_TextChanged(object sender, EventArgs e)
        {
            LoadLibrarians(txtSearchLibrarian.Text.Trim());
        }
    }
}
