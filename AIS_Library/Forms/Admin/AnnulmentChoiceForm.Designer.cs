namespace AIS_Library.Forms.Admin
{
    partial class AnnulmentChoiceForm
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
            rbFound = new RadioButton();
            rbReplace = new RadioButton();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(292, 23);
            label1.TabIndex = 0;
            label1.Text = "Выберите причину аннулирования:";
            // 
            // rbFound
            // 
            rbFound.AutoSize = true;
            rbFound.Font = new Font("Segoe UI", 10.2F);
            rbFound.Location = new Point(33, 68);
            rbFound.Name = "rbFound";
            rbFound.Size = new Size(416, 27);
            rbFound.TabIndex = 1;
            rbFound.TabStop = true;
            rbFound.Text = "Читатель нашел книгу (Восстановить экземпляр)";
            rbFound.UseVisualStyleBackColor = true;
            // 
            // rbReplace
            // 
            rbReplace.AutoSize = true;
            rbReplace.Font = new Font("Segoe UI", 10.2F);
            rbReplace.Location = new Point(33, 115);
            rbReplace.Name = "rbReplace";
            rbReplace.Size = new Size(491, 27);
            rbReplace.TabIndex = 2;
            rbReplace.TabStop = true;
            rbReplace.Text = "Читатель принес замену (Экземпляр остается списанным)";
            rbReplace.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Font = new Font("Segoe UI", 10.2F);
            btnOk.Location = new Point(470, 166);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(119, 36);
            btnOk.TabIndex = 4;
            btnOk.Text = "Выполнить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(345, 166);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AnnulmentChoiceForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 222);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(rbReplace);
            Controls.Add(rbFound);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "AnnulmentChoiceForm";
            Text = "AnnulmentChoiceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbFound;
        private RadioButton rbReplace;
        private Button btnOk;
        private Button btnCancel;
    }
}