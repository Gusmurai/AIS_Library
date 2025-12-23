using AIS_Library.Database;
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

namespace AIS_Library.Forms.Librarian
{
    public partial class SupplyForm : Form
    {
        private readonly string _isbn; 

        public SupplyForm(string isbn, string bookTitle)
        {
            InitializeComponent();

  
            _isbn = isbn;
            this.Text = $"Поставка: {bookTitle}";

            LoadSuppliers();
        }
        private void LoadSuppliers()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // Нам нужен ИНН (строка) как ID
                using (var cmd = new NpgsqlCommand("SELECT inn, name FROM suppliers ORDER BY name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     
                        cmbSupplier.Items.Add(new { Inn = reader.GetString(0), Name = reader.GetString(1) });
                    }
                }
            }
            // Настройка отображения
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Inn";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Новая переменная типа object, которая может хранить как строку (ИНН),
            // так и специальное значение DBNull.Value для отправки NULL в базу.
            object supplierInnValue;

            // Проверяем состояние чекбокса
            if (chkNoSupplier.Checked)
            {
                // Если галочка стоит - поставщик не нужен.
                supplierInnValue = DBNull.Value;
            }
            else
            {
                // Если галочки нет, то поставщик ДОЛЖЕН быть выбран.
                // Выполняем старую проверку.
                if (cmbSupplier.SelectedItem == null)
                {
                    MessageBox.Show("Выберите поставщика из списка или отметьте галочкой 'Без поставщика'!", "Внимание");
                    return;
                }

                // Берем ИНН из выбранного элемента
                dynamic selectedItem = cmbSupplier.SelectedItem;
                supplierInnValue = selectedItem.Inn;
            }



            decimal cost = nudPrice.Value;
            int count = (int)nudCount.Value;

            if (MessageBox.Show($"Принять {count} экз. по цене {cost} руб.?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int newInvNum;
                            using (var cmdCopy = new NpgsqlCommand("INSERT INTO copies (book_isbn, cost) VALUES (@isbn, @cost) RETURNING inventory_number", conn))
                            {
                                cmdCopy.Transaction = transaction;
                                cmdCopy.Parameters.AddWithValue("isbn", _isbn);
                                cmdCopy.Parameters.AddWithValue("cost", cost);
                                newInvNum = (int)cmdCopy.ExecuteScalar();
                            }

                            string sqlDelivery = "INSERT INTO deliveries (supplier_inn, copy_inventory_number, delivery_date) VALUES (@inn, @inv, @date)";
                            using (var cmdDel = new NpgsqlCommand(sqlDelivery, conn))
                            {
                                cmdDel.Transaction = transaction;

                                // передаем нашу новую переменную
                                cmdDel.Parameters.AddWithValue("inn", supplierInnValue);

                                cmdDel.Parameters.AddWithValue("inv", newInvNum);
                                cmdDel.Parameters.AddWithValue("date", DateTime.Now);
                                cmdDel.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Поставка принята успешно!");
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void chkNoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            // Если галочка установлена
            if (chkNoSupplier.Checked)
            {
                // Делаем ComboBox неактивным и сбрасываем выбор
                cmbSupplier.Enabled = false;
                cmbSupplier.SelectedIndex = -1; // -1 означает, что ничего не выбрано
            }
            else
            {
                // Если галочку сняли, снова делаем ComboBox активным
                cmbSupplier.Enabled = true;
            }
        }
    }
}

