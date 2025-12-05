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
            txtSurname.Location = new Point(202, 24);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(125, 27);
            txtSurname.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(202, 69);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(202, 120);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(125, 27);
            txtPatronymic.TabIndex = 2;
            // 
            // txtPassportSeria
            // 
            txtPassportSeria.Location = new Point(202, 225);
            txtPassportSeria.MaxLength = 4;
            txtPassportSeria.Name = "txtPassportSeria";
            txtPassportSeria.Size = new Size(125, 27);
            txtPassportSeria.TabIndex = 4;
            // 
            // txtPassportNum
            // 
            txtPassportNum.Location = new Point(202, 278);
            txtPassportNum.MaxLength = 6;
            txtPassportNum.Name = "txtPassportNum";
            txtPassportNum.Size = new Size(125, 27);
            txtPassportNum.TabIndex = 5;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(202, 324);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 24);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 7;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 76);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 8;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 123);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 9;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 175);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 10;
            label4.Text = "Дата рождения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 225);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 11;
            label5.Text = "Серия паспорта";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 278);
            label6.Name = "label6";
            label6.Size = new Size(126, 20);
            label6.TabIndex = 12;
            label6.Text = "Номер паспорта";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(55, 331);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 13;
            label7.Text = "Адрес";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(55, 381);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 14;
            label8.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(202, 374);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 15;
            // 
            // pbPhoto
            // 
            pbPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbPhoto.Location = new Point(442, 24);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(267, 268);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 16;
            pbPhoto.TabStop = false;
            // 
            // btnLoadPhoto
            // 
            btnLoadPhoto.Location = new Point(442, 313);
            btnLoadPhoto.Name = "btnLoadPhoto";
            btnLoadPhoto.Size = new Size(94, 29);
            btnLoadPhoto.TabIndex = 17;
            btnLoadPhoto.Text = "Загрузить";
            btnLoadPhoto.UseVisualStyleBackColor = true;
            btnLoadPhoto.Click += btnLoadPhoto_Click;
            // 
            // btnClearPhoto
            // 
            btnClearPhoto.Location = new Point(615, 313);
            btnClearPhoto.Name = "btnClearPhoto";
            btnClearPhoto.Size = new Size(94, 29);
            btnClearPhoto.TabIndex = 18;
            btnClearPhoto.Text = "Удалить";
            btnClearPhoto.UseVisualStyleBackColor = true;
            btnClearPhoto.Click += btnClearPhoto_Click;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(551, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 19;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(694, 409);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpBirth
            // 
            dtpBirth.Format = DateTimePickerFormat.Short;
            dtpBirth.Location = new Point(200, 171);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(127, 27);
            dtpBirth.TabIndex = 21;
            // 
            // ReaderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "ReaderForm";
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