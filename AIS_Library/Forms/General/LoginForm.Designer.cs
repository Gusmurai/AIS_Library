namespace AIS_Library.Forms.General
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(139, 88);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(139, 156);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // txtLogin
            // 
            txtLogin.Anchor = AnchorStyles.None;
            txtLogin.Location = new Point(246, 88);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(138, 27);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Location = new Point(246, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(138, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.Location = new Point(114, 278);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(147, 46);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.Location = new Point(316, 278);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(138, 46);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 347);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АИС \"Библиотека\": Авторизация";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
    }
}
