namespace AIS_Library.Forms.Admin
{
    partial class ChangeLoginForm
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
            btnOk = new Button();
            btnCancel = new Button();
            txtNewLogin = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(42, 157);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(124, 40);
            btnOk.TabIndex = 0;
            btnOk.Text = "Применить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 157);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtNewLogin
            // 
            txtNewLogin.Location = new Point(200, 67);
            txtNewLogin.Name = "txtNewLogin";
            txtNewLogin.Size = new Size(125, 27);
            txtNewLogin.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 67);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 3;
            label1.Text = "Новый логин";
            // 
            // ChangeLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 260);
            Controls.Add(label1);
            Controls.Add(txtNewLogin);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "ChangeLoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Смена логина сотрудника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private TextBox txtNewLogin;
        private Label label1;
    }
}