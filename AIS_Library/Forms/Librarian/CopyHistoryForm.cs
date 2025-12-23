using AIS_Library.Database;
using AIS_Library.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_Library.Forms.Librarian
{
    public partial class CopyHistoryForm : Form
    {
        private readonly int _invNumber;
        public CopyHistoryForm(int invNumber, string bookTitle)
        {
            InitializeComponent();
            _invNumber = invNumber;

            this.Text = $"Формуляр экземпляра №{invNumber}";
            lblInfo.Text = $"Книга: {bookTitle} (Инв. №{invNumber})";

            // Применяем красоту
            StyleHelper.ConfigureGrid(gridHistory);

            LoadHistory();
        }

        private void LoadHistory()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // Загружаем историю для конкретного экземпляра
                string query = @"SELECT reader_name, ticket_number, phone, lend_date, due_date, return_date, librarian_short
                                 FROM view_copy_history
                                 WHERE copy_inventory_number = @id
                                 ORDER BY lend_date DESC"; // Новые сверху

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", _invNumber);

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridHistory.DataSource = dt;
                }
            }

            // Настройка колонок
            if (gridHistory.Columns["reader_name"] != null)
                gridHistory.Columns["reader_name"].HeaderText = "Читатель";

            if (gridHistory.Columns["ticket_number"] != null)
            {
                gridHistory.Columns["ticket_number"].HeaderText = "Билет";
                //gridHistory.Columns["ticket_number"].Width = 60;
            }

            if (gridHistory.Columns["phone"] != null)
                gridHistory.Columns["phone"].HeaderText = "Телефон";

            if (gridHistory.Columns["lend_date"] != null)
                gridHistory.Columns["lend_date"].HeaderText = "Дата выдачи";

            if (gridHistory.Columns["due_date"] != null)
                gridHistory.Columns["due_date"].HeaderText = "Вернуть до";

            if (gridHistory.Columns["return_date"] != null)
                gridHistory.Columns["return_date"].HeaderText = "Дата возврата";

            if (gridHistory.Columns["librarian_short"] != null)
                gridHistory.Columns["librarian_short"].HeaderText = "Сотрудник";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridHistory.Rows[e.RowIndex];

                // Если даты возврата нет - книга сейчас у этого человека
                if (row.Cells["return_date"].Value == DBNull.Value)
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew; // Зеленоватый
                    row.DefaultCellStyle.Font = new Font(gridHistory.Font, FontStyle.Bold);
                }
            }
        }
    }
}
