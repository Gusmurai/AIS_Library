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

namespace AIS_Library.Forms.General
{
    public partial class ChangeSelfPasswordForm : Form
    {
        public ChangeSelfPasswordForm()
        {
            InitializeComponent();
            this.Text = "Смена пароля";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            // 1. Базовая валидация полей
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (oldPass == newPass)
            {
                MessageBox.Show("Новый пароль должен отличаться от старого!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {
                    // 2. Получаем текущие данные из БД
                    string currentLogin = UserInfo.Login;
                    string dbHash = "";
                    string dbSalt = "";

                    using (var cmdGet = new NpgsqlCommand("SELECT password_hash, password_salt FROM users WHERE login = @login", conn))
                    {
                        cmdGet.Parameters.AddWithValue("login", currentLogin);
                        using (var reader = cmdGet.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dbHash = reader.GetString(0);
                                dbSalt = reader.GetString(1);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: Пользователь не найден.", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // 3. Проверяем старый пароль
                    bool isOldValid = PasswordHelper.VerifyPassword(oldPass, dbHash, dbSalt);

                    if (!isOldValid)
                    {
                        MessageBox.Show("Старый пароль введен неверно!", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    // 4. ВОПРОС ПОЛЬЗОВАТЕЛЮ 
                    // Спрашиваем только тогда, когда уверены, что старый пароль верный
                    if (MessageBox.Show("Вы действительно хотите изменить свой пароль?", "Подтверждение смены пароля",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None; 
                        return;
                    }

                    // 5. Меняем пароль
                    var (newHash, newSalt) = PasswordHelper.HashPassword(newPass);

                    using (var cmdUpdate = new NpgsqlCommand("UPDATE users SET password_hash = @h, password_salt = @s WHERE login = @l", conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("h", newHash);
                        cmdUpdate.Parameters.AddWithValue("s", newSalt);
                        cmdUpdate.Parameters.AddWithValue("l", currentLogin);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show("Пароль успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при смене пароля: " + ex.Message);
                    this.DialogResult = DialogResult.None;
                }
            }
        }
    }
}
