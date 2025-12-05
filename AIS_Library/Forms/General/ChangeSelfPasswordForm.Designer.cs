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
            label1.Location = new Point(107, 94);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Старый пароль";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(107, 160);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 1;
            label2.Text = "Новый пароль";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(107, 237);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 2;
            label3.Text = "Подтвердите";
            // 
            // txtOldPass
            // 
            txtOldPass.Anchor = AnchorStyles.None;
            txtOldPass.Location = new Point(323, 98);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.Size = new Size(125, 27);
            txtOldPass.TabIndex = 3;
            txtOldPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            txtNewPass.Anchor = AnchorStyles.None;
            txtNewPass.Location = new Point(323, 172);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(125, 27);
            txtNewPass.TabIndex = 4;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Anchor = AnchorStyles.None;
            txtConfirmPass.Location = new Point(323, 237);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(125, 27);
            txtConfirmPass.TabIndex = 5;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(256, 323);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(409, 323);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ChangeSelfPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtOldPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ChangeSelfPasswordForm";
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