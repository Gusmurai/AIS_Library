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
    public partial class AuthorForm : Form
    {
        private readonly int? _id;

        public AuthorForm()
        {
            InitializeComponent();
            _id = null;
            this.Text = "Новый автор";
            dtpBirth.Value = DateTime.Now.AddYears(-30); // Для удобства
        }

        public AuthorForm(Author author)
        {
            InitializeComponent();
            _id = author.Id;
            txtSurname.Text = author.Surname;
            txtName.Text = author.FirstName;
            txtPatronymic.Text = author.Patronymic;
            // Дата обязательна в БД, поэтому она точно есть
            if (author.DateOfBirth.HasValue) dtpBirth.Value = author.DateOfBirth.Value;

            this.Text = "Редактирование автора";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string surname = txtSurname.Text.Trim();
            string name = txtName.Text.Trim();
            string patronymic = txtPatronymic.Text.Trim();
            DateTime birthDate = dtpBirth.Value;

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Фамилия и Имя обязательны!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd;

                    if (_id == null)
                        cmd = new NpgsqlCommand("INSERT INTO authors (surname, first_name, patronymic, date_of_birth) VALUES (@s, @n, @p, @d)", conn);
                    else
                    {
                        cmd = new NpgsqlCommand("UPDATE authors SET surname=@s, first_name=@n, patronymic=@p, date_of_birth=@d WHERE author_id=@id", conn);
                        cmd.Parameters.AddWithValue("id", _id);
                    }

                    cmd.Parameters.AddWithValue("s", surname);
                    cmd.Parameters.AddWithValue("n", name);
                    cmd.Parameters.AddWithValue("p", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                    cmd.Parameters.AddWithValue("d", birthDate);

                    cmd.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None;
                    if (ex.SqlState == "23505") MessageBox.Show("Такой автор уже существует!", "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
