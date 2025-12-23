using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_Library.Forms.General
{
    public partial class ChangeAmountForm : Form
    {
        public decimal NewAmount { get; private set; }
        public ChangeAmountForm(decimal currentAmount)
        {
            InitializeComponent();

            this.Text = "Изменение суммы штрафа";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            lblCurrentAmount.Text = $"{currentAmount:C2}";
            nudNewAmount.Value = currentAmount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewAmount = nudNewAmount.Value;
        }
    }
}
