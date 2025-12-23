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

namespace AIS_Library.Forms.Admin
{
    public partial class WriteOffReasonForm : Form
    {
        private readonly int? _id;

        public WriteOffReasonForm()
        {
            InitializeComponent();
            _id = null;
            this.Text = "Новая причина списания";
        }
        public WriteOffReasonForm(WriteOffReason reason)
        {
            InitializeComponent();
            _id = reason.Id;
            txtName.Text = reason.Name;
            this.Text = "Редактирование причины";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            // 1. Валидация на пустоту
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название причины!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // 2. ВОПРОС ПОЛЬЗОВАТЕЛЮ
            string action = (_id == null) ? "добавить" : "изменить";
            string question = $"Вы действительно хотите {action} причину списания: \"{name}\"?";

            if (MessageBox.Show(question, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            // 3. Сохранение
            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_id == null) // INSERT
                    {
                        cmd = new NpgsqlCommand("INSERT INTO write_off_reasons (name) VALUES (@name)", conn);
                    }
                    else // UPDATE
                    {
                        cmd = new NpgsqlCommand("UPDATE write_off_reasons SET name = @name WHERE reason_id = @id", conn);
                        cmd.Parameters.AddWithValue("id", _id);
                    }

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.ExecuteNonQuery();

          
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None;

                    if (ex.SqlState == "23505")
                        MessageBox.Show("Такая причина списания уже существует!", "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.SqlState == "P0001") 
                        MessageBox.Show(ex.MessageText, "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show(ex.MessageText, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
