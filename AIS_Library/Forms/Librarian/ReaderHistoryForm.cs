using AIS_Library.Database;
using AIS_Library.Helpers;
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

namespace AIS_Library.Forms.Librarian
{
    public partial class ReaderHistoryForm : Form
    {
        private readonly int _ticketNumber;
        public ReaderHistoryForm(int ticketNumber, string readerName)

        {
            InitializeComponent();

            _ticketNumber = ticketNumber;

            this.Text = $"Формуляр №{ticketNumber}";
            lblReaderInfo.Text = $"Читатель: {readerName} (Билет №{ticketNumber})";


            StyleHelper.ConfigureGrid(gridHistory);

            LoadHistory();
        }

        private void LoadHistory()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
          
                string query = @"SELECT book_title, copy_inventory_number, lend_date, due_date, return_date, librarian_short
                                 FROM view_reader_history
                                 WHERE reader_ticket_number = @id
                                 ORDER BY return_date ASC NULLS FIRST, lend_date DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", _ticketNumber);

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridHistory.DataSource = dt;
                }
            }

            // Настройка колонок
            if (gridHistory.Columns["book_title"] != null)
                gridHistory.Columns["book_title"].HeaderText = "Книга";

            if (gridHistory.Columns["copy_inventory_number"] != null)
            {
                gridHistory.Columns["copy_inventory_number"].HeaderText = "Инв. №";
    
            }

            if (gridHistory.Columns["lend_date"] != null)
                gridHistory.Columns["lend_date"].HeaderText = "Дата выдачи";

            if (gridHistory.Columns["due_date"] != null)
                gridHistory.Columns["due_date"].HeaderText = "Срок возврата";

            if (gridHistory.Columns["return_date"] != null)
                gridHistory.Columns["return_date"].HeaderText = "Дата возврата";

            if (gridHistory.Columns["librarian_short"] != null)
                gridHistory.Columns["librarian_short"].HeaderText = "Сотрудник";
        }

        // Раскрашиваем строки: На руках (Зеленый/Красный) или Сдана (Серый)
        private void gridHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridHistory.Rows[e.RowIndex];

                // Проверяем дату возврата
                var returnDate = row.Cells["return_date"].Value;

                if (returnDate == DBNull.Value || returnDate == null)
                {
                    // Книга НА РУКАХ
                    // Проверяем просрочку
                    var dueDateObj = row.Cells["due_date"].Value;
                    if (dueDateObj != DBNull.Value && Convert.ToDateTime(dueDateObj) < DateTime.Now)
                    {
                        // Просрочена - Красный фон
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        // На руках, срок норм - Зеленоватый (или жирный шрифт)
                        row.DefaultCellStyle.BackColor = Color.Honeydew;
                        row.DefaultCellStyle.Font = new Font(gridHistory.Font, FontStyle.Bold);
                    }
                }
                else
                {
                    // Книга ВОЗВРАЩЕНА (Архив) - Серый текст
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
