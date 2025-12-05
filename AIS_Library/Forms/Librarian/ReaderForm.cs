using AIS_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIS_Library.Helpers; // Обязательно для ImageHelper
using AIS_Library.Database;

using Npgsql;
namespace AIS_Library.Forms.Librarian
{
    public partial class ReaderForm : Form
    {
        private readonly int? _ticketNumber;
        public ReaderForm()
        {
            InitializeComponent();
            this.Text = "Новый читатель";
            dtpBirth.Value = DateTime.Now.AddYears(-18); // По умолчанию ставим 18 лет назад
        }

        // РЕДАКТИРОВАНИЕ
        public ReaderForm(Reader reader)
        {
            InitializeComponent();
            _ticketNumber = reader.TicketNumber;
            this.Text = $"Карточка читателя №{reader.TicketNumber}";

            txtSurname.Text = reader.Surname;
            txtName.Text = reader.FirstName;
            txtPatronymic.Text = reader.Patronymic;
            dtpBirth.Value = reader.DateOfBirth; // NOT NULL в БД

            txtPassportSeria.Text = reader.PassportSeries;
            txtPassportNum.Text = reader.PassportNumber;
            txtAddress.Text = reader.Address;
            txtPhone.Text = reader.Phone;

            // Загрузка фото
            if (reader.Photo != null && reader.Photo.Length > 0)
            {
                pbPhoto.Image = ImageHelper.BytesToImage(reader.Photo);
            }
        }

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Проверка на размер файла (опционально, например не больше 2МБ)
                    var fileInfo = new System.IO.FileInfo(ofd.FileName);
                    if (fileInfo.Length > 2 * 1024 * 1024)
                    {
                        MessageBox.Show("Файл слишком большой! Выберите фото до 2 МБ.");
                        return;
                    }
                    pbPhoto.Image = Image.FromFile(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить изображение.");
                }
            }
        }

        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
            pbPhoto.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Сбор данных
            string surname = txtSurname.Text.Trim();
            string name = txtName.Text.Trim();
            string patronymic = txtPatronymic.Text.Trim();
            DateTime birth = dtpBirth.Value;

            string passSeria = txtPassportSeria.Text.Trim();
            string passNum = txtPassportNum.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // 1. Валидация на пустоту (все поля кроме Отчества и Фото - NOT NULL)
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(passSeria) || string.IsNullOrEmpty(passNum) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Заполните все обязательные поля!\n(ФИО, Паспорт, Адрес, Телефон)", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Конвертация фото
            byte[] photoBytes = ImageHelper.ImageToBytes(pbPhoto.Image);

            // 2. Вопрос
            string action = _ticketNumber == null ? "зарегистрировать" : "сохранить данные";
            if (MessageBox.Show($"Вы уверены, что хотите {action} читателя {surname} {name}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            // 3. Запрос к БД
            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_ticketNumber == null) // INSERT
                    {
                        string query = @"INSERT INTO readers 
                            (surname, first_name, patronymic, date_of_birth, passport_series, passport_number, address, phone, photo, registration_date)
                            VALUES (@s, @n, @p, @d, @ps, @pn, @addr, @ph, @photo, CURRENT_DATE)";
                        cmd = new NpgsqlCommand(query, conn);
                    }
                    else // UPDATE
                    {
                        string query = @"UPDATE readers SET 
                            surname=@s, first_name=@n, patronymic=@p, date_of_birth=@d, 
                            passport_series=@ps, passport_number=@pn, address=@addr, phone=@ph, photo=@photo
                            WHERE ticket_number=@id";
                        cmd = new NpgsqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("id", _ticketNumber);
                    }

                    // Параметры
                    cmd.Parameters.AddWithValue("s", surname);
                    cmd.Parameters.AddWithValue("n", name);
                    cmd.Parameters.AddWithValue("p", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                    cmd.Parameters.AddWithValue("d", birth);
                    cmd.Parameters.AddWithValue("ps", passSeria);
                    cmd.Parameters.AddWithValue("pn", passNum);
                    cmd.Parameters.AddWithValue("addr", address);
                    cmd.Parameters.AddWithValue("ph", phone);
                    cmd.Parameters.AddWithValue("photo", photoBytes ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    // DialogResult = OK сработает сам
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None;

                    if (ex.SqlState == "23505") // Уникальность паспорта
                        MessageBox.Show("Читатель с такими паспортными данными уже зарегистрирован!", "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        // P0001 (твои триггеры) или CHECK constraints
                        MessageBox.Show(ex.MessageText, "Ошибка проверки данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}
