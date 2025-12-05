namespace AIS_Library.Forms.Librarian
{
    partial class LibrarianMainForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            gridReaders = new DataGridView();
            panel2 = new Panel();
            btnEditReader = new Button();
            btnAddReader = new Button();
            txtSearchReader = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaders).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1212, 34);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 34);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1212, 602);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gridReaders);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1204, 569);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Читатели";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridReaders
            // 
            gridReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReaders.Dock = DockStyle.Fill;
            gridReaders.Location = new Point(3, 41);
            gridReaders.Name = "gridReaders";
            gridReaders.ReadOnly = true;
            gridReaders.RowHeadersVisible = false;
            gridReaders.RowHeadersWidth = 51;
            gridReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridReaders.Size = new Size(1198, 525);
            gridReaders.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEditReader);
            panel2.Controls.Add(btnAddReader);
            panel2.Controls.Add(txtSearchReader);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1198, 38);
            panel2.TabIndex = 0;
            // 
            // btnEditReader
            // 
            btnEditReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditReader.Location = new Point(1067, 4);
            btnEditReader.Name = "btnEditReader";
            btnEditReader.Size = new Size(128, 30);
            btnEditReader.TabIndex = 3;
            btnEditReader.Text = "Редактировать";
            btnEditReader.UseVisualStyleBackColor = true;
            btnEditReader.Click += btnEditReader_Click;
            // 
            // btnAddReader
            // 
            btnAddReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddReader.Location = new Point(936, 2);
            btnAddReader.Name = "btnAddReader";
            btnAddReader.Size = new Size(125, 32);
            btnAddReader.TabIndex = 2;
            btnAddReader.Text = "Регистрация";
            btnAddReader.UseVisualStyleBackColor = true;
            btnAddReader.Click += btnAddReader_Click;
            // 
            // txtSearchReader
            // 
            txtSearchReader.Location = new Point(67, 9);
            txtSearchReader.Name = "txtSearchReader";
            txtSearchReader.Size = new Size(216, 27);
            txtSearchReader.TabIndex = 1;
            txtSearchReader.TextChanged += txtSearchReader_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1204, 569);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // LibrarianMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 636);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "LibrarianMainForm";
            Text = "Кабинет библиотекаря";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReaders).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel2;
        private Button btnEditReader;
        private Button btnAddReader;
        private TextBox txtSearchReader;
        private Label label1;
        private TabPage tabPage2;
        private DataGridView gridReaders;
    }
}