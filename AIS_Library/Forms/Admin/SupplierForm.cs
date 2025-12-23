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

namespace AIS_Library.Forms.Admin
{

    public partial class SupplierForm : Form
    {
        private readonly string _originalInn; // Храним старый ИНН для WHERE при update

        // Конструктор для ДОБАВЛЕНИЯ
        public SupplierForm()
        {
            InitializeComponent();
            _originalInn = null; 
            this.Text = "Новый поставщик";
        }

        // Конструктор для РЕДАКТИРОВАНИЯ
        public SupplierForm(Supplier supplier)
        {
            InitializeComponent();
            _originalInn = supplier.Inn; 

            txtInn.Text = supplier.Inn;
            txtName.Text = supplier.Name;
            txtAddress.Text = supplier.Address;
            txtPhone.Text = supplier.Phone;
            txtEmail.Text = supplier.Email;
            this.Text = "Редактирование поставщика";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Собираем данные
            string newInn = txtInn.Text.Trim();
            string name = txtName.Text.Trim();
            string addr = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(newInn) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(addr) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Все поля обязательны!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }


            string confirmationMessage = _originalInn == null
                ? "Вы действительно хотите добавить нового поставщика?"
                : "Вы действительно хотите сохранить изменения?";


            if (MessageBox.Show(confirmationMessage, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None; 
                return;
            }




            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_originalInn == null) // INSERT
                    {
                        cmd = new NpgsqlCommand("INSERT INTO suppliers (inn, name, address, phone, email) VALUES (@inn, @name, @addr, @phone, @email)", conn);
                        cmd.Parameters.AddWithValue("inn", newInn); // Для insert используем то, что ввели
                    }
                    else // UPDATE
                    {
                        // Обновляем всё, включая ИНН (если он изменился), ищем по старому ИНН
                        cmd = new NpgsqlCommand("UPDATE suppliers SET inn=@inn, name=@name, address=@addr, phone=@phone, email=@email WHERE inn=@oldInn", conn);
                        cmd.Parameters.AddWithValue("inn", newInn); // Новый ИНН
                        cmd.Parameters.AddWithValue("oldInn", _originalInn); // Старый ИНН для поиска
                    }

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("addr", addr);
                    cmd.Parameters.AddWithValue("phone", phone);
                    cmd.Parameters.AddWithValue("email", email);

                    cmd.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None; 
                    if (ex.SqlState == "23505")
                        MessageBox.Show("Поставщик с таким ИНН уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        // Выводим сообщение из триггера (валидация языка и т.д.)
                        MessageBox.Show(ex.MessageText, "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
