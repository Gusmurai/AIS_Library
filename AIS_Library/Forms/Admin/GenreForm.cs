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
   
        public partial class GenreForm : Form
        {
            private readonly int? _id; // Если null - это добавление, если есть число - редактирование

            // Конструктор для ДОБАВЛЕНИЯ
            public GenreForm()
            {
                InitializeComponent();
                _id = null;
                this.Text = "Новый жанр";
            }

            // Конструктор для РЕДАКТИРОВАНИЯ
            public GenreForm(Genre genre)
            {
                InitializeComponent();
                _id = genre.Id;
                txtName.Text = genre.Name;
                txtDesc.Text = genre.Description;
                this.Text = "Редактирование жанра";
            }
       
            private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string desc = txtDesc.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; // Не закрывать форму
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_id == null) // INSERT
                    {
                        cmd = new NpgsqlCommand("INSERT INTO genres (name, description) VALUES (@name, @desc)", conn);
                    }
                    else // UPDATE
                    {
                        cmd = new NpgsqlCommand("UPDATE genres SET name = @name, description = @desc WHERE genre_id = @id", conn);
                        cmd.Parameters.AddWithValue("id", _id);
                    }

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("desc", desc);
                    cmd.ExecuteNonQuery();

                    // DialogResult = OK (настроено в свойствах кнопки), форма закроется сама
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None; // Оставляем форму открытой, чтобы исправить ошибку
                    if (ex.SqlState == "23505") MessageBox.Show("Такой жанр уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(ex.MessageText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
  