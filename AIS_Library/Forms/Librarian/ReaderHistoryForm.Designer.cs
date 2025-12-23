namespace AIS_Library.Forms.Librarian
{
    partial class ReaderHistoryForm
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
            lblReaderInfo = new Label();
            gridHistory = new DataGridView();
            panel2 = new Panel();
            btnClose = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblReaderInfo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 42);
            panel1.TabIndex = 0;
            // 
            // lblReaderInfo
            // 
            lblReaderInfo.AutoSize = true;
            lblReaderInfo.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            lblReaderInfo.Location = new Point(13, 9);
            lblReaderInfo.Margin = new Padding(4, 0, 4, 0);
            lblReaderInfo.Name = "lblReaderInfo";
            lblReaderInfo.Size = new Size(224, 20);
            lblReaderInfo.TabIndex = 0;
            lblReaderInfo.Text = "Формуляр читателя: ...";
            // 
            // gridHistory
            // 
            gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistory.Dock = DockStyle.Fill;
            gridHistory.Location = new Point(0, 42);
            gridHistory.Margin = new Padding(4, 3, 4, 3);
            gridHistory.Name = "gridHistory";
            gridHistory.RowHeadersWidth = 51;
            gridHistory.Size = new Size(1100, 408);
            gridHistory.TabIndex = 1;
            gridHistory.CellFormatting += gridHistory_CellFormatting;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClose);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 414);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1100, 36);
            panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClose.Location = new Point(975, 3);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 30);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ReaderHistoryForm
            // 
            AutoScaleDimensions = new SizeF(11F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 450);
            Controls.Add(panel2);
            Controls.Add(gridHistory);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReaderHistoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ReaderHistoryForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblReaderInfo;
        private DataGridView gridHistory;
        private Panel panel2;
        private Button btnClose;
    }
}