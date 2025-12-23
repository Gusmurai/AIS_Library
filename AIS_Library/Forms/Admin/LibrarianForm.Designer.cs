namespace AIS_Library.Forms.Admin
{
    partial class LibrarianForm
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPhone = new TextBox();
            txtPatronymic = new TextBox();
            txtName = new TextBox();
            txtSurname = new TextBox();
            groupBox2 = new GroupBox();
            btnChangeLogin = new Button();
            btnChangePass = new Button();
            txtLogin = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtPassword = new TextBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtPatronymic);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtSurname);
            groupBox1.Font = new Font("Segoe UI", 10.2F);
            groupBox1.Location = new Point(33, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(353, 331);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Личные данные";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 269);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 7;
            label4.Text = "Телефон*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 200);
            label3.Name = "label3";
            label3.Size = new Size(83, 23);
            label3.TabIndex = 6;
            label3.Text = "Отчество";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 130);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 5;
            label2.Text = "Имя*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 63);
            label1.Name = "label1";
            label1.Size = new Size(88, 23);
            label1.TabIndex = 4;
            label1.Text = "Фамилия*";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(153, 266);
            txtPhone.MaxLength = 12;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(140, 30);
            txtPhone.TabIndex = 3;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(153, 200);
            txtPatronymic.MaxLength = 30;
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(140, 30);
            txtPatronymic.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(153, 130);
            txtName.MaxLength = 30;
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 30);
            txtName.TabIndex = 1;
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(153, 76);
            txtSurname.MaxLength = 30;
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(140, 30);
            txtSurname.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnChangeLogin);
            groupBox2.Controls.Add(btnChangePass);
            groupBox2.Controls.Add(txtLogin);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Font = new Font("Segoe UI", 10.2F);
            groupBox2.Location = new Point(432, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(440, 331);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Учётная запись";
            // 
            // btnChangeLogin
            // 
            btnChangeLogin.Location = new Point(266, 87);
            btnChangeLogin.Name = "btnChangeLogin";
            btnChangeLogin.Size = new Size(168, 33);
            btnChangeLogin.TabIndex = 12;
            btnChangeLogin.Text = "Сменить логин";
            btnChangeLogin.UseVisualStyleBackColor = true;
            btnChangeLogin.Click += btnChangeLogin_Click;
            // 
            // btnChangePass
            // 
            btnChangePass.Location = new Point(266, 200);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(155, 32);
            btnChangePass.TabIndex = 11;
            btnChangePass.Text = "Сменить пароль";
            btnChangePass.UseVisualStyleBackColor = true;
            btnChangePass.Click += btnChangePass_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(97, 87);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(140, 30);
            txtLogin.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 200);
            label6.Name = "label6";
            label6.Size = new Size(76, 23);
            label6.TabIndex = 9;
            label6.Text = "Пароль*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 87);
            label5.Name = "label5";
            label5.Size = new Size(65, 23);
            label5.TabIndex = 8;
            label5.Text = "Логин*";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(97, 197);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Скрыт";
            txtPassword.Size = new Size(140, 30);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Font = new Font("Segoe UI", 10.2F);
            chkIsActive.Location = new Point(33, 407);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(191, 27);
            chkIsActive.TabIndex = 2;
            chkIsActive.Text = "Сотрудник работает";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(758, 406);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 43);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(614, 406);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(123, 43);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // LibrarianForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 468);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsActive);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "LibrarianForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LibrarianForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtPhone;
        private TextBox txtPatronymic;
        private TextBox txtName;
        private TextBox txtSurname;
        private GroupBox groupBox2;
        private TextBox txtPassword;
        private CheckBox chkIsActive;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtLogin;
        private Button btnChangePass;
        private Button btnChangeLogin;
    }
}