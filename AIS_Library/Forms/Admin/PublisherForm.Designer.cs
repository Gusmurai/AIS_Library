namespace AIS_Library.Forms.Admin
{
    partial class PublisherForm
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
            txtName = new TextBox();
            txtCity = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 1;
            label2.Text = "Город";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(168, 27);
            txtName.TabIndex = 2;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(120, 87);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(168, 27);
            txtCity.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(138, 165);
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
            btnCancel.Location = new Point(238, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // PublisherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 206);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PublisherForm";
            Text = "PublisherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtCity;
        private Button btnSave;
        private Button btnCancel;
    }
}