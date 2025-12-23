
namespace AIS_Library.Forms.Librarian
{
    partial class BookForm
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
            pbCover = new PictureBox();
            btnLoadCover = new Button();
            btnClearCover = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtIsbn = new TextBox();
            txtTitle = new TextBox();
            cmbPublisher = new ComboBox();
            nudYear = new NumericUpDown();
            nudPages = new NumericUpDown();
            txtBbk = new TextBox();
            txtAuthorMark = new TextBox();
            clbAuthors = new CheckedListBox();
            clbGenres = new CheckedListBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtSearchAuthor = new TextBox();
            txtSearchGenre = new TextBox();
            chkNoYear = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPages).BeginInit();
            SuspendLayout();
            // 
            // pbCover
            // 
            pbCover.BorderStyle = BorderStyle.FixedSingle;
            pbCover.Location = new Point(34, 12);
            pbCover.Name = "pbCover";
            pbCover.Size = new Size(150, 220);
            pbCover.SizeMode = PictureBoxSizeMode.Zoom;
            pbCover.TabIndex = 0;
            pbCover.TabStop = false;
            // 
            // btnLoadCover
            // 
            btnLoadCover.Font = new Font("Segoe UI", 10.2F);
            btnLoadCover.Location = new Point(112, 256);
            btnLoadCover.Name = "btnLoadCover";
            btnLoadCover.Size = new Size(109, 30);
            btnLoadCover.TabIndex = 1;
            btnLoadCover.Text = "Загрузить";
            btnLoadCover.UseVisualStyleBackColor = true;
            btnLoadCover.Click += btnLoadCover_Click;
            // 
            // btnClearCover
            // 
            btnClearCover.Font = new Font("Segoe UI", 10.2F);
            btnClearCover.Location = new Point(12, 256);
            btnClearCover.Name = "btnClearCover";
            btnClearCover.Size = new Size(94, 29);
            btnClearCover.TabIndex = 2;
            btnClearCover.Text = "Удалить";
            btnClearCover.UseVisualStyleBackColor = true;
            btnClearCover.Click += btnClearCover_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(227, 12);
            label1.Name = "label1";
            label1.Size = new Size(54, 23);
            label1.TabIndex = 3;
            label1.Text = "ISBN*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(227, 62);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 4;
            label2.Text = "Название*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(227, 109);
            label3.Name = "label3";
            label3.Size = new Size(117, 23);
            label3.TabIndex = 5;
            label3.Text = "Издательство";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(227, 154);
            label4.Name = "label4";
            label4.Size = new Size(107, 23);
            label4.TabIndex = 6;
            label4.Text = "Год издания";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(227, 200);
            label5.Name = "label5";
            label5.Size = new Size(141, 23);
            label5.TabIndex = 7;
            label5.Text = "Кол-во страниц*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(227, 264);
            label6.Name = "label6";
            label6.Size = new Size(47, 23);
            label6.TabIndex = 8;
            label6.Text = "ББК*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(227, 311);
            label7.Name = "label7";
            label7.Size = new Size(140, 23);
            label7.TabIndex = 9;
            label7.Text = "Авторский знак*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(624, 170);
            label8.Name = "label8";
            label8.Size = new Size(61, 23);
            label8.TabIndex = 10;
            label8.Text = "Жанр*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(621, 12);
            label9.Name = "label9";
            label9.Size = new Size(57, 23);
            label9.TabIndex = 11;
            label9.Text = "Автор";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(373, 12);
            txtIsbn.MaxLength = 13;
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(214, 27);
            txtIsbn.TabIndex = 12;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(373, 62);
            txtTitle.MaxLength = 50;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(214, 27);
            txtTitle.TabIndex = 13;
            // 
            // cmbPublisher
            // 
            cmbPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPublisher.FormattingEnabled = true;
            cmbPublisher.Location = new Point(373, 109);
            cmbPublisher.Name = "cmbPublisher";
            cmbPublisher.Size = new Size(212, 28);
            cmbPublisher.TabIndex = 14;
            // 
            // nudYear
            // 
            nudYear.Location = new Point(373, 155);
            nudYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(95, 27);
            nudYear.TabIndex = 15;
            // 
            // nudPages
            // 
            nudPages.Location = new Point(373, 205);
            nudPages.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPages.Name = "nudPages";
            nudPages.Size = new Size(99, 27);
            nudPages.TabIndex = 16;
            // 
            // txtBbk
            // 
            txtBbk.Location = new Point(373, 263);
            txtBbk.MaxLength = 50;
            txtBbk.Name = "txtBbk";
            txtBbk.Size = new Size(125, 27);
            txtBbk.TabIndex = 17;
            // 
            // txtAuthorMark
            // 
            txtAuthorMark.Location = new Point(373, 307);
            txtAuthorMark.MaxLength = 50;
            txtAuthorMark.Name = "txtAuthorMark";
            txtAuthorMark.Size = new Size(125, 27);
            txtAuthorMark.TabIndex = 18;
            // 
            // clbAuthors
            // 
            clbAuthors.CheckOnClick = true;
            clbAuthors.FormattingEnabled = true;
            clbAuthors.Location = new Point(621, 45);
            clbAuthors.Name = "clbAuthors";
            clbAuthors.Size = new Size(291, 114);
            clbAuthors.TabIndex = 19;
            clbAuthors.ItemCheck += clbAuthors_ItemCheck;
            // 
            // clbGenres
            // 
            clbGenres.CheckOnClick = true;
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(624, 200);
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(288, 158);
            clbGenres.TabIndex = 20;
            clbGenres.ItemCheck += clbGenres_ItemCheck;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F);
            btnSave.Location = new Point(818, 378);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 29);
            btnSave.TabIndex = 21;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F);
            btnCancel.Location = new Point(718, 378);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSearchAuthor
            // 
            txtSearchAuthor.Location = new Point(678, 12);
            txtSearchAuthor.Name = "txtSearchAuthor";
            txtSearchAuthor.PlaceholderText = "Поиск автора...";
            txtSearchAuthor.Size = new Size(234, 27);
            txtSearchAuthor.TabIndex = 23;
            txtSearchAuthor.TextChanged += txtSearchAuthor_TextChanged;
            // 
            // txtSearchGenre
            // 
            txtSearchGenre.Location = new Point(689, 167);
            txtSearchGenre.Name = "txtSearchGenre";
            txtSearchGenre.PlaceholderText = "Поиск жанра...";
            txtSearchGenre.Size = new Size(223, 27);
            txtSearchGenre.TabIndex = 24;
            txtSearchGenre.TextChanged += txtSearchGenre_TextChanged;
            // 
            // chkNoYear
            // 
            chkNoYear.AutoSize = true;
            chkNoYear.Font = new Font("Segoe UI", 10.2F);
            chkNoYear.Location = new Point(492, 154);
            chkNoYear.Name = "chkNoYear";
            chkNoYear.Size = new Size(99, 27);
            chkNoYear.TabIndex = 25;
            chkNoYear.Text = "Без года";
            chkNoYear.UseVisualStyleBackColor = true;
            chkNoYear.CheckedChanged += chkNoYear_CheckedChanged;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 429);
            Controls.Add(chkNoYear);
            Controls.Add(txtSearchGenre);
            Controls.Add(txtSearchAuthor);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(clbGenres);
            Controls.Add(clbAuthors);
            Controls.Add(txtAuthorMark);
            Controls.Add(txtBbk);
            Controls.Add(nudPages);
            Controls.Add(nudYear);
            Controls.Add(cmbPublisher);
            Controls.Add(txtTitle);
            Controls.Add(txtIsbn);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClearCover);
            Controls.Add(btnLoadCover);
            Controls.Add(pbCover);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BookForm";
            ((System.ComponentModel.ISupportInitialize)pbCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private PictureBox pbCover;
        private Button btnLoadCover;
        private Button btnClearCover;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtIsbn;
        private TextBox txtTitle;
        private ComboBox cmbPublisher;
        private NumericUpDown nudYear;
        private NumericUpDown nudPages;
        private TextBox txtBbk;
        private TextBox txtAuthorMark;
        private CheckedListBox clbAuthors;
        private CheckedListBox clbGenres;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtSearchAuthor;
        private TextBox txtSearchGenre;
        private CheckBox chkNoYear;
    }
}