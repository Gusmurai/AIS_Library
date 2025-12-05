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
using System.Xml.Linq;
using Publisher = AIS_Library.Models.Publisher; // Уточняем класс

namespace AIS_Library.Forms.Admin
{
    public partial class PublisherForm : Form
    {
        private readonly int? _id;

        public PublisherForm() // Добавление
        {
            InitializeComponent();
            _id = null;
            this.Text = "Новое издательство";
        }

        public PublisherForm(Publisher pub) // Редактирование
        {
            InitializeComponent();
            _id = pub.Id;
            txtName.Text = pub.Name;
            txtCity.Text = pub.City;
            this.Text = "Редактирование издательства";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string city = txtCity.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Заполните название и город!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd = new NpgsqlCommand("INSERT INTO publishers (name, city) VALUES (@name, @city)", conn);
                    else
                    {
                        cmd = new NpgsqlCommand("UPDATE publishers SET name = @name, city = @city WHERE publisher_id = @id", conn);
                        cmd.Parameters.AddWithValue("id", _id);
                    }

                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("city", city);
                    cmd.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    this.DialogResult = DialogResult.None;
                    if (ex.SqlState == "23505") MessageBox.Show("Такое издательство в этом городе уже есть!", "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
