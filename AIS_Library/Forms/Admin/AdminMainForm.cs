using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;
using AIS_Library.Database;
using AIS_Library.Models;
using Publisher = AIS_Library.Models.Publisher;
using LibModel = AIS_Library.Models.Librarian;
using AIS_Library.Forms.General;
namespace AIS_Library.Forms.Admin;

using AIS_Library.Helpers;
using System.Data;

public partial class AdminMainForm : Form
{ // Флаг: true, если мы перезапускаем программу специально
    private bool _isRestoring = false;
    public AdminMainForm()
    {
        // Дизайн интерфейса кабинета администратора
        InitializeComponent();

        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridGenres);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridPublishers);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridAuthors);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridSuppliers);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridFines);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridLibrarians);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReports);
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridAllFines);

        // Настройка фильтра штрафов
        cboFineStatus.SelectedIndex = 0; // Выбираем пункт "Все" по умолчанию

        LoadFinesHistory();

        // Устанавливаем период: с 1-го числа текущего месяца по сегодня
        dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpEnd.Value = DateTime.Now;


        // Загружаем данные при открытии формы
        LoadGenres();
        LoadPublishers();
        LoadAuthors();
        LoadSuppliers();
        LoadFines();
        LoadLibrarians();

        // Стиль таблицы
        AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReasons);

        // Первичная загрузка
        LoadReasons();

        // Настройка отчетов
        cboReportType.SelectedIndex = 0; // Выбираем первый пункт по умолчанию
        dtpReportStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 1 число текущего месяца
        dtpReportEnd.Value = DateTime.Now;




        StyleHelper.ConfigureGrid(gridWriteOffs);
        LoadWriteOffs();

        dtpWriteOffStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // 1 число текущего месяца
        dtpWriteOffEnd.Value = DateTime.Now;
    }


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

                    MessageBox.Show(ex.MessageText, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }



    private void LoadAuthors(string searchText = "")
    {
        List<Author> authors = new List<Author>();
        using (var conn = DbHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT author_id, surname, first_name, patronymic, date_of_birth FROM authors";

            if (!string.IsNullOrEmpty(searchText))
            {

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

                    MessageBox.Show(ex.MessageText, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
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

            query += " ORDER BY is_active DESC, surname";

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
    // ОТЧЁТ
    private void btnGenerateReport_Click(object sender, EventArgs e)
    {
        int reportType = cboReportType.SelectedIndex;

        // Берем только дату, время не нужно
        DateTime dateStart = dtpReportStart.Value.Date;
        DateTime dateEnd = dtpReportEnd.Value.Date;

        string query = "";

        switch (reportType)
        {
            case 0: // Эффективность сотрудников
                query = "SELECT * FROM get_report_librarian_efficiency(@start, @end)";
                break;

            case 1: // Список должников (параметры не нужны)
                query = "SELECT * FROM get_report_debtors()";
                break;

            case 2: // Популярные книги
                query = "SELECT * FROM get_report_popular_books(@start, @end)";
                break;

            case 3: // Неоплаченные штрафы
                query = "SELECT * FROM get_report_unpaid_fines_list(@start, @end)";
                break;

            case 4: // Состояние фонда (параметры не нужны)
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
                    // Передаем параметры только если отчет их требует
                    // (1-Должники и 4-Фонд не требуют дат)
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

                        // Применяем красивый стиль
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
                MessageBox.Show("Ошибка при формировании отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ==========================================
    // ЭКСПОРТ (КНОПКА)
    // ==========================================

    private void btnExportReport_Click(object sender, EventArgs e)
    {
        if (gridReports.Rows.Count == 0)
        {
            MessageBox.Show("Нет данных для экспорта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string reportTitle = cboReportType.Text;
        string periodInfo = "";

        // Если даты активны (отчет за период), формируем строку.
        // Если отчет моментальный (как "Состояние фонда"), оставляем пустоту.
        if (dtpReportStart.Enabled)
        {
            periodInfo = $"Период: с {dtpReportStart.Value.ToShortDateString()} по {dtpReportEnd.Value.ToShortDateString()}";
        }

        // Подпись
        string signature = "Отчёт сформировал: Администратор";

        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "CSV файл (Excel) (*.csv)|*.csv|Текстовый файл (*.txt)|*.txt|Документ Word (*.doc)|*.doc";
        string cleanTitle = reportTitle.Replace(" ", "_");
        sfd.FileName = $"{cleanTitle}_{DateTime.Now:dd.MM.yyyy}";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();

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

    // ==========================================
    // МЕТОДЫ ЭКСПОРТА
    // ==========================================

    private void ExportToCsv(string filename, string title, string period, string signature)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine(title);
        if (!string.IsNullOrEmpty(period)) sb.AppendLine(period);

        // БЕЗ ВРЕМЕНИ
        sb.AppendLine($"Дата формирования:;{DateTime.Now.ToShortDateString()}");

        sb.AppendLine(signature);
        sb.AppendLine();

        // ... (остальной код цикла по строкам без изменений) ...
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

                    if (rawValue is DateTime dt)
                        cellValue = dt.ToShortDateString();
                    else
                        cellValue = rawValue?.ToString() ?? "";

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
            if (!string.IsNullOrEmpty(period))
                sw.WriteLine($"ПЕРИОД: {period.Replace("Период: ", "")}");

            // БЕЗ ВРЕМЕНИ
            sw.WriteLine($"ДАТА:   {DateTime.Now.ToShortDateString()}");

            sw.WriteLine(signature);
            sw.WriteLine(new string('=', 50));
            sw.WriteLine();

            // ... (дальше код выравнивания ширины и циклов без изменений) ...
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

        // Заголовок (Times New Roman)
        // \"Times New Roman\" — экранируем кавычки, чтобы имя шрифта было точным
        sb.Append($"<h1 style='text-align:center; font-family:\"Times New Roman\"'>{title}</h1>");

        // Период (Times New Roman)
        if (!string.IsNullOrEmpty(period))
        {
            sb.Append($"<h3 style='text-align:center; font-family:\"Times New Roman\"'>{period}</h3>");
        }

        // Дата формирования (Times New Roman)
        sb.Append($"<p style='text-align:center; font-family:\"Times New Roman\"'>Дата формирования: {DateTime.Now.ToShortDateString()}</p>");

        // Подпись (Times New Roman)
        sb.Append($"<p style='text-align:center; font-family:\"Times New Roman\"'>{signature}</p>");

        sb.Append("<br>");

        // Таблица (Оставляем Arial, как вы просили "кроме данных в таблице")
        sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%; font-family:Arial'>");

        // Заголовки таблицы (Фон серый)
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

    private void btnAddReason_Click(object sender, EventArgs e)
    {
        using (var form = new WriteOffReasonForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadReasons();
                MessageBox.Show("Причина добавлена!");
            }
        }
    }

    private void LoadReasons(string search = "")
    {
        List<WriteOffReason> reasons = new List<WriteOffReason>();

        using (var conn = DbHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT reason_id, name FROM write_off_reasons";

            if (!string.IsNullOrEmpty(search))
            {
                query += " WHERE name ILIKE @search";
            }

            query += " ORDER BY name";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("search", $"%{search}%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reasons.Add(new WriteOffReason
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
        }

        gridReasons.DataSource = null;
        gridReasons.DataSource = reasons;

        if (gridReasons.Columns["Id"] != null) gridReasons.Columns["Id"].Visible = false;
        if (gridReasons.Columns["Name"] != null) gridReasons.Columns["Name"].HeaderText = "Причина списания";
    }
    private void btnEditReason_Click(object sender, EventArgs e)
    {
        if (gridReasons.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите строку для редактирования!");
            return;
        }

        var selected = (WriteOffReason)gridReasons.SelectedRows[0].DataBoundItem;

        using (var form = new WriteOffReasonForm(selected))
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadReasons();
                MessageBox.Show("Причина обновлена!");
            }
        }
    }

    private void btnDeleteReason_Click(object sender, EventArgs e)
    {
        if (gridReasons.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите строку для удаления!", "Внимание");
            return;
        }

        var selected = (WriteOffReason)gridReasons.SelectedRows[0].DataBoundItem;

        // ВОПРОС ПОЛЬЗОВАТЕЛЮ
        if (MessageBox.Show($"Вы действительно хотите УДАЛИТЬ причину списания \"{selected.Name}\"?\nЭто действие нельзя отменить.",
            "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM write_off_reasons WHERE reason_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("id", selected.Id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Причина удалена.");
                    LoadReasons();
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState == "23503")
                        MessageBox.Show("Нельзя удалить эту причину, так как она уже использовалась в актах списания книг!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.MessageText, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }


    private void LoadFinesHistory()
    {
        using (var conn = DbHelper.GetConnection())
        {
            conn.Open();

            string query = @"SELECT fine_id, issue_date, payment_date, ticket_number, reader_fullname, book_title, article_name, amount, is_paid, comment 
                         FROM view_all_fines_extended 
                         WHERE issue_date BETWEEN @start AND @end";

            if (!string.IsNullOrEmpty(txtSearFine.Text))
            {
                query += @" AND (reader_fullname ILIKE @s 
                             OR article_name ILIKE @s 
                             OR book_title ILIKE @s  
                             OR CAST(ticket_number AS TEXT) LIKE @s)";
            }


            if (cboFineStatus.SelectedIndex == 1)
            {
                query += " AND is_paid = FALSE";
            }
            else if (cboFineStatus.SelectedIndex == 2)
            {
                query += " AND is_paid = TRUE";
            }


            query += " ORDER BY issue_date DESC";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.Add(new NpgsqlParameter("start", NpgsqlTypes.NpgsqlDbType.Date) { Value = dtpStart.Value.Date });
                cmd.Parameters.Add(new NpgsqlParameter("end", NpgsqlTypes.NpgsqlDbType.Date) { Value = dtpEnd.Value.Date });

                if (!string.IsNullOrEmpty(txtSearFine.Text))
                    cmd.Parameters.AddWithValue("s", $"%{txtSearFine.Text.Trim()}%");

                System.Data.DataTable dt = new System.Data.DataTable();
                new NpgsqlDataAdapter(cmd).Fill(dt);
                gridAllFines.DataSource = dt;

                decimal total = 0;
                foreach (DataRow row in dt.Rows) total += (decimal)row["amount"];
                lblTotal.Text = $"Итого по списку: {total:C2}";
            }
        }


        if (gridAllFines.Columns["fine_id"] != null) gridAllFines.Columns["fine_id"].Visible = false;

        if (gridAllFines.Columns["issue_date"] != null) gridAllFines.Columns["issue_date"].HeaderText = "Выписан";
        if (gridAllFines.Columns["payment_date"] != null) gridAllFines.Columns["payment_date"].HeaderText = "Дата оплаты";


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

        if (gridAllFines.Columns["comment"] != null) gridAllFines.Columns["comment"].HeaderText = "Заметки";
    }
    private void txtSearchReason_TextChanged(object sender, EventArgs e)
    {
        LoadReasons(txtSearchReason.Text.Trim());
    }


    private void btnFilter_Click(object sender, EventArgs e)
    {
        LoadFinesHistory();
    }

    private void btnAnnulFine_Click(object sender, EventArgs e)
    {
        if (gridAllFines.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите штраф для аннулирования.", "Внимание");
            return;
        }

        var row = gridAllFines.SelectedRows[0];
        int fineId = Convert.ToInt32(row.Cells["fine_id"].Value);
        string reader = row.Cells["reader_fullname"].Value.ToString();
        bool isPaid = Convert.ToBoolean(row.Cells["is_paid"].Value);


        if (isPaid)
        {
            MessageBox.Show("Этот штраф уже оплачен. Аннулирование невозможно.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        using (var choiceForm = new AnnulmentChoiceForm())
        {
            if (choiceForm.ShowDialog() == DialogResult.OK)
            {
                bool restoreBook = choiceForm.ShouldRestoreBook;

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

                        string msg = "Штраф успешно аннулирован.";

                        if (restoreBook)
                        {

                            msg += "\n\nЭкземпляр вернулся в фонд (статус 'В наличии').";
                        }
                        else
                        {

                            msg += "\n\nСтарый экземпляр остался в статусе 'Списан' (так как он утерян).";
                            msg += "\n\nВАЖНО: Принесенную взамен книгу БИБЛИОТЕКАРЮ необходимо оформить как новое поступление:";
                            msg += "\n1. Если книга уже есть в каталоге — через кнопку 'Поставка'.";
                            msg += "\n2. Если это новая книга — через кнопку 'Добавить книгу'.";
                        }

                        MessageBox.Show(msg, "Операция выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadFinesHistory();
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
        }
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

    private void txtSearFine_TextChanged(object sender, EventArgs e)
    {
        LoadFinesHistory();
    }



    private void LoadWriteOffs()
    {
        using (var conn = DbHelper.GetConnection())
        {
            conn.Open();
            string query = @"SELECT write_off_id, write_off_date, inventory_number, book_title, reason, librarian_name, cost 
                         FROM view_write_offs_full
                         WHERE write_off_date BETWEEN @start AND @end";


            if (!string.IsNullOrEmpty(txtSearchWriteOff.Text))
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
                cmd.Parameters.Add(new NpgsqlParameter("start", NpgsqlTypes.NpgsqlDbType.Date) { Value = dtpWriteOffStart.Value.Date });
                cmd.Parameters.Add(new NpgsqlParameter("end", NpgsqlTypes.NpgsqlDbType.Date) { Value = dtpWriteOffEnd.Value.Date });

                if (!string.IsNullOrEmpty(txtSearchWriteOff.Text))
                    cmd.Parameters.AddWithValue("search", $"%{txtSearchWriteOff.Text.Trim()}%");

                System.Data.DataTable dt = new System.Data.DataTable();
                new NpgsqlDataAdapter(cmd).Fill(dt);
                gridWriteOffs.DataSource = dt;


                decimal totalSum = 0;


                foreach (DataRow row in ((DataTable)gridWriteOffs.DataSource).Rows)
                {
                    if (row["cost"] != DBNull.Value)
                    {
                        totalSum += Convert.ToDecimal(row["cost"]);
                    }
                }


                int count = gridWriteOffs.Rows.Count;

                lbWriteOffsTotal.Text = $"Списано книг за период: {count} шт.  |  Общая сумма ущерба: {totalSum:C2}";
            }
        }


        if (gridWriteOffs.Columns["write_off_id"] != null) gridWriteOffs.Columns["write_off_id"].Visible = false;

        if (gridWriteOffs.Columns["write_off_date"] != null) gridWriteOffs.Columns["write_off_date"].HeaderText = "Дата";
        if (gridWriteOffs.Columns["inventory_number"] != null) gridWriteOffs.Columns["inventory_number"].HeaderText = "Инв. №";

        if (gridWriteOffs.Columns["book_title"] != null)
        {
            gridWriteOffs.Columns["book_title"].HeaderText = "Книга";
            gridWriteOffs.Columns["book_title"].FillWeight = 200;
        }

        if (gridWriteOffs.Columns["reason"] != null) gridWriteOffs.Columns["reason"].HeaderText = "Причина";
        if (gridWriteOffs.Columns["librarian_name"] != null) gridWriteOffs.Columns["librarian_name"].HeaderText = "Сотрудник";

        if (gridWriteOffs.Columns["cost"] != null)
        {
            gridWriteOffs.Columns["cost"].HeaderText = "Цена";
            gridWriteOffs.Columns["cost"].DefaultCellStyle.Format = "C2";
        }
    }

    private void btnFilterWriteOff_Click(object sender, EventArgs e)
    {
        LoadWriteOffs();
    }

    private void btnRestoreCopy_Click(object sender, EventArgs e)
    {
        if (gridWriteOffs.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите запись для восстановления!", "Внимание");
            return;
        }

        var row = gridWriteOffs.SelectedRows[0];

        string reason = row.Cells["reason"].Value.ToString();


        if (reason == "Утрата читателем")
        {
            MessageBox.Show(
                "Это списание связано с утерей книги читателем и начислением штрафа.\n\n" +
                "Вы не можете восстановить книгу отсюда, так как это нарушит финансовую отчетность.\n\n" +
                "Действия:\n" +
                "1. Перейдите на вкладку 'Штрафы'.\n" +
                "2. Найдите неоплаченный штраф этого читателя.\n" +
                "3. Нажмите 'Аннулировать' -> выберите 'Читатель нашел книгу'.\n\n" +
                "Если штраф уже оплачен, восстановление невозможно (книга считается выкупленной).",
                "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }


        int writeOffId = Convert.ToInt32(row.Cells["write_off_id"].Value);
        int invNum = Convert.ToInt32(row.Cells["inventory_number"].Value);
        string title = row.Cells["book_title"].Value.ToString();

        if (MessageBox.Show($"Вы уверены, что хотите отменить списание книги \"{title}\" (Инв. №{invNum})?\nПричина: {reason}.\n\nКнига снова станет доступной в фонде.",
            "Восстановление на баланс", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {

                    using (var cmd = new NpgsqlCommand("CALL sp_restore_copy(@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("id", writeOffId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Экземпляр успешно восстановлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWriteOffs();
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show(ex.MessageText, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }

    private void txtSearchWriteOff_TextChanged(object sender, EventArgs e)
    {
        LoadWriteOffs();
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


        if (!articleName.Contains("Порча"))
        {
            MessageBox.Show($"Изменение суммы для нарушения \"{articleName}\" запрещено.\n\n" +
                            "Вручную можно менять только сумму за Порчу книги.\n" +
                            "Штрафы за Утерю и Просрочку рассчитываются автоматически.",
                            "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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
                        MessageBox.Show("Сумма штрафа обновлена.", "Успех");
                        LoadFinesHistory();
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

    private void gridLibrarians_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {

        if (e.RowIndex >= 0)
        {

            var row = gridLibrarians.Rows[e.RowIndex];

            bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);


            if (isActive)
            {
                // Работающий сотрудник
                row.DefaultCellStyle.BackColor = Color.PaleGreen;
                row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }

    private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int type = cboReportType.SelectedIndex;
        // Даты НЕ нужны только для 1 (Должники) и 4 (Фонд)
        bool isPeriodRequired = (type != 1 && type != 4);

        dtpReportStart.Enabled = isPeriodRequired;
        dtpReportEnd.Enabled = isPeriodRequired;
    }

    private void btnBackup_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "Backup Files (*.backup)|*.backup";
        sfd.FileName = $"LibraryBackup_{DateTime.Now:yyyy-MM-dd_HH-mm}.backup";

        if (sfd.ShowDialog() == DialogResult.OK)
        {

            if (MessageBox.Show($"Вы действительно хотите создать резервную копию в файл:\n{sfd.FileName}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Отмена
            }

            this.Cursor = Cursors.WaitCursor; // Курсор ожидания
            try
            {
                AIS_Library.Helpers.BackupService.BackupDatabase(sfd.FileName);

                MessageBox.Show("Резервная копия успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Возвращаем обычный курсор
            }
        }
    }

    private async void btnRestore_Click(object sender, EventArgs e)
    {
        // ЭТАП 1: Предупреждение о потере данных
        // MessageBoxDefaultButton.Button2 делает кнопку "Нет" активной по умолчанию (защита от случайного Enter)
        if (MessageBox.Show("ВНИМАНИЕ! Текущая база данных будет ПОЛНОСТЬЮ ЗАМЕНЕНА.\n\n" +
                            "Все изменения, сделанные после создания резервной копии, будут безвозвратно потеряны.\n\n" +
                            "Вы уверены, что хотите продолжить?",
                            "Критическое действие",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
        {
            return;
        }

        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Backup Files (*.backup)|*.backup";
        ofd.Title = "Выберите файл резервной копии для восстановления";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            // ЭТАП 2: Финальное подтверждение с именем файла
            if (MessageBox.Show($"Вы выбрали файл:\n{ofd.FileName}\n\n" +
                                "Начать процесс восстановления? Это может занять некоторое время.",
                                "Подтверждение запуска",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Подготовка интерфейса
            txtBackupLog.Clear();
            txtBackupLog.AppendText("--- Инициализация процесса восстановления ---\r\n");
            this.Enabled = false;       // Блокируем форму, чтобы не нажали что-то еще
            this.Cursor = Cursors.WaitCursor; // Часики

            try
            {
                // Запуск задачи в фоне
                await Task.Run(() =>
                {
                    AIS_Library.Helpers.BackupService.RestoreDatabase(ofd.FileName, (message) =>
                    {
                        // Безопасное обновление текстового поля из другого потока
                        this.Invoke((MethodInvoker)delegate
                        {
                            txtBackupLog.AppendText(message + Environment.NewLine);
                            txtBackupLog.SelectionStart = txtBackupLog.Text.Length;
                            txtBackupLog.ScrollToCaret();
                        });
                    });
                });

                // Успех
                MessageBox.Show("База данных успешно восстановлена!\n\nПриложение будет перезапущено для обновления данных.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isRestoring = true; // Поднимаем флаг: "Это перезапуск, бэкап не нужен"
                Application.Restart();
                Application.Restart();
            }
            catch (Exception ex)
            {
                // Ошибка
                txtBackupLog.AppendText("\r\n!!! ОШИБКА: " + ex.Message);
                MessageBox.Show("Произошла ошибка при восстановлении:\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Этот блок сработает, если была ошибка (при успехе сработает Restart)
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
    private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_isRestoring)
        {
            return;
        }

        // Спрашиваем, нужен ли автоматический бэкап
        if (MessageBox.Show("Создать актуальную резервную копию базы данных перед выходом?",
            "Автоматический бэкап", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            // Формируем имя файла по умолчанию
            string defaultFileName = $"LibraryBackup_Auto_{DateTime.Now:yyyy-MM-dd_HH-mm}.backup";
            string filePath = Path.Combine(Application.StartupPath, defaultFileName); // Сохраняем рядом с EXE

            try
            {
                // Здесь не нужны SaveFileDialog, сохраняем в файл по умолчанию
                AIS_Library.Helpers.BackupService.BackupDatabase(filePath);
                MessageBox.Show($"Актуальная резервная копия успешно создана:\n{filePath}", "Бэкап", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Если бэкап не удался, предупреждаем, но не блокируем закрытие программы
                MessageBox.Show($"Ошибка при создании автоматического бэкапа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}