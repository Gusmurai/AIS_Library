using System;
using System.Windows.Forms;
using Npgsql; 


using AIS_Library.Database;
using AIS_Library.Models;
using AIS_Library.Forms.Admin;
using AIS_Library.Forms.Librarian;


namespace AIS_Library.Forms.General
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

    
            if (DbHelper.TestConnection())
            {
                // Можно закомментировать эту строку, чтобы не мешала каждый раз
                MessageBox.Show("Подключение к PostgreSQL успешно!", "Успех");
            }
        }




        // КНОПКА "ВОЙТИ"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Запрашиваем данные. 
                    // ВАЖНО: Убедись, что в базе password_hash и password_salt не пустые!
                    string query = "SELECT role, password_hash, password_salt FROM users WHERE login = @u_login";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("u_login", login);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int role = reader.GetInt32(0);
                                string dbHash = reader.GetString(1);
                                string dbSalt = reader.GetString(2);

                              
                                bool isPasswordCorrect = Helpers.PasswordHelper.VerifyPassword(password, dbHash, dbSalt);

                                if (isPasswordCorrect)
                                {
                                    // Успех!
                                    UserInfo.Login = login;
                                    UserInfo.Role = role;

                                    reader.Close(); 

                                    if (role == 1)
                                    {
                                        LoadLibrarianId(login, conn);
                                    }

                                    this.Hide();

                                    if (role == 0)
                                    {
                                        var adminForm = new AdminMainForm();
                                        adminForm.Show();
                                        adminForm.FormClosed += (s, args) => this.Close();
                                    }
                                    else if (role == 1)
                                    {
                                        var libForm = new LibrarianMainForm();
                                        libForm.Show();
                                        libForm.FormClosed += (s, args) => this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // КНОПКА "ВЫХОД"
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Вспомогательный метод: получить ID библиотекаря
        private void LoadLibrarianId(string login, NpgsqlConnection conn)
        {
            try
            {
                string query = "SELECT tabel_number FROM librarians WHERE user_login = @login";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("login", login);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        UserInfo.LibrarianId = Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                // Если не нашли, не ломаем программу, просто ID будет 0
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}