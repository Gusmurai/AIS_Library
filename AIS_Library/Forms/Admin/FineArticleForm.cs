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
    public partial class FineArticleForm : Form
    {
        private readonly int? _id; // ID статьи (null при добавлении)

        public FineArticleForm()
        {
            InitializeComponent();
            _id = null;
            this.Text = "Новая статья штрафа";
        }

        public FineArticleForm(FineArticle article)
        {
            InitializeComponent();
            _id = article.Id;
            txtName.Text = article.Name;
            txtDesc.Text = article.Description;
            // Если сумма null (например, цена книги), ставим 0
            nudAmount.Value = article.BaseAmount ?? 0;
            this.Text = "Редактирование статьи";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string desc = txtDesc.Text.Trim();
            decimal amount = nudAmount.Value;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Заполните название и описание!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Если 0, отправляем NULL (плавающая сумма), или оставляем 0 - зависит от твоей логики.
            // Давай сделаем: если 0, то записываем как 0.00 (фиксированная сумма 0), 
            // а NULL для штрафа "Утеря" лучше обрабатывать отдельно или считать 0 как "по цене книги".
            // В твоем коде ранее мы передавали (object)amount.
            object amountVal = amount > 0 ? (object)amount : DBNull.Value;

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_id == null) // INSERT
                    {
                        cmd = new NpgsqlCommand("INSERT INTO fine_articles (name, description, base_amount) VALUES (@name, @desc, @amount)", conn);
                    }
                    else // UPDATE
                    {
                        cmd = new NpgsqlCommand("UPDATE fine_articles SET name=@name, description=@desc, base_amount=@amount WHERE article_id=@id", conn);
                        cmd.Parameters.AddWithValue("id", _id);
                    }

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("desc", desc);
                    cmd.Parameters.AddWithValue("amount", amountVal);

                    cmd.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None;
                    // Вывод сообщения из триггера (проверка русского языка)
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
