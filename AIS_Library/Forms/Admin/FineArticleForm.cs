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
        private readonly int? _id; 

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

      
            string confirmationMessage = _id == null
                ? "Вы действительно хотите добавить новую статью штрафа?"
                : "Вы действительно хотите сохранить изменения?";

            // Показываем диалоговое окно и проверяем ответ
            if (MessageBox.Show(confirmationMessage, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None; 
                return; 
            }

           
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

                   
                    if (ex.SqlState == "23505")
                    {
                        MessageBox.Show("Статья штрафа с таким названием уже существует!", "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       
                        MessageBox.Show(ex.MessageText, "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
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

