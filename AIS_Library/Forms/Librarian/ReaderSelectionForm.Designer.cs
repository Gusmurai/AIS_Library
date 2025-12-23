namespace AIS_Library.Forms.Librarian
{
    partial class ReaderSelectionForm
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
            txtSearch = new TextBox();
            label1 = new Label();
            gridReaders = new DataGridView();
            panel2 = new Panel();
            btnSelect = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaders).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
            panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(70, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(168, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // gridReaders
            // 
            gridReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReaders.Dock = DockStyle.Fill;
            gridReaders.Location = new Point(0, 35);
            gridReaders.Name = "gridReaders";
            gridReaders.RowHeadersWidth = 51;
            gridReaders.Size = new Size(800, 415);
            gridReaders.TabIndex = 1;
            gridReaders.CellDoubleClick += gridReaders_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSelect);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 418);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 32);
            panel2.TabIndex = 2;
            // 
            // btnSelect
            // 
            btnSelect.DialogResult = DialogResult.OK;
            btnSelect.Location = new Point(703, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // ReaderSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(gridReaders);
            Controls.Add(panel1);
            Name = "ReaderSelectionForm";
            Text = "ReaderSelectionForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaders).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView gridReaders;
        private TextBox txtSearch;
        private Panel panel2;
        private Button btnSelect;
    }
}