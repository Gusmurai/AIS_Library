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
    public partial class NoteForm : Form
    {
        // Свойство, чтобы забрать текст снаружи
        public string NoteText { get; private set; }

        public NoteForm(string currentText)
        {
            InitializeComponent();
            txtNote.Text = currentText;
            this.Text = "Редактирование заметки";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Спрашиваем подтверждение
            if (MessageBox.Show("Вы действительно хотите сохранить эту заметку?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Если нажали "Нет", запрещаем закрытие формы
                this.DialogResult = DialogResult.None;
                return;
            }

            // 2. Если "Да" — сохраняем текст в свойство
            NoteText = txtNote.Text.Trim();
        }
    }
}
