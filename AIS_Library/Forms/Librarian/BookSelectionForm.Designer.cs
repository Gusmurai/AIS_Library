namespace AIS_Library.Forms.Librarian
{
    partial class BookSelectionForm
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
            txtSearchCopy = new TextBox();
            label8 = new Label();
            txtSearch = new TextBox();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            gridBooks = new DataGridView();
            label2 = new Label();
            lblCodes = new Label();
            lblISBN = new Label();
            lblPubInfo = new Label();
            lblAuthors = new Label();
            lblTitle = new Label();
            pbBookCover = new PictureBox();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSelect = new Button();
            gridCopies = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBookCover).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCopies).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearchCopy);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1425, 36);
            panel1.TabIndex = 0;
            // 
            // txtSearchCopy
            // 
            txtSearchCopy.Anchor = AnchorStyles.Top;
            txtSearchCopy.Location = new Point(839, 3);
            txtSearchCopy.Margin = new Padding(4, 3, 4, 3);
            txtSearchCopy.Name = "txtSearchCopy";
            txtSearchCopy.Size = new Size(222, 27);
            txtSearchCopy.TabIndex = 3;
            txtSearchCopy.TextChanged += txtSearchCopy_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(712, 9);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 2;
            label8.Text = "Поиск по №";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(91, 6);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(229, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 36);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(gridCopies);
            splitContainer1.Size = new Size(1425, 464);
            splitContainer1.SplitterDistance = 707;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(gridBooks);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(label2);
            splitContainer2.Panel2.Controls.Add(lblCodes);
            splitContainer2.Panel2.Controls.Add(lblISBN);
            splitContainer2.Panel2.Controls.Add(lblPubInfo);
            splitContainer2.Panel2.Controls.Add(lblAuthors);
            splitContainer2.Panel2.Controls.Add(lblTitle);
            splitContainer2.Panel2.Controls.Add(pbBookCover);
            splitContainer2.Panel2.Font = new Font("Microsoft Sans Serif", 10.2F);
            splitContainer2.Size = new Size(707, 464);
            splitContainer2.SplitterDistance = 154;
            splitContainer2.TabIndex = 1;
            // 
            // gridBooks
            // 
            gridBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBooks.Dock = DockStyle.Fill;
            gridBooks.Location = new Point(0, 0);
            gridBooks.Margin = new Padding(4, 3, 4, 3);
            gridBooks.Name = "gridBooks";
            gridBooks.RowHeadersWidth = 51;
            gridBooks.Size = new Size(707, 154);
            gridBooks.TabIndex = 0;
            gridBooks.CellClick += gridBooks_CellClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(199, 9);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(288, 23);
            label2.TabIndex = 7;
            label2.Text = "Информация о выбранной книге";
            // 
            // lblCodes
            // 
            lblCodes.AutoSize = true;
            lblCodes.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblCodes.Location = new Point(249, 250);
            lblCodes.Margin = new Padding(4, 0, 4, 0);
            lblCodes.Name = "lblCodes";
            lblCodes.Size = new Size(186, 20);
            lblCodes.TabIndex = 6;
            lblCodes.Text = "ББК, Авторский знак";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblISBN.Location = new Point(249, 203);
            lblISBN.Margin = new Padding(4, 0, 4, 0);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(48, 20);
            lblISBN.TabIndex = 4;
            lblISBN.Text = "ISBN";
            // 
            // lblPubInfo
            // 
            lblPubInfo.AutoSize = true;
            lblPubInfo.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblPubInfo.Location = new Point(249, 162);
            lblPubInfo.Margin = new Padding(4, 0, 4, 0);
            lblPubInfo.Name = "lblPubInfo";
            lblPubInfo.Size = new Size(159, 20);
            lblPubInfo.TabIndex = 3;
            lblPubInfo.Text = "Доп. информация";
            // 
            // lblAuthors
            // 
            lblAuthors.AutoSize = true;
            lblAuthors.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblAuthors.Location = new Point(249, 117);
            lblAuthors.Margin = new Padding(4, 0, 4, 0);
            lblAuthors.Name = "lblAuthors";
            lblAuthors.Size = new Size(61, 20);
            lblAuthors.TabIndex = 2;
            lblAuthors.Text = "Автор";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10.2F);
            lblTitle.Location = new Point(249, 79);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(91, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Название";
            // 
            // pbBookCover
            // 
            pbBookCover.BorderStyle = BorderStyle.FixedSingle;
            pbBookCover.Location = new Point(29, 54);
            pbBookCover.Margin = new Padding(4, 3, 4, 3);
            pbBookCover.Name = "pbBookCover";
            pbBookCover.Size = new Size(161, 226);
            pbBookCover.SizeMode = PictureBoxSizeMode.Zoom;
            pbBookCover.TabIndex = 0;
            pbBookCover.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSelect);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 426);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(713, 38);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(456, 6);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelect.DialogResult = DialogResult.OK;
            btnSelect.Location = new Point(581, 6);
            btnSelect.Margin = new Padding(4, 3, 4, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(118, 29);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // gridCopies
            // 
            gridCopies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCopies.Dock = DockStyle.Fill;
            gridCopies.Location = new Point(0, 0);
            gridCopies.Margin = new Padding(4, 3, 4, 3);
            gridCopies.Name = "gridCopies";
            gridCopies.RowHeadersWidth = 51;
            gridCopies.Size = new Size(713, 464);
            gridCopies.TabIndex = 0;
            gridCopies.CellDoubleClick += gridCopies_CellDoubleClick;
            // 
            // BookSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1425, 500);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 10.2F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "BookSelectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BookSelectionForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBookCover).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCopies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSearch;
        private Label label1;
        private SplitContainer splitContainer1;
        private DataGridView gridBooks;
        private Panel panel2;
        private Button btnCancel;
        private Button btnSelect;
        private DataGridView gridCopies;
        private SplitContainer splitContainer2;
        private PictureBox pbBookCover;
        private Label lblCodes;
        private Label lblISBN;
        private Label lblPubInfo;
        private Label lblAuthors;
        private Label lblTitle;
        private Label label2;
        private TextBox txtSearchCopy;
        private Label label8;
    }
}