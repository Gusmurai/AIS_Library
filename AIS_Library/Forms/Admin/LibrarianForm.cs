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
using AIS_Library.Models;
using LibModel = AIS_Library.Models.Librarian;
namespace AIS_Library.Forms.Admin
{
    public partial class LibrarianForm : Form
    {
        private readonly int? _tabelNumber;
        private readonly string _originalLogin;

        // Временная переменная для нового пароля (при редактировании)
        private string _pendingNewPassword = null;

        // === КОНСТРУКТОР ДОБАВЛЕНИЯ ===
        public LibrarianForm()
        {
            InitializeComponent();
            _tabelNumber = null;
            this.Text = "Новый сотрудник";

            chkIsActive.Checked = true;
            chkIsActive.Enabled = false;

            // Настройка ЛОГИНА
            txtLogin.ReadOnly = false;
            btnChangeLogin.Visible = false;

            // Настройка ПАРОЛЯ
            txtPassword.Visible = true;
            txtPassword.ReadOnly = false;
            txtPassword.Text = ""; // Обязательно пусто
            txtPassword.PlaceholderText = " "; // Подсказка для ввода
            txtPassword.UseSystemPasswordChar = true; // Скрываем ввод звездочками
            btnChangePass.Visible = false;
        }

        // === КОНСТРУКТОР РЕДАКТИРОВАНИЯ ===
        public LibrarianForm(LibModel lib)
        {
            InitializeComponent();
            _tabelNumber = lib.TabelNumber;
            _originalLogin = lib.UserLogin;

            txtSurname.Text = lib.Surname;
            txtName.Text = lib.FirstName;
            txtPatronymic.Text = lib.Patronymic;
            txtPhone.Text = lib.Phone;
            chkIsActive.Checked = lib.IsActive;

            this.Text = "Редактирование сотрудника";

            // Настройка ЛОГИНА
            txtLogin.Text = lib.UserLogin;
            txtLogin.ReadOnly = true;
            btnChangeLogin.Visible = true;

            // Настройка ПАРОЛЯ
            txtPassword.Visible = true;
            txtPassword.Text = ""; // Обязательно пусто, чтобы было видно Placeholder
            txtPassword.PlaceholderText = "Пароль скрыт"; // <--- ВОТ ОНО
            txtPassword.ReadOnly = true;       // Писать напрямую нельзя
            txtPassword.UseSystemPasswordChar = false; // Отключаем звездочки, чтобы видеть текст плейсхолдера

            btnChangePass.Visible = true;
        }


