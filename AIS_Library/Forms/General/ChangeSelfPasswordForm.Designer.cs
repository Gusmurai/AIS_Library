namespace AIS_Library.Forms.General
{
    partial class ChangeSelfPasswordForm
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
            txtOldPass = new TextBox();
            txtNewPass = new TextBox();
            txtConfirmPass = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(43, 30);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 0;
            label1.Text = "Старый пароль";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(43, 92);
            label2.Name = "label2";
            label2.Size = new Size(125, 23);
            label2.TabIndex = 1;
            label2.Text = "Новый пароль";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(47, 150);
            label3.Name = "label3";
            label3.Size = new Size(111, 23);
            label3.TabIndex = 2;
            label3.Text = "Подтвердите";
            // 
            // txtOldPass
            // 
            txtOldPass.Anchor = AnchorStyles.None;
            txtOldPass.Location = new Point(207, 26);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.Size = new Size(191, 30);
            txtOldPass.TabIndex = 3;
            txtOldPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            txtNewPass.Anchor = AnchorStyles.None;
            txtNewPass.Location = new Point(207, 84);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(191, 30);
            txtNewPass.TabIndex = 4;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Anchor = AnchorStyles.None;
            txtConfirmPass.Location = new Point(207, 150);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(191, 30);
            txtConfirmPass.TabIndex = 5;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(292, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(168, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ChangeSelfPasswordForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 273);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtOldPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "ChangeSelfPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtOldPass;
        private TextBox txtNewPass;
        private TextBox txtConfirmPass;
        private Button btnSave;
        private Button btnCancel;
    }
}