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

namespace AIS_Library.Forms.Librarian
{
    public partial class CreateReservationForm : Form
    {
        public CreateReservationForm()
        {
            InitializeComponent();

            this.Text = "Новая бронь";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void btnFindReader_Click(object sender, EventArgs e)
        {
            using (var form = new ReaderSelectionForm(""))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Получаем результат выбора
                    txtTicket.Text = form.SelectedTicketNumber.ToString();
                    lblReaderName.Text = form.SelectedFullName;

                 
                }
            }

        }

        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            // Открываем форму выбора, которая у нас уже есть
            using (var form = new BookSelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                    lblBookTitle.Text = form.SelectedBookTitle;
                    lblIsbn.Text = form.SelectedBookIsbn;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTicket.Text) || string.IsNullOrEmpty(lblIsbn.Text))
            {
                MessageBox.Show("Выберите читателя и книгу!", "Внимание");
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("CALL sp_create_reservation(@isbn, @reader, @lib)", conn))
                    {
                        cmd.Parameters.AddWithValue("isbn", lblIsbn.Text);
                        cmd.Parameters.AddWithValue("reader", int.Parse(txtTicket.Text));
                        cmd.Parameters.AddWithValue("lib", UserInfo.LibrarianId);
                        cmd.ExecuteNonQuery();
                    }

                    string msg = "Книга успешно забронирована на 3 дня.\n\n" +
                                 "⚠️ НАПОМНИТЕ ЧИТАТЕЛЮ:\n" +
                                 "Выдача книги будет невозможна, если при посещении выяснится, что:\n" +
                                 "1. У него на руках 5 книг (лимит).\n" +
                                 "2. Есть неоплаченные штрафы.\n" +
                                 "3. Есть просроченные книги на руках.";

                    MessageBox.Show(msg, "Бронь создана", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                }
                catch (PostgresException ex)
                {
                    // Ошибки из процедуры (долги, лимит, нет свободных) придут сюда
                    MessageBox.Show(ex.MessageText, "Невозможно забронировать", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}