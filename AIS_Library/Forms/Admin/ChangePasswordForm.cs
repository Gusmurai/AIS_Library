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
    public partial class ChangePasswordForm : Form
    {
       
        public string NewPassword { get; private set; }

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pass = txtNewPass.Text.Trim();
            string confirm = txtConfirmPass.Text.Trim();

            // 1. Валидация
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }


            if (MessageBox.Show("Вы действительно хотите задать новый пароль?",
                "Подтверждение смены пароля", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None; 
                return;
            }

            NewPassword = pass;
        }
    }
}
