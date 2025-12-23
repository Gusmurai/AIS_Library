namespace AIS_Library.Forms.Librarian
{
    partial class SupplyForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbSupplier = new ComboBox();
            nudPrice = new NumericUpDown();
            nudCount = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            chkNoSupplier = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(97, 23);
            label1.TabIndex = 0;
            label1.Text = "Поставщик";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(26, 99);
            label2.Name = "label2";
            label2.Size = new Size(146, 23);
            label2.TabIndex = 1;
            label2.Text = "Стоимость за шт.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(26, 162);
            label3.Name = "label3";
            label3.Size = new Size(102, 23);
            label3.TabIndex = 2;
            label3.Text = "Количество";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(190, 17);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(169, 31);
            cmbSupplier.TabIndex = 3;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new Point(190, 99);
            nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(169, 30);
            nudPrice.TabIndex = 4;
            // 
            // nudCount
            // 
            nudCount.Location = new Point(190, 162);
            nudCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCount.Name = "nudCount";
            nudCount.Size = new Size(169, 30);
            nudCount.TabIndex = 5;
            nudCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(266, 237);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 6;
            btnSave.Text = "Принять";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(141, 237);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkNoSupplier
            // 
            chkNoSupplier.AutoSize = true;
            chkNoSupplier.Font = new Font("Segoe UI", 10.2F);
            chkNoSupplier.Location = new Point(190, 56);
            chkNoSupplier.Name = "chkNoSupplier";
            chkNoSupplier.Size = new Size(158, 27);
            chkNoSupplier.TabIndex = 8;
            chkNoSupplier.Text = "Без поставщика";
            chkNoSupplier.UseVisualStyleBackColor = true;
            chkNoSupplier.CheckedChanged += chkNoSupplier_CheckedChanged;
            // 
            // SupplyForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 279);
            Controls.Add(chkNoSupplier);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(nudCount);
            Controls.Add(nudPrice);
            Controls.Add(cmbSupplier);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SupplyForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SupplyForm";
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbSupplier;
        private NumericUpDown nudPrice;
        private NumericUpDown nudCount;
        private Button btnSave;
        private Button btnCancel;
        private CheckBox chkNoSupplier;
    }
}