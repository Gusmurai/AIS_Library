namespace AIS_Library.Forms.Admin
{
    partial class GenreForm
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
            txtName = new TextBox();
            txtDesc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(108, 21);
            txtName.Name = "txtName";
            txtName.Size = new Size(287, 27);
            txtName.TabIndex = 0;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(108, 88);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(525, 338);
            txtDesc.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 2;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Описание";
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(494, 451);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(609, 451);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // GenreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 489);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDesc);
            Controls.Add(txtName);
            Name = "GenreForm";
            Text = "GenreForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtDesc;
        private Label label1;
        private Label label2;
        private Button btnSave;
        private Button btnCancel;
    }
}