namespace AIS_Library.Forms.Librarian
{
    partial class CopyHistoryForm
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
            lblInfo = new Label();
            panel2 = new Panel();
            btnClose = new Button();
            gridHistory = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblInfo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 44);
            panel1.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblInfo.Location = new Point(21, 11);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(59, 23);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClose);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 414);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 36);
            panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClose.Location = new Point(703, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // gridHistory
            // 
            gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistory.Dock = DockStyle.Fill;
            gridHistory.Location = new Point(0, 44);
            gridHistory.Name = "gridHistory";
            gridHistory.RowHeadersWidth = 51;
            gridHistory.Size = new Size(800, 370);
            gridHistory.TabIndex = 2;
            gridHistory.CellFormatting += gridHistory_CellFormatting;
            // 
            // CopyHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridHistory);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CopyHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CopyHistoryForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblInfo;
        private Panel panel2;
        private Button btnClose;
        private DataGridView gridHistory;
    }
}