        // === КНОПКА СМЕНЫ ПАРОЛЯ ===
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            // 1. Спрашиваем
            //if (MessageBox.Show("Вы действительно хотите сменить пароль сотрудника?",
            //    "Смена пароля", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            // 2. Открываем форму
            using (var passForm = new ChangePasswordForm())
            {
                if (passForm.ShowDialog() == DialogResult.OK)
                {
                    _pendingNewPassword = passForm.NewPassword;

                    // Визуально показываем, что изменение принято.
                    // Когда мы задаем Text, PlaceholderText автоматически скрывается.
                    txtPassword.Text = "Пароль будет изменен";
                    txtPassword.UseSystemPasswordChar = false; // Чтобы текст читался, а не был точками

                    MessageBox.Show("Новый пароль временно сохранен.\nНажмите 'Сохранить' внизу формы, чтобы записать изменения в БД.",
                        "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // === СОХРАНЕНИЕ ===
        private void btnSave_Click(object sender, EventArgs e)
        {
            string surname = txtSurname.Text.Trim();
            string name = txtName.Text.Trim();
            string patronymic = txtPatronymic.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string newLogin = txtLogin.Text.Trim();
            bool isActive = chkIsActive.Checked;

            // Определяем, какой пароль использовать
            // Если это создание - берем из текстбокса. 
            // Если редактирование - берем из временной переменной.
            string passwordToSave = (_tabelNumber == null) ? txtPassword.Text.Trim() : _pendingNewPassword;

            // 1. ВАЛИДАЦИЯ
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(newLogin))
            {
                MessageBox.Show("ФИО, Телефон и Логин обязательны!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // При СОЗДАНИИ пароль обязателен
            if (_tabelNumber == null && string.IsNullOrEmpty(passwordToSave))
            {
                MessageBox.Show("Задайте пароль для нового сотрудника!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // 2. ПОДТВЕРЖДЕНИЕ
            string question = (_tabelNumber == null)
                ? $"Принять на работу: {surname} {name}?"
                : $"Сохранить изменения: {surname} {name}?";

            if (MessageBox.Show(question, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            // 3. ТРАНЗАКЦИЯ В БД
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (_tabelNumber == null) // INSERT
                        {
                            // Хешируем пароль из TextBox
                            var (hash, salt) = PasswordHelper.HashPassword(passwordToSave);

                            string sqlUser = "INSERT INTO users (login, password_hash, password_salt, role) VALUES (@login, @hash, @salt, 1)";
                            using (var cmd = new NpgsqlCommand(sqlUser, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("login", newLogin);
                                cmd.Parameters.AddWithValue("hash", hash);
                                cmd.Parameters.AddWithValue("salt", salt);
                                cmd.ExecuteNonQuery();
                            }

                            string sqlLib = "INSERT INTO librarians (surname, first_name, patronymic, phone, user_login, is_active) VALUES (@s, @n, @p, @ph, @login, true)";
                            using (var cmd = new NpgsqlCommand(sqlLib, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("s", surname);
                                cmd.Parameters.AddWithValue("n", name);
                                cmd.Parameters.AddWithValue("p", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                                cmd.Parameters.AddWithValue("ph", phone);
                                cmd.Parameters.AddWithValue("login", newLogin);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else // UPDATE
                        {
                            // Обновляем данные
                            string sqlLib = "UPDATE librarians SET surname=@s, first_name=@n, patronymic=@p, phone=@ph, is_active=@active WHERE tabel_number=@id";
                            using (var cmd = new NpgsqlCommand(sqlLib, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("s", surname);
                                cmd.Parameters.AddWithValue("n", name);
                                cmd.Parameters.AddWithValue("p", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                                cmd.Parameters.AddWithValue("ph", phone);
                                cmd.Parameters.AddWithValue("active", isActive);
                                cmd.Parameters.AddWithValue("id", _tabelNumber);
                                cmd.ExecuteNonQuery();
                            }

                            // Логика обновления User (Логин и Пароль)
                            bool loginChanged = newLogin != _originalLogin;
                            bool passwordChanged = !string.IsNullOrEmpty(passwordToSave); // Проверяем переменную из формы смены пароля

                            if (loginChanged || passwordChanged)
                            {
                                string sqlUser = "UPDATE users SET ";
                                if (loginChanged) sqlUser += "login = @newLogin, ";
                                if (passwordChanged) sqlUser += "password_hash = @hash, password_salt = @salt, ";
                                sqlUser = sqlUser.TrimEnd(',', ' ') + " WHERE login = @oldLogin";

                                using (var cmd = new NpgsqlCommand(sqlUser, conn))
                                {
                                    cmd.Transaction = transaction;
                                    cmd.Parameters.AddWithValue("oldLogin", _originalLogin);
                                    if (loginChanged) cmd.Parameters.AddWithValue("newLogin", newLogin);
                                    if (passwordChanged)
                                    {
                                        var (hash, salt) = PasswordHelper.HashPassword(passwordToSave);
                                        cmd.Parameters.AddWithValue("hash", hash);
                                        cmd.Parameters.AddWithValue("salt", salt);
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (PostgresException ex)
                    {
                        transaction.Rollback();
                        this.DialogResult = DialogResult.None;
                        if (ex.SqlState == "23505") MessageBox.Show("Логин занят!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // === КНОПКА СМЕНЫ ЛОГИНА ===
        private void btnChangeLogin_Click(object sender, EventArgs e)
        {
            // Открываем форму смены логина
            using (var form = new ChangeLoginForm(txtLogin.Text))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем текст на главной форме
                    txtLogin.Text = form.NewLogin;

                    // Выводим напоминание (как и для пароля)
                    MessageBox.Show("Новый логин задан.\nНажмите 'Сохранить', чтобы записать изменения в БД.",
                                    "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

