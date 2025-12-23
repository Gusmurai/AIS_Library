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
    public partial class ReaderSelectionForm : Form
    {   
        public int SelectedTicketNumber { get; private set; }
        public string SelectedFullName { get; private set; }
        public ReaderSelectionForm(string initialSearch = "")
        {
            InitializeComponent();
            this.Text = "Выбор читателя";
            this.StartPosition = FormStartPosition.CenterParent;

            StyleHelper.ConfigureGrid(gridReaders);

            // Если передали текст (например, фамилию), сразу ищем
            txtSearch.Text = initialSearch;
            LoadReaders(initialSearch);
        }


        private void LoadReaders(string search)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
        
                string query = @"
                    SELECT 
                        ticket_number, 
                        surname, first_name, patronymic,
                        phone, 
                        date_of_birth
                    FROM readers 
                    WHERE is_active = TRUE
                      AND (
                          CONCAT_WS(' ', surname, first_name, patronymic) ILIKE @s
                          OR phone ILIKE @s
                          OR CAST(ticket_number AS TEXT) LIKE @s
                      )
                    ORDER BY surname
                    LIMIT 50"; 

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("s", $"%{search.Trim()}%");

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    gridReaders.DataSource = dt;
                }
            }

            // Настройка колонок
            if (gridReaders.Columns["ticket_number"] != null)
                gridReaders.Columns["ticket_number"].HeaderText = "№ Билета";

            if (gridReaders.Columns["surname"] != null)
                gridReaders.Columns["surname"].HeaderText = "Фамилия";

            if (gridReaders.Columns["first_name"] != null)
                gridReaders.Columns["first_name"].HeaderText = "Имя";

            if (gridReaders.Columns["patronymic"] != null)
                gridReaders.Columns["patronymic"].HeaderText = "Отчество";

            if (gridReaders.Columns["phone"] != null)
                gridReaders.Columns["phone"].HeaderText = "Телефон";

            if (gridReaders.Columns["date_of_birth"] != null)
                gridReaders.Columns["date_of_birth"].Visible = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ConfirmSelection();


        }

        private void ConfirmSelection()
        {
            if (gridReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите читателя из списка!", "Внимание");
                return;
            }

            var row = gridReaders.SelectedRows[0];
            SelectedTicketNumber = Convert.ToInt32(row.Cells["ticket_number"].Value);

            // Собираем полное имя красиво
            string s = row.Cells["surname"].Value.ToString();
            string n = row.Cells["first_name"].Value.ToString();
            string p = row.Cells["patronymic"].Value.ToString();
            SelectedFullName = $"{s} {n} {p}".Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReaders(txtSearch.Text);
        }

        private void gridReaders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmSelection();
        }
    }
}


