namespace AIS_Library.Forms.Admin
{
    partial class ChangePasswordForm
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
            txtNewPass = new TextBox();
            txtConfirmPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtNewPass
            // 
            txtNewPass.Location = new Point(200, 38);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(125, 27);
            txtNewPass.TabIndex = 0;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Location = new Point(200, 98);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(125, 27);
            txtConfirmPass.TabIndex = 1;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 38);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 2;
            label1.Text = "Новый пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 101);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 3;
            label2.Text = "Повторите пароль";
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(46, 163);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(113, 45);
            btnOk.TabIndex = 4;
            btnOk.Text = "Применить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 43);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 232);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Смена пароля сотрудника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewPass;
        private TextBox txtConfirmPass;
        private Label label1;
        private Label label2;
        private Button btnOk;
        private Button btnCancel;
    }
}