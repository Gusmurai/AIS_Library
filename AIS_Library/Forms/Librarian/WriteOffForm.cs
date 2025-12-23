using AIS_Library.Database;
using AIS_Library.Helpers;
using Npgsql;
using System;
using System.Windows.Forms;

namespace AIS_Library.Forms.Librarian
{
    public partial class WriteOffForm : Form
    {
        private readonly int _inventoryNumber;
        private readonly int _librarianId;
        private readonly string _autoSelectReason; 
        // Конструктор
        public WriteOffForm(int inventoryNumber, string bookTitle, string autoSelectReason = null)
        {
            InitializeComponent();
            _inventoryNumber = inventoryNumber;
            _librarianId = AIS_Library.Models.UserInfo.LibrarianId;
            _autoSelectReason = autoSelectReason;

            this.Text = "Акт списания";
            lblInfo.Text = $"Списание экземпляра №{_inventoryNumber}\nКнига: {bookTitle}";

            // 1. Загружаем список
            LoadReasons();

            // 2. Логика автовыбора (если режим автоматический)
            if (!string.IsNullOrEmpty(_autoSelectReason))
            {
                foreach (var item in cmbReason.Items)
                {
                    if (item is ListItem listItem)
                    {
                
                      

                        bool match = listItem.Name.IndexOf(_autoSelectReason, StringComparison.OrdinalIgnoreCase) >= 0
                                     || _autoSelectReason.IndexOf(listItem.Name, StringComparison.OrdinalIgnoreCase) >= 0;

                        if (match)
                        {
                            cmbReason.SelectedItem = item;
                            cmbReason.Enabled = false; // Блокируем выбор

                            // Убираем возможность сбежать
                            btnCancel.Visible = false;
                            this.ControlBox = false; // Убираем крестик
                            break;
                        }
                    }
                }
            }
        }

        private void LoadReasons()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT reason_id, name FROM write_off_reasons ORDER BY name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        // ФИЛЬТРАЦИЯ ДЛЯ РУЧНОГО РЕЖИМА
                        // Если открыли вручную - Скрываем причины, связанные с утерей
                        if (string.IsNullOrEmpty(_autoSelectReason))
                        {
                            if (name.IndexOf("Утрата", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                name.IndexOf("Утеря", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                continue; // Пропускаем
                            }
                        }

                        cmbReason.Items.Add(new ListItem
                        {
                            Id = id,
                            Name = name
                        });
                    }
                }
            }
            cmbReason.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbReason.SelectedItem == null)
            {
                MessageBox.Show("Выберите причину списания!", "Внимание");
                return;
            }

            int reasonId = ((ListItem)cmbReason.SelectedItem).Id;

            // Если это не авто-режим, спрашиваем подтверждение. 
           
            if (string.IsNullOrEmpty(_autoSelectReason))
            {
                if (MessageBox.Show("Вы уверены, что хотите списать этот экземпляр?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Вызываем процедуру
                    string query = "CALL sp_write_off_copy(@inv, @lib, @reasonId)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("inv", _inventoryNumber);
                        cmd.Parameters.AddWithValue("lib", _librarianId);
                        cmd.Parameters.AddWithValue("reasonId", reasonId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Экземпляр успешно списан.");
                    this.DialogResult = DialogResult.OK;
                }
                catch (PostgresException ex)
                {
                    // Сообщение от базы
                    MessageBox.Show(ex.MessageText, "Ошибка списания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}