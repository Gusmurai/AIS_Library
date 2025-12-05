using AIS_Library.Database;
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
        public LibrarianMainForm()
        {
            InitializeComponent();

            // Отображаем, кто работает
            this.Text = $"АИС Библиотека | Сотрудник: {UserInfo.Login}";

            AIS_Library.Helpers.StyleHelper.ConfigureGrid(gridReaders);

            LoadReaders();
        }

        // ЗАГРУЗКА И ПОИСК
        private void LoadReaders(string searchText = "")
        {
            List<Reader> readers = new List<Reader>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // Выбираем все поля
                string query = @"SELECT ticket_number, surname, first_name, patronymic, date_of_birth, 
                                        passport_series, passport_number, address, phone, registration_date, photo 
                                 FROM readers";

                // Умный поиск (ФИО, Телефон, Номер билета, Паспорт)
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" WHERE CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @search
                                   OR phone ILIKE @search 
                                   OR CAST(ticket_number AS TEXT) ILIKE @search
                                   OR passport_number ILIKE @search";
                }

                query += " ORDER BY surname";

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
                                // Фото читаем в массив байт (нужно для передачи в форму редактирования)
                                Photo = reader.IsDBNull(10) ? null : (byte[])reader["photo"]
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
            if (gridReaders.Columns["RegistrationDate"] != null) gridReaders.Columns["RegistrationDate"].Visible = false;
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

            using (var form = new ReaderForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReaders();
                    MessageBox.Show("Данные читателя обновлены.");
                }
            }
        }
    }
}
