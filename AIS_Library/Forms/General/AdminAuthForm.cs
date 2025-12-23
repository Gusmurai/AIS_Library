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

namespace AIS_Library.Forms.General
{
    public partial class AdminAuthForm : Form
    {
        public AdminAuthForm()
        {
            InitializeComponent();

            this.Text = "Подтверждение прав";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string login = txtAdminLogin.Text.Trim();
            string password = txtAdminPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль администратора!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {
                    
                    string query = "SELECT role, password_hash, password_salt FROM users WHERE login = @login";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("login", login);

                        using (var reader = cmd.ExecuteReader())
                        {
                            // 1. ПРОВЕРКА ЛОГИНА
                            if (!reader.Read())
                            {
                                MessageBox.Show("Пользователь с таким логином не найден.",
                                    "Ошибка логина", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                            }

                            // Получаем данные пользователя
                            int role = reader.GetInt32(0);
                            string dbHash = reader.GetString(1);
                            string dbSalt = reader.GetString(2);

                            // 2. ПРОВЕРКА ПРАВ (РОЛИ)
                            if (role != 0) // Если не Админ (0)
                            {
                                MessageBox.Show("У этого пользователя нет прав администратора.",
                                    "Отказ в доступе", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.DialogResult = DialogResult.None;
                                return;
                            }

                            // 3. ПРОВЕРКА ПАРОЛЯ
                            if (!PasswordHelper.VerifyPassword(password, dbHash, dbSalt))
                            {
                                MessageBox.Show("Неверный пароль.",
                                    "Ошибка пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    this.DialogResult = DialogResult.None;
                }
            }
        }
    }
}
