namespace AIS_Library.Forms.Admin
{
    partial class SupplierForm
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
            txtInn = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtInn
            // 
            txtInn.Location = new Point(102, 24);
            txtInn.Name = "txtInn";
            txtInn.Size = new Size(185, 27);
            txtInn.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(102, 71);
            txtName.Name = "txtName";
            txtName.Size = new Size(185, 27);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(102, 178);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(185, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(102, 123);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(185, 27);
            txtAddress.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(102, 233);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(185, 27);
            txtEmail.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(93, 297);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(193, 297);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 7;
            label1.Text = "ИНН";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 8;
            label2.Text = "Название";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 9;
            label3.Text = "Адрес";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 181);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 10;
            label4.Text = "Телефон";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 233);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 11;
            label5.Text = "Email";
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 333);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(txtInn);
            Name = "SupplierForm";
            Text = "SupplierForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInn;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}