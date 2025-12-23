namespace AIS_Library.Forms.Librarian
{
    partial class ReaderForm
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
            txtSurname = new TextBox();
            txtName = new TextBox();
            txtPatronymic = new TextBox();
            txtPassportSeria = new TextBox();
            txtPassportNum = new TextBox();
            txtAddress = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtPhone = new TextBox();
            pbPhoto = new PictureBox();
            btnLoadPhoto = new Button();
            btnClearPhoto = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            dtpBirth = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(227, 28);
            txtSurname.MaxLength = 30;
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(267, 30);
            txtSurname.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(227, 79);
            txtName.MaxLength = 30;
            txtName.Name = "txtName";
            txtName.Size = new Size(267, 30);
            txtName.TabIndex = 1;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(227, 138);
            txtPatronymic.MaxLength = 30;
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(267, 30);
            txtPatronymic.TabIndex = 2;
            // 
            // txtPassportSeria
            // 
            txtPassportSeria.Location = new Point(227, 259);
            txtPassportSeria.MaxLength = 4;
            txtPassportSeria.Name = "txtPassportSeria";
            txtPassportSeria.Size = new Size(140, 30);
            txtPassportSeria.TabIndex = 4;
            // 
            // txtPassportNum
            // 
            txtPassportNum.Location = new Point(227, 320);
            txtPassportNum.MaxLength = 6;
            txtPassportNum.Name = "txtPassportNum";
            txtPassportNum.Size = new Size(140, 30);
            txtPassportNum.TabIndex = 5;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(227, 373);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(267, 50);
            txtAddress.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(62, 36);
            label1.Name = "label1";
            label1.Size = new Size(88, 23);
            label1.TabIndex = 7;
            label1.Text = "Фамилия*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(62, 87);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 8;
            label2.Text = "Имя*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(62, 146);
            label3.Name = "label3";
            label3.Size = new Size(83, 23);
            label3.TabIndex = 9;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(62, 205);
            label4.Name = "label4";
            label4.Size = new Size(139, 23);
            label4.TabIndex = 10;
            label4.Text = "Дата рождения*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(62, 267);
            label5.Name = "label5";
            label5.Size = new Size(144, 23);
            label5.TabIndex = 11;
            label5.Text = "Серия паспорта*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(62, 328);
            label6.Name = "label6";
            label6.Size = new Size(148, 23);
            label6.TabIndex = 12;
            label6.Text = "Номер паспорта*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(62, 400);
            label7.Name = "label7";
            label7.Size = new Size(64, 23);
            label7.TabIndex = 13;
            label7.Text = "Адрес*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(62, 460);
            label8.Name = "label8";
            label8.Size = new Size(85, 23);
            label8.TabIndex = 14;
            label8.Text = "Телефон*";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(227, 452);
            txtPhone.MaxLength = 12;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(140, 30);
            txtPhone.TabIndex = 15;
            // 
            // pbPhoto
            // 
            pbPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbPhoto.Location = new Point(611, 20);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(170, 235);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 16;
            pbPhoto.TabStop = false;
            // 
            // btnLoadPhoto
            // 
            btnLoadPhoto.Font = new Font("Segoe UI", 10.2F);
            btnLoadPhoto.Location = new Point(702, 267);
            btnLoadPhoto.Name = "btnLoadPhoto";
            btnLoadPhoto.Size = new Size(106, 33);
            btnLoadPhoto.TabIndex = 17;
            btnLoadPhoto.Text = "Загрузить";
            btnLoadPhoto.UseVisualStyleBackColor = true;
            btnLoadPhoto.Click += btnLoadPhoto_Click;
            // 
            // btnClearPhoto
            // 
            btnClearPhoto.Font = new Font("Segoe UI", 10.2F);
            btnClearPhoto.Location = new Point(573, 267);
            btnClearPhoto.Name = "btnClearPhoto";
            btnClearPhoto.Size = new Size(106, 33);
            btnClearPhoto.TabIndex = 18;
            btnClearPhoto.Text = "Удалить";
            btnClearPhoto.UseVisualStyleBackColor = true;
            btnClearPhoto.Click += btnClearPhoto_Click;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(702, 475);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 19;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(573, 475);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpBirth
            // 
            dtpBirth.CustomFormat = " ";
            dtpBirth.Format = DateTimePickerFormat.Short;
            dtpBirth.Location = new Point(225, 197);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(142, 30);
            dtpBirth.TabIndex = 21;
            dtpBirth.ValueChanged += dtpBirth_ValueChanged;
            // 
            // ReaderForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 522);
            Controls.Add(dtpBirth);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClearPhoto);
            Controls.Add(btnLoadPhoto);
            Controls.Add(pbPhoto);
            Controls.Add(txtPhone);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(txtPassportNum);
            Controls.Add(txtPassportSeria);
            Controls.Add(txtPatronymic);
            Controls.Add(txtName);
            Controls.Add(txtSurname);
            Font = new Font("Segoe UI", 10.2F);
            Name = "ReaderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ReaderForm";
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSurname;
        private TextBox txtName;
        private TextBox txtPatronymic;
        private TextBox txtPassportSeria;
        private TextBox txtPassportNum;
        private TextBox txtAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtPhone;
        private PictureBox pbPhoto;
        private Button btnLoadPhoto;
        private Button btnClearPhoto;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpBirth;
    }
}