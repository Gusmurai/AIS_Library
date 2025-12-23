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

    public partial class AnnulmentChoiceForm : Form
    {
        public bool ShouldRestoreBook { get; private set; } = false;
        public AnnulmentChoiceForm()
        {
            InitializeComponent();

            this.Text = "Выбор действия";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // По умолчанию - просто ошибка
            rbFound.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ShouldRestoreBook = rbFound.Checked;


        }
    }
}
