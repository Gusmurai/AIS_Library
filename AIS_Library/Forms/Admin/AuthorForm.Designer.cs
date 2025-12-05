namespace AIS_Library.Forms.Admin
{
    partial class AuthorForm
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
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpBirth = new DateTimePicker();
            SuspendLayout();
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(168, 24);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(165, 27);
            txtSurname.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(168, 80);
            txtName.Name = "txtName";
            txtName.Size = new Size(165, 27);
            txtName.TabIndex = 1;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(168, 141);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(165, 27);
            txtPatronymic.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(159, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(259, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 5;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 6;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 148);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 7;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 214);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 8;
            label4.Text = "Дата рождения";
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(168, 207);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(165, 27);
            dtpBirth.TabIndex = 9;
            // 
            // AuthorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 313);
            Controls.Add(dtpBirth);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPatronymic);
            Controls.Add(txtName);
            Controls.Add(txtSurname);
            Name = "AuthorForm";
            Text = "AuthorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSurname;
        private TextBox txtName;
        private TextBox txtPatronymic;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpBirth;
    }
}