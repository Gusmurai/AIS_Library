using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIS_Library.Database;
using AIS_Library.Helpers; 
using AIS_Library.Models;
using Npgsql;

namespace AIS_Library.Forms.Librarian
{
    public partial class BookCopiesForm : Form
    {
        private readonly string _isbn;
        private readonly string _bookTitle;
        public BookCopiesForm(Book book)
        {
            InitializeComponent();
            _isbn = book.Isbn;
            _bookTitle = book.Title;

            lblBookInfo.Text = $"{book.Title} (ISBN: {book.Isbn})";
            this.Text = "Управление экземплярами";

            StyleHelper.ConfigureGrid(gridCopies);
            LoadCopies();
        }
        private void LoadCopies(string search = "")
        {
            List<Copy> copies = new List<Copy>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                // Базовый запрос
                string query = "SELECT inventory_number, cost, status FROM view_copies_status WHERE isbn = @isbn";

                // Если в поиске что-то есть, добавляем фильтр
                if (!string.IsNullOrEmpty(search))
                {
                    // CAST(... AS TEXT) превращает число в строку, чтобы работал LIKE
                    query += " AND CAST(inventory_number AS TEXT) LIKE @search";
                }

                query += @" ORDER BY 
            CASE WHEN status = 'Списан' THEN 2 ELSE 1 END, 
            inventory_number";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("isbn", _isbn);

                    // Добавляем параметр поиска с %
                    if (!string.IsNullOrEmpty(search))
                    {
                        cmd.Parameters.AddWithValue("search", $"%{search}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            copies.Add(new Copy
                            {
                                InventoryNumber = reader.GetInt32(0),
                                Cost = reader.GetDecimal(1),
                                Status = reader.GetString(2),
                                Isbn = _isbn,
                                Title = _bookTitle
                            });
                        }
                    }
                }
            }

            gridCopies.DataSource = null;
            gridCopies.DataSource = copies;

            // Настройка колонок (чтобы не слетали при обновлении)
            if (gridCopies.Columns["InventoryNumber"] != null) gridCopies.Columns["InventoryNumber"].HeaderText = "Инв. номер";
            if (gridCopies.Columns["Cost"] != null) gridCopies.Columns["Cost"].HeaderText = "Цена";
            if (gridCopies.Columns["Status"] != null) gridCopies.Columns["Status"].HeaderText = "Статус";

            // Скрываем лишнее
            if (gridCopies.Columns["Isbn"] != null) gridCopies.Columns["Isbn"].Visible = false;
            if (gridCopies.Columns["Title"] != null) gridCopies.Columns["Title"].Visible = false;
            if (gridCopies.Columns["DisplayText"] != null) gridCopies.Columns["DisplayText"].Visible = false;
        }
        private void btnSupply_Click(object sender, EventArgs e)
        {
            using (var form = new SupplyForm(_isbn, _bookTitle))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCopies(); // Обновляем список, появились новые книги
                }
            }
        }

        private void gridCopies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var copy = (Copy)gridCopies.Rows[e.RowIndex].DataBoundItem;
                if (copy.Status == "Списан")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightGray;
                    e.CellStyle.ForeColor = System.Drawing.Color.Gray;
                }
                else if (copy.Status == "Выдан")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.MistyRose; 
                }
                else if (copy.Status == "В наличии")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen; 
                }
            }
        }

        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            if (gridCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите экземпляр для списания!");
                return;
            }

            var selectedCopy = (Copy)gridCopies.SelectedRows[0].DataBoundItem;

            // Проверки перед списанием
            if (selectedCopy.Status == "Списан")
            {
                MessageBox.Show("Этот экземпляр уже списан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Открываем форму списания
            using (var form = new WriteOffForm(selectedCopy.InventoryNumber, _bookTitle))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCopies(txtSearchInv.Text.Trim()); 
                }
            }
        }

        private void txtSearchInv_TextChanged(object sender, EventArgs e)
        {
            // При каждом нажатии клавиши обновляем таблицу
            LoadCopies(txtSearchInv.Text.Trim());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (gridCopies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите экземпляр, чтобы посмотреть его историю.", "Внимание");
                return;
            }

            // Получаем данные
            var selectedCopy = (Copy)gridCopies.SelectedRows[0].DataBoundItem;

            // Открываем формуляр
            using (var form = new CopyHistoryForm(selectedCopy.InventoryNumber, _bookTitle))
            {
                form.ShowDialog();
            }
        }
    }
}
