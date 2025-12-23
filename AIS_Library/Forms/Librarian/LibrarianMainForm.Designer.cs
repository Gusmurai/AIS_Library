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
            btnLogout = new Button();
            btnChangePassword = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            gridReaders = new DataGridView();
            panel2 = new Panel();
            btnChangeStatus = new Button();
            btnHistoryReader = new Button();
            btnEditReader = new Button();
            btnAddReader = new Button();
            txtSearchReader = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            gridBooks = new DataGridView();
            panel3 = new Panel();
            btnArchiveBook = new Button();
            btnCopies = new Button();
            btnEditBook = new Button();
            btnAddBook = new Button();
            txtSearchBook = new TextBox();
            label2 = new Label();
            tabIssue = new TabPage();
            splitContainer1 = new SplitContainer();
            gridCirculationReaders = new DataGridView();
            pnlReaderInfo = new Panel();
            groupBox2 = new GroupBox();
            gridReaderFines = new DataGridView();
            panel5 = new Panel();
            btnPayFine = new Button();
            btnEditNote = new Button();
            groupBox1 = new GroupBox();
            lblCirculationInfo = new Label();
            lblCirculationName = new Label();
            pbCirculationPhoto = new PictureBox();
            panel4 = new Panel();
            txtCirculationReaderSearch = new TextBox();
            label3 = new Label();
            gridReaderBooks = new DataGridView();
            label4 = new Label();
            panel6 = new Panel();
            btnExtendBook = new Button();
            btnLostBook = new Button();
            btnReturnBook = new Button();
            btnIssueBook = new Button();
            btnFindBook = new Button();
            txtInv = new TextBox();
            label5 = new Label();
            tabPage4 = new TabPage();
            gridAllFines = new DataGridView();
            panel10 = new Panel();
            btnEditAmount = new Button();
            btnAnnulFine = new Button();
            btnGlobalNote = new Button();
            btnGlobalPay = new Button();
            lblTotalFines = new Label();
            panel9 = new Panel();
            btnFilterFines = new Button();
            cboFineStatus = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            dtpFineEnd = new DateTimePicker();
            dtpFineStart = new DateTimePicker();
            txtFilterFineReader = new TextBox();
            label7 = new Label();
            tabPage5 = new TabPage();
            gridWriteOffs = new DataGridView();
            panel12 = new Panel();
            label13 = new Label();
            lbWriteOffs = new Label();
            panel11 = new Panel();
            label12 = new Label();
            label11 = new Label();
            btnFilterWriteOff = new Button();
            dtpWriteOffEnd = new DateTimePicker();
            dtpWriteOffStart = new DateTimePicker();
            txtSearWriteOff = new TextBox();
            txtSearchWriteOff = new Label();
            tabReserv = new TabPage();
            gridReservations = new DataGridView();
            panel8 = new Panel();
            btnGoToIssue = new Button();
            btnCancelReservation = new Button();
            panel7 = new Panel();
            label14 = new Label();
            btnCreateReservation = new Button();
            cboResStatus = new ComboBox();
            txtSearchReservation = new TextBox();
            label6 = new Label();
            tabPage7 = new TabPage();
            gridReports = new DataGridView();
            panel13 = new Panel();
            dtpReportEnd = new DateTimePicker();
            dtpReportStart = new DateTimePicker();
            cboReportType = new ComboBox();
            btnGenerateReport = new Button();
            btnExportReport = new Button();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaders).BeginInit();
            panel2.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBooks).BeginInit();
            panel3.SuspendLayout();
            tabIssue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCirculationReaders).BeginInit();
            pnlReaderInfo.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaderFines).BeginInit();
            panel5.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCirculationPhoto).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaderBooks).BeginInit();
            panel6.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAllFines).BeginInit();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridWriteOffs).BeginInit();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            tabReserv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReservations).BeginInit();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReports).BeginInit();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnChangePassword);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 34);
            panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(1273, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.BackColor = Color.White;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Location = new Point(1124, 3);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(143, 29);
            btnChangePassword.TabIndex = 0;
            btnChangePassword.Text = "Сменить пароль";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabIssue);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabReserv);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControl1.Location = new Point(0, 34);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1370, 603);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gridReaders);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1362, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Читатели";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridReaders
            // 
            gridReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReaders.Dock = DockStyle.Fill;
            gridReaders.Location = new Point(3, 46);
            gridReaders.Name = "gridReaders";
            gridReaders.ReadOnly = true;
            gridReaders.RowHeadersVisible = false;
            gridReaders.RowHeadersWidth = 51;
            gridReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridReaders.Size = new Size(1356, 518);
            gridReaders.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnChangeStatus);
            panel2.Controls.Add(btnHistoryReader);
            panel2.Controls.Add(btnEditReader);
            panel2.Controls.Add(btnAddReader);
            panel2.Controls.Add(txtSearchReader);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1356, 43);
            panel2.TabIndex = 0;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeStatus.Location = new Point(1176, 4);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(175, 31);
            btnChangeStatus.TabIndex = 5;
            btnChangeStatus.Text = "В архив/Из архива";
            btnChangeStatus.UseVisualStyleBackColor = true;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // btnHistoryReader
            // 
            btnHistoryReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistoryReader.Location = new Point(769, 4);
            btnHistoryReader.Name = "btnHistoryReader";
            btnHistoryReader.Size = new Size(118, 30);
            btnHistoryReader.TabIndex = 4;
            btnHistoryReader.Text = "Формуляр";
            btnHistoryReader.UseVisualStyleBackColor = true;
            btnHistoryReader.Click += btnHistoryReader_Click;
            // 
            // btnEditReader
            // 
            btnEditReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditReader.Location = new Point(1024, 4);
            btnEditReader.Name = "btnEditReader";
            btnEditReader.Size = new Size(143, 32);
            btnEditReader.TabIndex = 3;
            btnEditReader.Text = "Редактировать";
            btnEditReader.UseVisualStyleBackColor = true;
            btnEditReader.Click += btnEditReader_Click;
            // 
            // btnAddReader
            // 
            btnAddReader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddReader.Location = new Point(893, 4);
            btnAddReader.Name = "btnAddReader";
            btnAddReader.Size = new Size(125, 31);
            btnAddReader.TabIndex = 2;
            btnAddReader.Text = "Регистрация";
            btnAddReader.UseVisualStyleBackColor = true;
            btnAddReader.Click += btnAddReader_Click;
            // 
            // txtSearchReader
            // 
            txtSearchReader.Location = new Point(72, 6);
            txtSearchReader.Name = "txtSearchReader";
            txtSearchReader.Size = new Size(244, 30);
            txtSearchReader.TabIndex = 1;
            txtSearchReader.TextChanged += txtSearchReader_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 0;
            label1.Text = "Поиск";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gridBooks);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1362, 567);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Каталог книг";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridBooks
            // 
            gridBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBooks.Dock = DockStyle.Fill;
            gridBooks.Location = new Point(3, 43);
            gridBooks.Name = "gridBooks";
            gridBooks.RowHeadersVisible = false;
            gridBooks.RowHeadersWidth = 51;
            gridBooks.Size = new Size(1356, 521);
            gridBooks.TabIndex = 1;
            gridBooks.CellFormatting += gridBooks_CellFormatting;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnArchiveBook);
            panel3.Controls.Add(btnCopies);
            panel3.Controls.Add(btnEditBook);
            panel3.Controls.Add(btnAddBook);
            panel3.Controls.Add(txtSearchBook);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1356, 40);
            panel3.TabIndex = 0;
            // 
            // btnArchiveBook
            // 
            btnArchiveBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnArchiveBook.Location = new Point(1170, 3);
            btnArchiveBook.Name = "btnArchiveBook";
            btnArchiveBook.Size = new Size(181, 29);
            btnArchiveBook.TabIndex = 5;
            btnArchiveBook.Text = "В архив/Из архива";
            btnArchiveBook.UseVisualStyleBackColor = true;
            btnArchiveBook.Click += btnArchiveBook_Click;
            // 
            // btnCopies
            // 
            btnCopies.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopies.Location = new Point(748, 3);
            btnCopies.Name = "btnCopies";
            btnCopies.Size = new Size(128, 29);
            btnCopies.TabIndex = 4;
            btnCopies.Text = "Экземпляры";
            btnCopies.UseVisualStyleBackColor = true;
            btnCopies.Click += btnCopies_Click;
            // 
            // btnEditBook
            // 
            btnEditBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditBook.Location = new Point(1016, 3);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(148, 29);
            btnEditBook.TabIndex = 3;
            btnEditBook.Text = "Редактировать";
            btnEditBook.UseVisualStyleBackColor = true;
            btnEditBook.Click += btnEditBook_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddBook.Location = new Point(882, 3);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(128, 29);
            btnAddBook.TabIndex = 2;
            btnAddBook.Text = "Новая книга";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(72, 6);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(243, 30);
            txtSearchBook.TabIndex = 1;
            txtSearchBook.TextChanged += txtSearchBook_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 9);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 0;
            label2.Text = "Поиск";
            // 
            // tabIssue
            // 
            tabIssue.Controls.Add(splitContainer1);
            tabIssue.Location = new Point(4, 32);
            tabIssue.Name = "tabIssue";
            tabIssue.Size = new Size(1362, 567);
            tabIssue.TabIndex = 2;
            tabIssue.Text = "Выдача/Возврат";
            tabIssue.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(gridCirculationReaders);
            splitContainer1.Panel1.Controls.Add(pnlReaderInfo);
            splitContainer1.Panel1.Controls.Add(panel4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gridReaderBooks);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Size = new Size(1362, 567);
            splitContainer1.SplitterDistance = 626;
            splitContainer1.TabIndex = 0;
            // 
            // gridCirculationReaders
            // 
            gridCirculationReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCirculationReaders.Dock = DockStyle.Fill;
            gridCirculationReaders.Location = new Point(0, 38);
            gridCirculationReaders.Name = "gridCirculationReaders";
            gridCirculationReaders.RowHeadersWidth = 51;
            gridCirculationReaders.Size = new Size(626, 119);
            gridCirculationReaders.TabIndex = 2;
            gridCirculationReaders.CellClick += gridCirculationReaders_CellClick;
            // 
            // pnlReaderInfo
            // 
            pnlReaderInfo.Controls.Add(groupBox2);
            pnlReaderInfo.Controls.Add(panel5);
            pnlReaderInfo.Controls.Add(groupBox1);
            pnlReaderInfo.Dock = DockStyle.Bottom;
            pnlReaderInfo.Location = new Point(0, 157);
            pnlReaderInfo.Name = "pnlReaderInfo";
            pnlReaderInfo.Size = new Size(626, 410);
            pnlReaderInfo.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridReaderFines);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(0, 190);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(626, 178);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Неоплаченные штрафы";
            // 
            // gridReaderFines
            // 
            gridReaderFines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReaderFines.Dock = DockStyle.Fill;
            gridReaderFines.Location = new Point(3, 26);
            gridReaderFines.Name = "gridReaderFines";
            gridReaderFines.RowHeadersWidth = 51;
            gridReaderFines.Size = new Size(620, 149);
            gridReaderFines.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnPayFine);
            panel5.Controls.Add(btnEditNote);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 368);
            panel5.Name = "panel5";
            panel5.Size = new Size(626, 42);
            panel5.TabIndex = 1;
            // 
            // btnPayFine
            // 
            btnPayFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPayFine.Location = new Point(517, 10);
            btnPayFine.Name = "btnPayFine";
            btnPayFine.Size = new Size(94, 29);
            btnPayFine.TabIndex = 1;
            btnPayFine.Text = "Оплата";
            btnPayFine.UseVisualStyleBackColor = true;
            btnPayFine.Click += btnPayFine_Click;
            // 
            // btnEditNote
            // 
            btnEditNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditNote.Location = new Point(408, 10);
            btnEditNote.Name = "btnEditNote";
            btnEditNote.Size = new Size(94, 29);
            btnEditNote.TabIndex = 0;
            btnEditNote.Text = "Заметка";
            btnEditNote.UseVisualStyleBackColor = true;
            btnEditNote.Click += btnEditNote_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCirculationInfo);
            groupBox1.Controls.Add(lblCirculationName);
            groupBox1.Controls.Add(pbCirculationPhoto);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(626, 190);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выбранный читатель";
            // 
            // lblCirculationInfo
            // 
            lblCirculationInfo.AutoSize = true;
            lblCirculationInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCirculationInfo.Location = new Point(149, 74);
            lblCirculationInfo.Name = "lblCirculationInfo";
            lblCirculationInfo.Size = new Size(130, 23);
            lblCirculationInfo.TabIndex = 2;
            lblCirculationInfo.Text = "№ ЧБ, телефон";
            // 
            // lblCirculationName
            // 
            lblCirculationName.AutoSize = true;
            lblCirculationName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblCirculationName.Location = new Point(149, 32);
            lblCirculationName.Name = "lblCirculationName";
            lblCirculationName.Size = new Size(50, 23);
            lblCirculationName.TabIndex = 1;
            lblCirculationName.Text = "ФИО";
            // 
            // pbCirculationPhoto
            // 
            pbCirculationPhoto.Dock = DockStyle.Left;
            pbCirculationPhoto.Location = new Point(3, 26);
            pbCirculationPhoto.Name = "pbCirculationPhoto";
            pbCirculationPhoto.Size = new Size(120, 161);
            pbCirculationPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbCirculationPhoto.TabIndex = 0;
            pbCirculationPhoto.TabStop = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtCirculationReaderSearch);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(626, 38);
            panel4.TabIndex = 0;
            // 
            // txtCirculationReaderSearch
            // 
            txtCirculationReaderSearch.Location = new Point(149, 5);
            txtCirculationReaderSearch.Name = "txtCirculationReaderSearch";
            txtCirculationReaderSearch.Size = new Size(253, 30);
            txtCirculationReaderSearch.TabIndex = 1;
            txtCirculationReaderSearch.TextChanged += txtCirculationReaderSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(6, 8);
            label3.Name = "label3";
            label3.Size = new Size(133, 23);
            label3.TabIndex = 0;
            label3.Text = "Поиск читателя";
            // 
            // gridReaderBooks
            // 
            gridReaderBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReaderBooks.Dock = DockStyle.Fill;
            gridReaderBooks.Location = new Point(0, 23);
            gridReaderBooks.Name = "gridReaderBooks";
            gridReaderBooks.RowHeadersWidth = 51;
            gridReaderBooks.Size = new Size(732, 502);
            gridReaderBooks.TabIndex = 2;
            gridReaderBooks.CellFormatting += gridReaderBooks_CellFormatting;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(129, 23);
            label4.TabIndex = 1;
            label4.Text = "Книги на руках";
            // 
            // panel6
            // 
            panel6.Controls.Add(btnExtendBook);
            panel6.Controls.Add(btnLostBook);
            panel6.Controls.Add(btnReturnBook);
            panel6.Controls.Add(btnIssueBook);
            panel6.Controls.Add(btnFindBook);
            panel6.Controls.Add(txtInv);
            panel6.Controls.Add(label5);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 525);
            panel6.Name = "panel6";
            panel6.Size = new Size(732, 42);
            panel6.TabIndex = 0;
            // 
            // btnExtendBook
            // 
            btnExtendBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExtendBook.Location = new Point(634, 5);
            btnExtendBook.Name = "btnExtendBook";
            btnExtendBook.Size = new Size(94, 29);
            btnExtendBook.TabIndex = 6;
            btnExtendBook.Text = "Продлить";
            btnExtendBook.UseVisualStyleBackColor = true;
            btnExtendBook.Click += btnExtendBook_Click;
            // 
            // btnLostBook
            // 
            btnLostBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLostBook.Location = new Point(515, 6);
            btnLostBook.Name = "btnLostBook";
            btnLostBook.Size = new Size(113, 29);
            btnLostBook.TabIndex = 5;
            btnLostBook.Text = "Утеря книги";
            btnLostBook.UseVisualStyleBackColor = true;
            btnLostBook.Click += btnLostBook_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReturnBook.Location = new Point(415, 5);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(94, 29);
            btnReturnBook.TabIndex = 4;
            btnReturnBook.Text = "Возврат";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Location = new Point(305, 5);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(94, 29);
            btnIssueBook.TabIndex = 3;
            btnIssueBook.Text = "Выдать";
            btnIssueBook.UseVisualStyleBackColor = true;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnFindBook
            // 
            btnFindBook.Location = new Point(205, 5);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(94, 29);
            btnFindBook.TabIndex = 2;
            btnFindBook.Text = "Найти";
            btnFindBook.UseVisualStyleBackColor = true;
            btnFindBook.Click += btnFindBook_Click;
            // 
            // txtInv
            // 
            txtInv.Location = new Point(74, 7);
            txtInv.Name = "txtInv";
            txtInv.Size = new Size(125, 30);
            txtInv.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 11);
            label5.Name = "label5";
            label5.Size = new Size(69, 23);
            label5.TabIndex = 0;
            label5.Text = "ИНВ №";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(gridAllFines);
            tabPage4.Controls.Add(panel10);
            tabPage4.Controls.Add(panel9);
            tabPage4.Location = new Point(4, 32);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1362, 567);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Штрафы";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridAllFines
            // 
            gridAllFines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAllFines.Dock = DockStyle.Fill;
            gridAllFines.Location = new Point(0, 47);
            gridAllFines.Name = "gridAllFines";
            gridAllFines.RowHeadersWidth = 51;
            gridAllFines.Size = new Size(1362, 465);
            gridAllFines.TabIndex = 2;
            gridAllFines.CellFormatting += gridAllFines_CellFormatting;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnEditAmount);
            panel10.Controls.Add(btnAnnulFine);
            panel10.Controls.Add(btnGlobalNote);
            panel10.Controls.Add(btnGlobalPay);
            panel10.Controls.Add(lblTotalFines);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 512);
            panel10.Name = "panel10";
            panel10.Size = new Size(1362, 55);
            panel10.TabIndex = 1;
            // 
            // btnEditAmount
            // 
            btnEditAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditAmount.Location = new Point(567, 20);
            btnEditAmount.Name = "btnEditAmount";
            btnEditAmount.Size = new Size(250, 28);
            btnEditAmount.TabIndex = 4;
            btnEditAmount.Text = "Изменить сумму штрафа (admin)";
            btnEditAmount.UseVisualStyleBackColor = true;
            btnEditAmount.Click += btnEditAmount_Click;
            // 
            // btnAnnulFine
            // 
            btnAnnulFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnnulFine.Location = new Point(832, 19);
            btnAnnulFine.Name = "btnAnnulFine";
            btnAnnulFine.Size = new Size(248, 29);
            btnAnnulFine.TabIndex = 3;
            btnAnnulFine.Text = "Аннулировать штраф (admin)";
            btnAnnulFine.UseVisualStyleBackColor = true;
            btnAnnulFine.Click += btnAnnulFine_Click;
            // 
            // btnGlobalNote
            // 
            btnGlobalNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGlobalNote.Location = new Point(1260, 19);
            btnGlobalNote.Name = "btnGlobalNote";
            btnGlobalNote.Size = new Size(94, 29);
            btnGlobalNote.TabIndex = 2;
            btnGlobalNote.Text = "Заметка";
            btnGlobalNote.UseVisualStyleBackColor = true;
            btnGlobalNote.Click += btnGlobalNote_Click;
            // 
            // btnGlobalPay
            // 
            btnGlobalPay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGlobalPay.Location = new Point(1086, 19);
            btnGlobalPay.Name = "btnGlobalPay";
            btnGlobalPay.Size = new Size(155, 29);
            btnGlobalPay.TabIndex = 1;
            btnGlobalPay.Text = "Принять оплату";
            btnGlobalPay.UseVisualStyleBackColor = true;
            btnGlobalPay.Click += btnGlobalPay_Click;
            // 
            // lblTotalFines
            // 
            lblTotalFines.AutoSize = true;
            lblTotalFines.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotalFines.Location = new Point(26, 19);
            lblTotalFines.Name = "lblTotalFines";
            lblTotalFines.Size = new Size(125, 20);
            lblTotalFines.TabIndex = 0;
            lblTotalFines.Text = "Итого: 0.00 руб.";
            // 
            // panel9
            // 
            panel9.Controls.Add(btnFilterFines);
            panel9.Controls.Add(cboFineStatus);
            panel9.Controls.Add(label10);
            panel9.Controls.Add(label9);
            panel9.Controls.Add(label8);
            panel9.Controls.Add(dtpFineEnd);
            panel9.Controls.Add(dtpFineStart);
            panel9.Controls.Add(txtFilterFineReader);
            panel9.Controls.Add(label7);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1362, 47);
            panel9.TabIndex = 0;
            // 
            // btnFilterFines
            // 
            btnFilterFines.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterFines.Location = new Point(1241, 11);
            btnFilterFines.Name = "btnFilterFines";
            btnFilterFines.Size = new Size(113, 29);
            btnFilterFines.TabIndex = 8;
            btnFilterFines.Text = "Применить";
            btnFilterFines.UseVisualStyleBackColor = true;
            btnFilterFines.Click += btnFilterFines_Click;
            // 
            // cboFineStatus
            // 
            cboFineStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFineStatus.FormattingEnabled = true;
            cboFineStatus.Items.AddRange(new object[] { "Все", "Неоплаченные", "Оплаченные" });
            cboFineStatus.Location = new Point(694, 10);
            cboFineStatus.Name = "cboFineStatus";
            cboFineStatus.Size = new Size(151, 31);
            cboFineStatus.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(636, 14);
            label10.Name = "label10";
            label10.Size = new Size(60, 23);
            label10.TabIndex = 6;
            label10.Text = "Статус";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(462, 15);
            label9.Name = "label9";
            label9.Size = new Size(30, 23);
            label9.TabIndex = 5;
            label9.Text = "по";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(316, 16);
            label8.Name = "label8";
            label8.Size = new Size(21, 23);
            label8.TabIndex = 4;
            label8.Text = "С";
            // 
            // dtpFineEnd
            // 
            dtpFineEnd.Format = DateTimePickerFormat.Short;
            dtpFineEnd.Location = new Point(495, 11);
            dtpFineEnd.Name = "dtpFineEnd";
            dtpFineEnd.Size = new Size(115, 30);
            dtpFineEnd.TabIndex = 3;
            // 
            // dtpFineStart
            // 
            dtpFineStart.Format = DateTimePickerFormat.Short;
            dtpFineStart.Location = new Point(340, 10);
            dtpFineStart.Name = "dtpFineStart";
            dtpFineStart.Size = new Size(116, 30);
            dtpFineStart.TabIndex = 2;
            // 
            // txtFilterFineReader
            // 
            txtFilterFineReader.Location = new Point(61, 11);
            txtFilterFineReader.Name = "txtFilterFineReader";
            txtFilterFineReader.Size = new Size(248, 30);
            txtFilterFineReader.TabIndex = 1;
            txtFilterFineReader.TextChanged += txtFilterFineReader_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 12);
            label7.Name = "label7";
            label7.Size = new Size(58, 23);
            label7.TabIndex = 0;
            label7.Text = "Поиск";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(gridWriteOffs);
            tabPage5.Controls.Add(panel12);
            tabPage5.Controls.Add(panel11);
            tabPage5.Location = new Point(4, 32);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1362, 567);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Акты списания";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // gridWriteOffs
            // 
            gridWriteOffs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWriteOffs.Dock = DockStyle.Fill;
            gridWriteOffs.Location = new Point(0, 48);
            gridWriteOffs.Name = "gridWriteOffs";
            gridWriteOffs.RowHeadersWidth = 51;
            gridWriteOffs.Size = new Size(1362, 477);
            gridWriteOffs.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.Controls.Add(label13);
            panel12.Controls.Add(lbWriteOffs);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 525);
            panel12.Name = "panel12";
            panel12.Size = new Size(1362, 42);
            panel12.TabIndex = 1;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(790, 12);
            label13.Name = "label13";
            label13.Size = new Size(485, 23);
            label13.TabIndex = 2;
            label13.Text = "(!) Восстановить книгу в фонд может только администратор";
            // 
            // lbWriteOffs
            // 
            lbWriteOffs.AutoSize = true;
            lbWriteOffs.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbWriteOffs.Location = new Point(20, 12);
            lbWriteOffs.Name = "lbWriteOffs";
            lbWriteOffs.Size = new Size(52, 20);
            lbWriteOffs.TabIndex = 1;
            lbWriteOffs.Text = "Итого";
            // 
            // panel11
            // 
            panel11.Controls.Add(label12);
            panel11.Controls.Add(label11);
            panel11.Controls.Add(btnFilterWriteOff);
            panel11.Controls.Add(dtpWriteOffEnd);
            panel11.Controls.Add(dtpWriteOffStart);
            panel11.Controls.Add(txtSearWriteOff);
            panel11.Controls.Add(txtSearchWriteOff);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(1362, 48);
            panel11.TabIndex = 0;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(474, 18);
            label12.Name = "label12";
            label12.Size = new Size(30, 23);
            label12.TabIndex = 6;
            label12.Text = "по";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(329, 18);
            label11.Name = "label11";
            label11.Size = new Size(21, 23);
            label11.TabIndex = 5;
            label11.Text = "С";
            // 
            // btnFilterWriteOff
            // 
            btnFilterWriteOff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterWriteOff.Location = new Point(1244, 11);
            btnFilterWriteOff.Name = "btnFilterWriteOff";
            btnFilterWriteOff.Size = new Size(110, 29);
            btnFilterWriteOff.TabIndex = 4;
            btnFilterWriteOff.Text = "Применить";
            btnFilterWriteOff.UseVisualStyleBackColor = true;
            btnFilterWriteOff.Click += btnFilterWriteOff_Click;
            // 
            // dtpWriteOffEnd
            // 
            dtpWriteOffEnd.Format = DateTimePickerFormat.Short;
            dtpWriteOffEnd.Location = new Point(507, 13);
            dtpWriteOffEnd.Name = "dtpWriteOffEnd";
            dtpWriteOffEnd.Size = new Size(117, 30);
            dtpWriteOffEnd.TabIndex = 3;
            // 
            // dtpWriteOffStart
            // 
            dtpWriteOffStart.Format = DateTimePickerFormat.Short;
            dtpWriteOffStart.Location = new Point(353, 13);
            dtpWriteOffStart.Name = "dtpWriteOffStart";
            dtpWriteOffStart.Size = new Size(115, 30);
            dtpWriteOffStart.TabIndex = 2;
            // 
            // txtSearWriteOff
            // 
            txtSearWriteOff.Location = new Point(76, 13);
            txtSearWriteOff.Name = "txtSearWriteOff";
            txtSearWriteOff.Size = new Size(234, 30);
            txtSearWriteOff.TabIndex = 1;
            txtSearWriteOff.TextChanged += txtSearWriteOff_TextChanged;
            // 
            // txtSearchWriteOff
            // 
            txtSearchWriteOff.AutoSize = true;
            txtSearchWriteOff.Location = new Point(8, 16);
            txtSearchWriteOff.Name = "txtSearchWriteOff";
            txtSearchWriteOff.Size = new Size(58, 23);
            txtSearchWriteOff.TabIndex = 0;
            txtSearchWriteOff.Text = "Поиск";
            // 
            // tabReserv
            // 
            tabReserv.Controls.Add(gridReservations);
            tabReserv.Controls.Add(panel8);
            tabReserv.Controls.Add(panel7);
            tabReserv.Location = new Point(4, 32);
            tabReserv.Name = "tabReserv";
            tabReserv.Size = new Size(1362, 567);
            tabReserv.TabIndex = 5;
            tabReserv.Text = "Бронирование";
            tabReserv.UseVisualStyleBackColor = true;
            // 
            // gridReservations
            // 
            gridReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReservations.Dock = DockStyle.Fill;
            gridReservations.Location = new Point(0, 42);
            gridReservations.Name = "gridReservations";
            gridReservations.RowHeadersWidth = 51;
            gridReservations.Size = new Size(1362, 482);
            gridReservations.TabIndex = 2;
            gridReservations.CellFormatting += gridReservations_CellFormatting;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnGoToIssue);
            panel8.Controls.Add(btnCancelReservation);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 524);
            panel8.Name = "panel8";
            panel8.Size = new Size(1362, 43);
            panel8.TabIndex = 1;
            // 
            // btnGoToIssue
            // 
            btnGoToIssue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGoToIssue.Location = new Point(1154, 6);
            btnGoToIssue.Name = "btnGoToIssue";
            btnGoToIssue.Size = new Size(200, 29);
            btnGoToIssue.TabIndex = 1;
            btnGoToIssue.Text = "Выдать по брони";
            btnGoToIssue.UseVisualStyleBackColor = true;
            btnGoToIssue.Click += btnGoToIssue_Click;
            // 
            // btnCancelReservation
            // 
            btnCancelReservation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelReservation.Location = new Point(987, 6);
            btnCancelReservation.Name = "btnCancelReservation";
            btnCancelReservation.Size = new Size(161, 29);
            btnCancelReservation.TabIndex = 0;
            btnCancelReservation.Text = "Отменить бронь";
            btnCancelReservation.UseVisualStyleBackColor = true;
            btnCancelReservation.Click += btnCancelReservation_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(label14);
            panel7.Controls.Add(btnCreateReservation);
            panel7.Controls.Add(cboResStatus);
            panel7.Controls.Add(txtSearchReservation);
            panel7.Controls.Add(label6);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1362, 42);
            panel7.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(334, 11);
            label14.Name = "label14";
            label14.Size = new Size(60, 23);
            label14.TabIndex = 4;
            label14.Text = "Статус";
            // 
            // btnCreateReservation
            // 
            btnCreateReservation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateReservation.Location = new Point(1099, 6);
            btnCreateReservation.Name = "btnCreateReservation";
            btnCreateReservation.Size = new Size(234, 29);
            btnCreateReservation.TabIndex = 3;
            btnCreateReservation.Text = "Оформить бронирование";
            btnCreateReservation.UseVisualStyleBackColor = true;
            btnCreateReservation.Click += btnCreateReservation_Click;
            // 
            // cboResStatus
            // 
            cboResStatus.FormattingEnabled = true;
            cboResStatus.Items.AddRange(new object[] { "Все", "Активные", "Неактивные" });
            cboResStatus.Location = new Point(400, 6);
            cboResStatus.Name = "cboResStatus";
            cboResStatus.Size = new Size(151, 31);
            cboResStatus.TabIndex = 2;
            cboResStatus.SelectedIndexChanged += cboResStatus_SelectedIndexChanged;
            // 
            // txtSearchReservation
            // 
            txtSearchReservation.Location = new Point(77, 8);
            txtSearchReservation.Name = "txtSearchReservation";
            txtSearchReservation.Size = new Size(230, 30);
            txtSearchReservation.TabIndex = 1;
            txtSearchReservation.TextChanged += txtSearchReservation_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 11);
            label6.Name = "label6";
            label6.Size = new Size(58, 23);
            label6.TabIndex = 0;
            label6.Text = "Поиск";
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(gridReports);
            tabPage7.Controls.Add(panel13);
            tabPage7.Location = new Point(4, 32);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1362, 567);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Отчёты";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // gridReports
            // 
            gridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReports.Dock = DockStyle.Fill;
            gridReports.Location = new Point(0, 41);
            gridReports.Name = "gridReports";
            gridReports.RowHeadersWidth = 51;
            gridReports.Size = new Size(1362, 526);
            gridReports.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.Controls.Add(dtpReportEnd);
            panel13.Controls.Add(dtpReportStart);
            panel13.Controls.Add(cboReportType);
            panel13.Controls.Add(btnGenerateReport);
            panel13.Controls.Add(btnExportReport);
            panel13.Controls.Add(label17);
            panel13.Controls.Add(label16);
            panel13.Controls.Add(label15);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(1362, 41);
            panel13.TabIndex = 0;
            // 
            // dtpReportEnd
            // 
            dtpReportEnd.Format = DateTimePickerFormat.Short;
            dtpReportEnd.Location = new Point(731, 6);
            dtpReportEnd.Name = "dtpReportEnd";
            dtpReportEnd.Size = new Size(126, 30);
            dtpReportEnd.TabIndex = 7;
            // 
            // dtpReportStart
            // 
            dtpReportStart.Format = DateTimePickerFormat.Short;
            dtpReportStart.Location = new Point(564, 7);
            dtpReportStart.Name = "dtpReportStart";
            dtpReportStart.Size = new Size(125, 30);
            dtpReportStart.TabIndex = 6;
            // 
            // cboReportType
            // 
            cboReportType.FormattingEnabled = true;
            cboReportType.Items.AddRange(new object[] { "Читательская активность", "Список должников", "Топ-20 популярных книг", "Неоплаченные штрафы", "Текущее состояние фонда", "Журнал списаний", "Журнал поставок" });
            cboReportType.Location = new Point(107, 6);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(310, 31);
            cboReportType.TabIndex = 5;
            cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerateReport.Location = new Point(1107, 6);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(147, 29);
            btnGenerateReport.TabIndex = 4;
            btnGenerateReport.Text = "Сформировать";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnExportReport
            // 
            btnExportReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportReport.Location = new Point(1260, 6);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(94, 29);
            btnExportReport.TabIndex = 3;
            btnExportReport.Text = "Экспорт";
            btnExportReport.UseVisualStyleBackColor = true;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(695, 10);
            label17.Name = "label17";
            label17.Size = new Size(30, 23);
            label17.TabIndex = 2;
            label17.Text = "по";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(471, 9);
            label16.Name = "label16";
            label16.Size = new Size(87, 23);
            label16.TabIndex = 1;
            label16.Text = "Период: с";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(8, 10);
            label15.Name = "label15";
            label15.Size = new Size(96, 23);
            label15.TabIndex = 0;
            label15.Text = "Вид отчёта";
            // 
            // LibrarianMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 637);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "LibrarianMainForm";
            Text = "Кабинет библиотекаря";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReaders).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridBooks).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabIssue.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCirculationReaders).EndInit();
            pnlReaderInfo.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReaderFines).EndInit();
            panel5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCirculationPhoto).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridReaderBooks).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAllFines).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridWriteOffs).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            tabReserv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReservations).EndInit();
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReports).EndInit();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
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
        private Button btnHistoryReader;
        private DataGridView gridBooks;
        private Panel panel3;
        private Button btnCopies;
        private Button btnEditBook;
        private Button btnAddBook;
        private TextBox txtSearchBook;
        private Label label2;
        private TabPage tabIssue;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button btnLogout;
        private Button btnChangePassword;
        private TabPage tabReserv;
        private TabPage tabPage7;
        private Panel panel9;
        private DateTimePicker dtpFineEnd;
        private DateTimePicker dtpFineStart;
        private TextBox txtFilterFineReader;
        private Label label7;
        private ComboBox cboFineStatus;
        private Label label10;
        private Label label9;
        private Label label8;
        private Panel panel10;
        private Button btnFilterFines;
        private Label lblTotalFines;
        private DataGridView gridAllFines;
        private Button btnGlobalNote;
        private Button btnGlobalPay;
        private DataGridView gridWriteOffs;
        private Panel panel12;
        private Panel panel11;
        private Label label12;
        private Label label11;
        private Button btnFilterWriteOff;
        private DateTimePicker dtpWriteOffEnd;
        private DateTimePicker dtpWriteOffStart;
        private TextBox txtSearWriteOff;
        private Label txtSearchWriteOff;
        private Label lbWriteOffs;
        private Button btnAnnulFine;
        private Label label13;
        private Button btnChangeStatus;
        private Button btnArchiveBook;
        private SplitContainer splitContainer1;
        private Panel panel4;
        private TextBox txtCirculationReaderSearch;
        private Label label3;
        private Panel pnlReaderInfo;
        private GroupBox groupBox1;
        private Label lblCirculationInfo;
        private Label lblCirculationName;
        private PictureBox pbCirculationPhoto;
        private DataGridView gridCirculationReaders;
        private DataGridView gridReaderFines;
        private Panel panel5;
        private Button btnPayFine;
        private Button btnEditNote;
        private Label label4;
        private Panel panel6;
        private GroupBox groupBox2;
        private Button btnFindBook;
        private TextBox txtInv;
        private Label label5;
        private Button btnExtendBook;
        private Button btnLostBook;
        private Button btnReturnBook;
        private Button btnIssueBook;
        private DataGridView gridReaderBooks;
        private Button btnEditAmount;
        private DataGridView gridReservations;
        private Panel panel8;
        private Panel panel7;
        private Button btnCreateReservation;
        private ComboBox cboResStatus;
        private TextBox txtSearchReservation;
        private Label label6;
        private Button btnGoToIssue;
        private Button btnCancelReservation;
        private Label label14;
        private DataGridView gridReports;
        private Panel panel13;
        private Label label15;
        private Label label17;
        private Label label16;
        private Button btnExportReport;
        private Button btnGenerateReport;
        private ComboBox cboReportType;
        private DateTimePicker dtpReportEnd;
        private DateTimePicker dtpReportStart;
    }
}