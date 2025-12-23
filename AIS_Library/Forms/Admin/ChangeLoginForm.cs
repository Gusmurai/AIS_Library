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
    public partial class ChangeLoginForm : Form
    {
        public string NewLogin { get; private set; }

        public ChangeLoginForm(string currentLogin)
        {
            InitializeComponent();
            // Предзаполняем текущим логином для удобства
            txtNewLogin.Text = currentLogin;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string login = txtNewLogin.Text.Trim();

            // 1. Проверка на пустоту
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Логин не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; 
                return;
            }

            // 2. Вопрос пользователю (То, что ты просила)
            if (MessageBox.Show($"Вы действительно хотите изменить логин на '{login}'?",
                "Подтверждение смены логина", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None; 
                return;
            }

            NewLogin = login;
          
        }
    }
}
