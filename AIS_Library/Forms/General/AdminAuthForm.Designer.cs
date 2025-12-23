namespace AIS_Library.Forms.General
{
    partial class AdminAuthForm
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
            txtAdminLogin = new TextBox();
            txtAdminPassword = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(36, 52);
            label1.Name = "label1";
            label1.Size = new Size(197, 23);
            label1.TabIndex = 0;
            label1.Text = "Логин администратора:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(36, 114);
            label2.Name = "label2";
            label2.Size = new Size(208, 23);
            label2.TabIndex = 1;
            label2.Text = "Пароль администратора:";
            // 
            // txtAdminLogin
            // 
            txtAdminLogin.Location = new Point(250, 44);
            txtAdminLogin.Name = "txtAdminLogin";
            txtAdminLogin.Size = new Size(180, 30);
            txtAdminLogin.TabIndex = 2;
            // 
            // txtAdminPassword
            // 
            txtAdminPassword.Location = new Point(250, 114);
            txtAdminPassword.Name = "txtAdminPassword";
            txtAdminPassword.Size = new Size(180, 30);
            txtAdminPassword.TabIndex = 3;
            txtAdminPassword.UseSystemPasswordChar = true;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Font = new Font("Segoe UI", 10.2F);
            btnConfirm.Location = new Point(294, 185);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(136, 33);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Подтвердить";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(181, 185);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AdminAuthForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 253);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtAdminPassword);
            Controls.Add(txtAdminLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "AdminAuthForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AdminAuthForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtAdminLogin;
        private TextBox txtAdminPassword;
        private Button btnConfirm;
        private Button btnCancel;
    }
}