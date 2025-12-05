namespace AIS_Library.Forms.Admin
{
    partial class FineArticleForm
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
            nudAmount = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(123, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 27);
            txtName.TabIndex = 0;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(123, 95);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(364, 77);
            txtDesc.TabIndex = 1;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(123, 207);
            nudAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(150, 27);
            nudAmount.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(286, 289);
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
            btnCancel.Location = new Point(395, 289);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 5;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 98);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 6;
            label2.Text = "Описание";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 209);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 7;
            label3.Text = "Сумма";
            // 
            // FineArticleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 321);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(nudAmount);
            Controls.Add(txtDesc);
            Controls.Add(txtName);
            Name = "FineArticleForm";
            Text = "FineArticleForm";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtDesc;
        private NumericUpDown nudAmount;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}