namespace AIS_Library.Forms.Librarian
{
    partial class CreateReservationForm
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnFindReader = new Button();
            lblReaderName = new Label();
            txtTicket = new TextBox();
            groupBox2 = new GroupBox();
            lblIsbn = new Label();
            lblBookTitle = new Label();
            btnSelectBook = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnFindReader);
            groupBox1.Controls.Add(lblReaderName);
            groupBox1.Controls.Add(txtTicket);
            groupBox1.Font = new Font("Segoe UI", 10.2F);
            groupBox1.Location = new Point(14, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(324, 169);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Читатель";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 41);
            label1.Name = "label1";
            label1.Size = new Size(55, 23);
            label1.TabIndex = 3;
            label1.Text = "№ ЧБ";
            // 
            // btnFindReader
            // 
            btnFindReader.Location = new Point(166, 37);
            btnFindReader.Name = "btnFindReader";
            btnFindReader.Size = new Size(106, 33);
            btnFindReader.TabIndex = 2;
            btnFindReader.Text = "Найти";
            btnFindReader.UseVisualStyleBackColor = true;
            btnFindReader.Click += btnFindReader_Click;
            // 
            // lblReaderName
            // 
            lblReaderName.AutoSize = true;
            lblReaderName.Location = new Point(18, 92);
            lblReaderName.Name = "lblReaderName";
            lblReaderName.Size = new Size(48, 23);
            lblReaderName.TabIndex = 1;
            lblReaderName.Text = "ФИО";
            // 
            // txtTicket
            // 
            txtTicket.Location = new Point(75, 38);
            txtTicket.Name = "txtTicket";
            txtTicket.ReadOnly = true;
            txtTicket.Size = new Size(84, 30);
            txtTicket.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblIsbn);
            groupBox2.Controls.Add(lblBookTitle);
            groupBox2.Controls.Add(btnSelectBook);
            groupBox2.Font = new Font("Segoe UI", 10.2F);
            groupBox2.Location = new Point(359, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(395, 169);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Книга";
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(21, 129);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(47, 23);
            lblIsbn.TabIndex = 2;
            lblIsbn.Text = "ISBN";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(21, 92);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(86, 23);
            lblBookTitle.TabIndex = 1;
            lblBookTitle.Text = "Название";
            // 
            // btnSelectBook
            // 
            btnSelectBook.Location = new Point(21, 38);
            btnSelectBook.Name = "btnSelectBook";
            btnSelectBook.Size = new Size(198, 31);
            btnSelectBook.TabIndex = 0;
            btnSelectBook.Text = "Выбрать из каталога";
            btnSelectBook.UseVisualStyleBackColor = true;
            btnSelectBook.Click += btnSelectBook_Click;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(585, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(169, 33);
            btnSave.TabIndex = 2;
            btnSave.Text = "Оформить бронь";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(472, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CreateReservationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 239);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "CreateReservationForm";
            Text = "CreateReservationForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnFindReader;
        private Label lblReaderName;
        private TextBox txtTicket;
        private Label lblIsbn;
        private Label lblBookTitle;
        private Button btnSelectBook;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
    }
}