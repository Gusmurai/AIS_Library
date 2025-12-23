namespace AIS_Library.Forms.Librarian
{
    partial class BookCopiesForm
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
            panel1 = new Panel();
            btnHistory = new Button();
            txtSearchInv = new TextBox();
            label1 = new Label();
            btnWriteOff = new Button();
            btnSupply = new Button();
            lblBookInfo = new Label();
            gridCopies = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCopies).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHistory);
            panel1.Controls.Add(txtSearchInv);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnWriteOff);
            panel1.Controls.Add(btnSupply);
            panel1.Controls.Add(lblBookInfo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1284, 44);
            panel1.TabIndex = 0;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Segoe UI", 10.2F);
            btnHistory.Location = new Point(840, 5);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(106, 33);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "Формуляр";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // txtSearchInv
            // 
            txtSearchInv.Location = new Point(654, 6);
            txtSearchInv.Name = "txtSearchInv";
            txtSearchInv.Size = new Size(140, 30);
            txtSearchInv.TabIndex = 4;
            txtSearchInv.TextChanged += txtSearchInv_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(540, 10);
            label1.Name = "label1";
            label1.Size = new Size(107, 23);
            label1.TabIndex = 3;
            label1.Text = "Поиск по №";
            // 
            // btnWriteOff
            // 
            btnWriteOff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWriteOff.Font = new Font("Segoe UI", 10.2F);
            btnWriteOff.Location = new Point(1158, 6);
            btnWriteOff.Name = "btnWriteOff";
            btnWriteOff.Size = new Size(123, 34);
            btnWriteOff.TabIndex = 2;
            btnWriteOff.Text = "Списать";
            btnWriteOff.UseVisualStyleBackColor = true;
            btnWriteOff.Click += btnWriteOff_Click;
            // 
            // btnSupply
            // 
            btnSupply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSupply.Font = new Font("Segoe UI", 10.2F);
            btnSupply.Location = new Point(953, 3);
            btnSupply.Name = "btnSupply";
            btnSupply.Size = new Size(198, 37);
            btnSupply.TabIndex = 1;
            btnSupply.Text = "Оформить поставку";
            btnSupply.UseVisualStyleBackColor = true;
            btnSupply.Click += btnSupply_Click;
            // 
            // lblBookInfo
            // 
            lblBookInfo.AutoSize = true;
            lblBookInfo.Font = new Font("Segoe UI", 10.2F);
            lblBookInfo.Location = new Point(14, 12);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(55, 23);
            lblBookInfo.TabIndex = 0;
            lblBookInfo.Text = "label1";
            // 
            // gridCopies
            // 
            gridCopies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCopies.Dock = DockStyle.Fill;
            gridCopies.Location = new Point(0, 44);
            gridCopies.Name = "gridCopies";
            gridCopies.RowHeadersWidth = 51;
            gridCopies.Size = new Size(1284, 501);
            gridCopies.TabIndex = 1;
            gridCopies.CellFormatting += gridCopies_CellFormatting;
            // 
            // BookCopiesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 545);
            Controls.Add(gridCopies);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "BookCopiesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BookCopiesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCopies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnWriteOff;
        private Button btnSupply;
        private Label lblBookInfo;
        private DataGridView gridCopies;
        private TextBox txtSearchInv;
        private Label label1;
        private Button btnHistory;
    }
}