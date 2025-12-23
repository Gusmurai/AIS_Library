namespace AIS_Library.Forms.Librarian
{
    partial class FineForm
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
            cboArticles = new ComboBox();
            label2 = new Label();
            nudAmount = new NumericUpDown();
            chkIsPaid = new CheckBox();
            btnSave = new Button();
            label3 = new Label();
            txtComment = new TextBox();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(14, 22);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 0;
            label1.Text = "Статья штрафа";
            // 
            // cboArticles
            // 
            cboArticles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboArticles.FormattingEnabled = true;
            cboArticles.Location = new Point(156, 18);
            cboArticles.Name = "cboArticles";
            cboArticles.Size = new Size(169, 31);
            cboArticles.TabIndex = 1;
            cboArticles.SelectedIndexChanged += cboArticles_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(14, 77);
            label2.Name = "label2";
            label2.Size = new Size(134, 23);
            label2.TabIndex = 2;
            label2.Text = "Сумма к оплате";
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(158, 74);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(169, 30);
            nudAmount.TabIndex = 3;
            // 
            // chkIsPaid
            // 
            chkIsPaid.AutoSize = true;
            chkIsPaid.Font = new Font("Segoe UI", 10.2F);
            chkIsPaid.Location = new Point(353, 77);
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.Size = new Size(160, 27);
            chkIsPaid.TabIndex = 4;
            chkIsPaid.Text = "Оплачено сразу";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(425, 263);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "Оформить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(14, 140);
            label3.Name = "label3";
            label3.Size = new Size(73, 23);
            label3.TabIndex = 6;
            label3.Text = "Заметка";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(151, 145);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Size = new Size(368, 98);
            txtComment.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(299, 263);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FineForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 310);
            Controls.Add(btnCancel);
            Controls.Add(txtComment);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(chkIsPaid);
            Controls.Add(nudAmount);
            Controls.Add(label2);
            Controls.Add(cboArticles);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "FineForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FineForm";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboArticles;
        private Label label2;
        private NumericUpDown nudAmount;
        private CheckBox chkIsPaid;
        private Button btnSave;
        private Label label3;
        private TextBox txtComment;
        private Button btnCancel;
    }
}