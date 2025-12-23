namespace AIS_Library.Forms.General
{
    partial class ChangeAmountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCurrentAmount = new Label();
            nudNewAmount = new NumericUpDown();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)nudNewAmount).BeginInit();
            SuspendLayout();
            // 
            // lblCurrentAmount
            // 
            lblCurrentAmount.AutoSize = true;
            lblCurrentAmount.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblCurrentAmount.Location = new Point(24, 24);
            lblCurrentAmount.Name = "lblCurrentAmount";
            lblCurrentAmount.Size = new Size(136, 20);
            lblCurrentAmount.TabIndex = 0;
            lblCurrentAmount.Text = "Текущая сумма";
            // 
            // nudNewAmount
            // 
            nudNewAmount.DecimalPlaces = 2;
            nudNewAmount.Location = new Point(173, 71);
            nudNewAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudNewAmount.Name = "nudNewAmount";
            nudNewAmount.Size = new Size(150, 27);
            nudNewAmount.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F);
            label1.Location = new Point(24, 73);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 2;
            label1.Text = "Новая сумма";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10.2F);
            btnCancel.Location = new Point(190, 137);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Microsoft Sans Serif", 10.2F);
            btnSave.Location = new Point(290, 137);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChangeAmountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 181);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(nudNewAmount);
            Controls.Add(lblCurrentAmount);
            Name = "ChangeAmountForm";
            Text = "ChangeAmountForm";
            ((System.ComponentModel.ISupportInitialize)nudNewAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentAmount;
        private NumericUpDown nudNewAmount;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
    }
}