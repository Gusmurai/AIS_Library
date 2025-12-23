namespace AIS_Library.Forms.Admin
{
    partial class AdminMainForm
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
            txt = new TabControl();
            tabIzd = new TabPage();
            gridPublishers = new DataGridView();
            panel3 = new Panel();
            txtSearchPublisher = new TextBox();
            label5 = new Label();
            btnDeletePublisher = new Button();
            btnAddPublisher = new Button();
            btnEditPublish = new Button();
            tabAut = new TabPage();
            gridAuthors = new DataGridView();
            panel4 = new Panel();
            label6 = new Label();
            txtSearchAuthor = new TextBox();
            btnDeleteAuthor = new Button();
            btnAddAuthor = new Button();
            btnEditAuthor = new Button();
            tabGenres = new TabPage();
            gridGenres = new DataGridView();
            panel2 = new Panel();
            txtSearchGenre = new TextBox();
            label4 = new Label();
            btnAddGenre = new Button();
            btnEditGenre = new Button();
            btnDeleteGenre = new Button();
            tabPost = new TabPage();
            gridSuppliers = new DataGridView();
            panel5 = new Panel();
            label7 = new Label();
            txtSearchSupplier = new TextBox();
            btnDeleteSupplier = new Button();
            btnAddSupplier = new Button();
            btnEditSupplier = new Button();
            tabState = new TabPage();
            gridFines = new DataGridView();
            panel6 = new Panel();
            btnEditFine = new Button();
            label8 = new Label();
            txtSearchFine = new TextBox();
            btnDeleteFine = new Button();
            btnAddFine = new Button();
            tabFine = new TabPage();
            gridAllFines = new DataGridView();
            panel11 = new Panel();
            btnEditAmount = new Button();
            lblTotal = new Label();
            btnAnnulFine = new Button();
            panel10 = new Panel();
            label14 = new Label();
            cboFineStatus = new ComboBox();
            btnFilter = new Button();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            label13 = new Label();
            label12 = new Label();
            txtSearFine = new TextBox();
            label11 = new Label();
            tabReas = new TabPage();
            gridReasons = new DataGridView();
            panel9 = new Panel();
            txtSearchReason = new TextBox();
            label10 = new Label();
            btnDeleteReason = new Button();
            btnEditReason = new Button();
            btnAddReason = new Button();
            tabLib = new TabPage();
            gridLibrarians = new DataGridView();
            panel7 = new Panel();
            btnDeleteLibrarian = new Button();
            label9 = new Label();
            txtSearchLibrarian = new TextBox();
            btnEditLibrarian = new Button();
            btnAddLibrarian = new Button();
            tabSpis = new TabPage();
            gridWriteOffs = new DataGridView();
            panel13 = new Panel();
            lbWriteOffsTotal = new Label();
            btnRestoreCopy = new Button();
            panel12 = new Panel();
            label17 = new Label();
            label16 = new Label();
            btnFilterWriteOff = new Button();
            dtpWriteOffEnd = new DateTimePicker();
            dtpWriteOffStart = new DateTimePicker();
            txtSearchWriteOff = new TextBox();
            label15 = new Label();
            tabOtch = new TabPage();
            gridReports = new DataGridView();
            panel8 = new Panel();
            btnExportReport = new Button();
            btnGenerateReport = new Button();
            cboReportType = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            dtpReportStart = new DateTimePicker();
            label3 = new Label();
            dtpReportEnd = new DateTimePicker();
            tabPage1 = new TabPage();
            txtBackupLog = new TextBox();
            panel14 = new Panel();
            btnRestore = new Button();
            btnBackup = new Button();
            btnLogout = new Button();
            panel1 = new Panel();
            btnChangePassword = new Button();
            txt.SuspendLayout();
            tabIzd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPublishers).BeginInit();
            panel3.SuspendLayout();
            tabAut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAuthors).BeginInit();
            panel4.SuspendLayout();
            tabGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridGenres).BeginInit();
            panel2.SuspendLayout();
            tabPost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).BeginInit();
            panel5.SuspendLayout();
            tabState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFines).BeginInit();
            panel6.SuspendLayout();
            tabFine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAllFines).BeginInit();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            tabReas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReasons).BeginInit();
            panel9.SuspendLayout();
            tabLib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLibrarians).BeginInit();
            panel7.SuspendLayout();
            tabSpis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridWriteOffs).BeginInit();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            tabOtch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReports).BeginInit();
            panel8.SuspendLayout();
            tabPage1.SuspendLayout();
            panel14.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txt
            // 
            txt.Controls.Add(tabIzd);
            txt.Controls.Add(tabAut);
            txt.Controls.Add(tabGenres);
            txt.Controls.Add(tabPost);
            txt.Controls.Add(tabState);
            txt.Controls.Add(tabFine);
            txt.Controls.Add(tabReas);
            txt.Controls.Add(tabLib);
            txt.Controls.Add(tabSpis);
            txt.Controls.Add(tabOtch);
            txt.Controls.Add(tabPage1);
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txt.Location = new Point(0, 37);
            txt.Name = "txt";
            txt.SelectedIndex = 0;
            txt.Size = new Size(1122, 665);
            txt.TabIndex = 0;
            // 
            // tabIzd
            // 
            tabIzd.Controls.Add(gridPublishers);
            tabIzd.Controls.Add(panel3);
            tabIzd.Location = new Point(4, 32);
            tabIzd.Name = "tabIzd";
            tabIzd.Padding = new Padding(3);
            tabIzd.Size = new Size(1114, 629);
            tabIzd.TabIndex = 1;
            tabIzd.Text = "Издательства";
            tabIzd.UseVisualStyleBackColor = true;
            // 
            // gridPublishers
            // 
            gridPublishers.AllowUserToAddRows = false;
            gridPublishers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPublishers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPublishers.Dock = DockStyle.Fill;
            gridPublishers.Location = new Point(3, 44);
            gridPublishers.Name = "gridPublishers";
            gridPublishers.ReadOnly = true;
            gridPublishers.RowHeadersVisible = false;
            gridPublishers.RowHeadersWidth = 51;
            gridPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPublishers.Size = new Size(1108, 582);
            gridPublishers.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtSearchPublisher);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(btnDeletePublisher);
            panel3.Controls.Add(btnAddPublisher);
            panel3.Controls.Add(btnEditPublish);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1108, 41);
            panel3.TabIndex = 14;
            // 
            // txtSearchPublisher
            // 
            txtSearchPublisher.Location = new Point(61, 5);
            txtSearchPublisher.Name = "txtSearchPublisher";
            txtSearchPublisher.Size = new Size(267, 30);
            txtSearchPublisher.TabIndex = 15;
            txtSearchPublisher.TextChanged += txtSearchPublisher_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 7);
            label5.Name = "label5";
            label5.Size = new Size(58, 23);
            label5.TabIndex = 14;
            label5.Text = "Поиск";
            // 
            // btnDeletePublisher
            // 
            btnDeletePublisher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeletePublisher.Location = new Point(1007, 3);
            btnDeletePublisher.Name = "btnDeletePublisher";
            btnDeletePublisher.Size = new Size(94, 31);
            btnDeletePublisher.TabIndex = 6;
            btnDeletePublisher.Text = "Удалить";
            btnDeletePublisher.UseVisualStyleBackColor = true;
            btnDeletePublisher.Click += btnDeletePublisher_Click;
            // 
            // btnAddPublisher
            // 
            btnAddPublisher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPublisher.Location = new Point(757, 3);
            btnAddPublisher.Name = "btnAddPublisher";
            btnAddPublisher.Size = new Size(94, 32);
            btnAddPublisher.TabIndex = 5;
            btnAddPublisher.Text = "Добавить";
            btnAddPublisher.UseVisualStyleBackColor = true;
            btnAddPublisher.Click += btnAddPublisher_Click;
            // 
            // btnEditPublish
            // 
            btnEditPublish.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditPublish.Location = new Point(857, 3);
            btnEditPublish.Name = "btnEditPublish";
            btnEditPublish.Size = new Size(142, 31);
            btnEditPublish.TabIndex = 13;
            btnEditPublish.Text = "Редактировать";
            btnEditPublish.UseVisualStyleBackColor = true;
            btnEditPublish.Click += btnEditPublish_Click;
            // 
            // tabAut
            // 
            tabAut.Controls.Add(gridAuthors);
            tabAut.Controls.Add(panel4);
            tabAut.Location = new Point(4, 32);
            tabAut.Name = "tabAut";
            tabAut.Size = new Size(1114, 629);
            tabAut.TabIndex = 2;
            tabAut.Text = "Авторы";
            tabAut.UseVisualStyleBackColor = true;
            // 
            // gridAuthors
            // 
            gridAuthors.AllowUserToAddRows = false;
            gridAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAuthors.Dock = DockStyle.Fill;
            gridAuthors.Location = new Point(0, 43);
            gridAuthors.Name = "gridAuthors";
            gridAuthors.ReadOnly = true;
            gridAuthors.RowHeadersVisible = false;
            gridAuthors.RowHeadersWidth = 51;
            gridAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAuthors.Size = new Size(1114, 586);
            gridAuthors.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(label6);
            panel4.Controls.Add(txtSearchAuthor);
            panel4.Controls.Add(btnDeleteAuthor);
            panel4.Controls.Add(btnAddAuthor);
            panel4.Controls.Add(btnEditAuthor);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1114, 43);
            panel4.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 10);
            label6.Name = "label6";
            label6.Size = new Size(58, 23);
            label6.TabIndex = 14;
            label6.Text = "Поиск";
            // 
            // txtSearchAuthor
            // 
            txtSearchAuthor.Location = new Point(61, 7);
            txtSearchAuthor.Name = "txtSearchAuthor";
            txtSearchAuthor.Size = new Size(266, 30);
            txtSearchAuthor.TabIndex = 13;
            txtSearchAuthor.TextChanged += txtSearchAuthor_TextChanged;
            // 
            // btnDeleteAuthor
            // 
            btnDeleteAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteAuthor.Location = new Point(1017, 8);
            btnDeleteAuthor.Name = "btnDeleteAuthor";
            btnDeleteAuthor.Size = new Size(94, 29);
            btnDeleteAuthor.TabIndex = 7;
            btnDeleteAuthor.Text = "Удалить";
            btnDeleteAuthor.UseVisualStyleBackColor = true;
            btnDeleteAuthor.Click += btnDeleteAuthor_Click;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddAuthor.Location = new Point(774, 7);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(94, 29);
            btnAddAuthor.TabIndex = 6;
            btnAddAuthor.Text = "Добавить";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // btnEditAuthor
            // 
            btnEditAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditAuthor.Location = new Point(874, 8);
            btnEditAuthor.Name = "btnEditAuthor";
            btnEditAuthor.Size = new Size(137, 29);
            btnEditAuthor.TabIndex = 12;
            btnEditAuthor.Text = "Редактировать";
            btnEditAuthor.UseVisualStyleBackColor = true;
            btnEditAuthor.Click += btnEditAuthor_Click;
            // 
            // tabGenres
            // 
            tabGenres.Controls.Add(gridGenres);
            tabGenres.Controls.Add(panel2);
            tabGenres.Location = new Point(4, 32);
            tabGenres.Name = "tabGenres";
            tabGenres.Padding = new Padding(3);
            tabGenres.Size = new Size(1114, 629);
            tabGenres.TabIndex = 0;
            tabGenres.Text = "Жанры";
            tabGenres.UseVisualStyleBackColor = true;
            // 
            // gridGenres
            // 
            gridGenres.AllowUserToAddRows = false;
            gridGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridGenres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGenres.Dock = DockStyle.Fill;
            gridGenres.Location = new Point(3, 46);
            gridGenres.MultiSelect = false;
            gridGenres.Name = "gridGenres";
            gridGenres.ReadOnly = true;
            gridGenres.RowHeadersVisible = false;
            gridGenres.RowHeadersWidth = 51;
            gridGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridGenres.Size = new Size(1108, 580);
            gridGenres.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtSearchGenre);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnAddGenre);
            panel2.Controls.Add(btnEditGenre);
            panel2.Controls.Add(btnDeleteGenre);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1108, 43);
            panel2.TabIndex = 14;
            // 
            // txtSearchGenre
            // 
            txtSearchGenre.Location = new Point(61, 6);
            txtSearchGenre.Name = "txtSearchGenre";
            txtSearchGenre.Size = new Size(269, 30);
            txtSearchGenre.TabIndex = 15;
            txtSearchGenre.TextChanged += txtSearchGenre_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 14;
            label4.Text = "Поиск";
            // 
            // btnAddGenre
            // 
            btnAddGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddGenre.Location = new Point(765, 3);
            btnAddGenre.Name = "btnAddGenre";
            btnAddGenre.Size = new Size(100, 31);
            btnAddGenre.TabIndex = 5;
            btnAddGenre.Text = "Добавить";
            btnAddGenre.UseVisualStyleBackColor = true;
            btnAddGenre.Click += btnAddGenre_Click;
            // 
            // btnEditGenre
            // 
            btnEditGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditGenre.Location = new Point(871, 3);
            btnEditGenre.Name = "btnEditGenre";
            btnEditGenre.Size = new Size(134, 30);
            btnEditGenre.TabIndex = 13;
            btnEditGenre.Text = "Редактировать";
            btnEditGenre.UseVisualStyleBackColor = true;
            btnEditGenre.Click += btnEditGenre_Click;
            // 
            // btnDeleteGenre
            // 
            btnDeleteGenre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteGenre.Location = new Point(1011, 3);
            btnDeleteGenre.Name = "btnDeleteGenre";
            btnDeleteGenre.Size = new Size(94, 32);
            btnDeleteGenre.TabIndex = 6;
            btnDeleteGenre.Text = "Удалить";
            btnDeleteGenre.UseVisualStyleBackColor = true;
            btnDeleteGenre.Click += btnDeleteGenre_Click;
            // 
            // tabPost
            // 
            tabPost.Controls.Add(gridSuppliers);
            tabPost.Controls.Add(panel5);
            tabPost.Location = new Point(4, 32);
            tabPost.Name = "tabPost";
            tabPost.Padding = new Padding(3);
            tabPost.Size = new Size(1114, 629);
            tabPost.TabIndex = 3;
            tabPost.Text = "Поставщики";
            tabPost.UseVisualStyleBackColor = true;
            // 
            // gridSuppliers
            // 
            gridSuppliers.AllowUserToAddRows = false;
            gridSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSuppliers.Dock = DockStyle.Fill;
            gridSuppliers.Location = new Point(3, 46);
            gridSuppliers.MultiSelect = false;
            gridSuppliers.Name = "gridSuppliers";
            gridSuppliers.ReadOnly = true;
            gridSuppliers.RowHeadersVisible = false;
            gridSuppliers.RowHeadersWidth = 51;
            gridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSuppliers.Size = new Size(1108, 580);
            gridSuppliers.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(label7);
            panel5.Controls.Add(txtSearchSupplier);
            panel5.Controls.Add(btnDeleteSupplier);
            panel5.Controls.Add(btnAddSupplier);
            panel5.Controls.Add(btnEditSupplier);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1108, 43);
            panel5.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 8);
            label7.Name = "label7";
            label7.Size = new Size(58, 23);
            label7.TabIndex = 15;
            label7.Text = "Поиск";
            // 
            // txtSearchSupplier
            // 
            txtSearchSupplier.Location = new Point(67, 7);
            txtSearchSupplier.Name = "txtSearchSupplier";
            txtSearchSupplier.Size = new Size(263, 30);
            txtSearchSupplier.TabIndex = 16;
            txtSearchSupplier.TextChanged += txtSearchSupplier_TextChanged;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteSupplier.Location = new Point(1009, 7);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(94, 30);
            btnDeleteSupplier.TabIndex = 12;
            btnDeleteSupplier.Text = "Удалить";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSupplier.Location = new Point(767, 4);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(94, 33);
            btnAddSupplier.TabIndex = 11;
            btnAddSupplier.Text = "Добавить";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditSupplier.Location = new Point(867, 5);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(134, 32);
            btnEditSupplier.TabIndex = 13;
            btnEditSupplier.Text = "Редактировать";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // tabState
            // 
            tabState.Controls.Add(gridFines);
            tabState.Controls.Add(panel6);
            tabState.Location = new Point(4, 32);
            tabState.Name = "tabState";
            tabState.Size = new Size(1114, 629);
            tabState.TabIndex = 4;
            tabState.Text = "Штрафные статьи";
            tabState.UseVisualStyleBackColor = true;
            // 
            // gridFines
            // 
            gridFines.AllowUserToAddRows = false;
            gridFines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridFines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFines.Dock = DockStyle.Fill;
            gridFines.Location = new Point(0, 46);
            gridFines.MultiSelect = false;
            gridFines.Name = "gridFines";
            gridFines.ReadOnly = true;
            gridFines.RowHeadersVisible = false;
            gridFines.RowHeadersWidth = 51;
            gridFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridFines.Size = new Size(1114, 583);
            gridFines.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnEditFine);
            panel6.Controls.Add(label8);
            panel6.Controls.Add(txtSearchFine);
            panel6.Controls.Add(btnDeleteFine);
            panel6.Controls.Add(btnAddFine);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1114, 46);
            panel6.TabIndex = 17;
            // 
            // btnEditFine
            // 
            btnEditFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditFine.Location = new Point(868, 5);
            btnEditFine.Name = "btnEditFine";
            btnEditFine.Size = new Size(143, 32);
            btnEditFine.TabIndex = 9;
            btnEditFine.Text = "Редактировать";
            btnEditFine.UseVisualStyleBackColor = true;
            btnEditFine.Click += btnEditFine_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 10);
            label8.Name = "label8";
            label8.Size = new Size(58, 23);
            label8.TabIndex = 15;
            label8.Text = "Поиск";
            // 
            // txtSearchFine
            // 
            txtSearchFine.Location = new Point(64, 7);
            txtSearchFine.Name = "txtSearchFine";
            txtSearchFine.Size = new Size(270, 30);
            txtSearchFine.TabIndex = 16;
            txtSearchFine.TextChanged += txtSearchFine_TextChanged;
            // 
            // btnDeleteFine
            // 
            btnDeleteFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteFine.Location = new Point(1017, 5);
            btnDeleteFine.Name = "btnDeleteFine";
            btnDeleteFine.Size = new Size(94, 32);
            btnDeleteFine.TabIndex = 8;
            btnDeleteFine.Text = "Удалить";
            btnDeleteFine.UseVisualStyleBackColor = true;
            btnDeleteFine.Click += btnDeleteFine_Click;
            // 
            // btnAddFine
            // 
            btnAddFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFine.Location = new Point(768, 5);
            btnAddFine.Name = "btnAddFine";
            btnAddFine.Size = new Size(94, 32);
            btnAddFine.TabIndex = 7;
            btnAddFine.Text = "Добавить";
            btnAddFine.UseVisualStyleBackColor = true;
            btnAddFine.Click += btnAddFine_Click;
            // 
            // tabFine
            // 
            tabFine.Controls.Add(gridAllFines);
            tabFine.Controls.Add(panel11);
            tabFine.Controls.Add(panel10);
            tabFine.Location = new Point(4, 32);
            tabFine.Name = "tabFine";
            tabFine.Size = new Size(1114, 629);
            tabFine.TabIndex = 8;
            tabFine.Text = "Штрафы";
            tabFine.UseVisualStyleBackColor = true;
            // 
            // gridAllFines
            // 
            gridAllFines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAllFines.Dock = DockStyle.Fill;
            gridAllFines.Location = new Point(0, 44);
            gridAllFines.Name = "gridAllFines";
            gridAllFines.RowHeadersWidth = 51;
            gridAllFines.Size = new Size(1114, 529);
            gridAllFines.TabIndex = 2;
            gridAllFines.CellFormatting += gridAllFines_CellFormatting;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnEditAmount);
            panel11.Controls.Add(lblTotal);
            panel11.Controls.Add(btnAnnulFine);
            panel11.Dock = DockStyle.Bottom;
            panel11.Location = new Point(0, 573);
            panel11.Name = "panel11";
            panel11.Size = new Size(1114, 56);
            panel11.TabIndex = 1;
            // 
            // btnEditAmount
            // 
            btnEditAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditAmount.Location = new Point(705, 19);
            btnEditAmount.Name = "btnEditAmount";
            btnEditAmount.Size = new Size(216, 29);
            btnEditAmount.TabIndex = 9;
            btnEditAmount.Text = "Изменить сумму штрафа";
            btnEditAmount.UseVisualStyleBackColor = true;
            btnEditAmount.Click += btnEditAmount_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.Location = new Point(23, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 20);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Итого";
            // 
            // btnAnnulFine
            // 
            btnAnnulFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnnulFine.Location = new Point(936, 19);
            btnAnnulFine.Name = "btnAnnulFine";
            btnAnnulFine.Size = new Size(170, 29);
            btnAnnulFine.TabIndex = 7;
            btnAnnulFine.Text = "Аннулировать штраф";
            btnAnnulFine.UseVisualStyleBackColor = true;
            btnAnnulFine.Click += btnAnnulFine_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(label14);
            panel10.Controls.Add(cboFineStatus);
            panel10.Controls.Add(btnFilter);
            panel10.Controls.Add(dtpEnd);
            panel10.Controls.Add(dtpStart);
            panel10.Controls.Add(label13);
            panel10.Controls.Add(label12);
            panel10.Controls.Add(txtSearFine);
            panel10.Controls.Add(label11);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(1114, 44);
            panel10.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(608, 14);
            label14.Name = "label14";
            label14.Size = new Size(60, 23);
            label14.TabIndex = 8;
            label14.Text = "Статус";
            // 
            // cboFineStatus
            // 
            cboFineStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFineStatus.FormattingEnabled = true;
            cboFineStatus.Items.AddRange(new object[] { "Все", "Неоплаченные", "Оплаченные" });
            cboFineStatus.Location = new Point(679, 8);
            cboFineStatus.Name = "cboFineStatus";
            cboFineStatus.Size = new Size(151, 31);
            cboFineStatus.TabIndex = 7;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.Location = new Point(993, 7);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(113, 29);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Применить";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(475, 11);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(116, 30);
            dtpEnd.TabIndex = 5;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(318, 11);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(118, 30);
            dtpStart.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(442, 14);
            label13.Name = "label13";
            label13.Size = new Size(30, 23);
            label13.TabIndex = 3;
            label13.Text = "по";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(285, 14);
            label12.Name = "label12";
            label12.Size = new Size(21, 23);
            label12.TabIndex = 2;
            label12.Text = "С";
            // 
            // txtSearFine
            // 
            txtSearFine.Location = new Point(66, 10);
            txtSearFine.Name = "txtSearFine";
            txtSearFine.Size = new Size(208, 30);
            txtSearFine.TabIndex = 1;
            txtSearFine.TextChanged += txtSearFine_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 11);
            label11.Name = "label11";
            label11.Size = new Size(58, 23);
            label11.TabIndex = 0;
            label11.Text = "Поиск";
            // 
            // tabReas
            // 
            tabReas.Controls.Add(gridReasons);
            tabReas.Controls.Add(panel9);
            tabReas.Location = new Point(4, 32);
            tabReas.Name = "tabReas";
            tabReas.Size = new Size(1114, 629);
            tabReas.TabIndex = 7;
            tabReas.Text = "Причины списаний";
            tabReas.UseVisualStyleBackColor = true;
            // 
            // gridReasons
            // 
            gridReasons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReasons.Dock = DockStyle.Fill;
            gridReasons.Location = new Point(0, 45);
            gridReasons.Name = "gridReasons";
            gridReasons.RowHeadersWidth = 51;
            gridReasons.Size = new Size(1114, 584);
            gridReasons.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Controls.Add(txtSearchReason);
            panel9.Controls.Add(label10);
            panel9.Controls.Add(btnDeleteReason);
            panel9.Controls.Add(btnEditReason);
            panel9.Controls.Add(btnAddReason);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1114, 45);
            panel9.TabIndex = 0;
            // 
            // txtSearchReason
            // 
            txtSearchReason.Location = new Point(72, 10);
            txtSearchReason.Name = "txtSearchReason";
            txtSearchReason.Size = new Size(253, 30);
            txtSearchReason.TabIndex = 4;
            txtSearchReason.TextChanged += txtSearchReason_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 10);
            label10.Name = "label10";
            label10.Size = new Size(58, 23);
            label10.TabIndex = 3;
            label10.Text = "Поиск";
            // 
            // btnDeleteReason
            // 
            btnDeleteReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteReason.Location = new Point(1017, 7);
            btnDeleteReason.Name = "btnDeleteReason";
            btnDeleteReason.Size = new Size(94, 29);
            btnDeleteReason.TabIndex = 2;
            btnDeleteReason.Text = "Удалить";
            btnDeleteReason.UseVisualStyleBackColor = true;
            btnDeleteReason.Click += btnDeleteReason_Click;
            // 
            // btnEditReason
            // 
            btnEditReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditReason.Location = new Point(872, 7);
            btnEditReason.Name = "btnEditReason";
            btnEditReason.Size = new Size(139, 29);
            btnEditReason.TabIndex = 1;
            btnEditReason.Text = "Редактировать";
            btnEditReason.UseVisualStyleBackColor = true;
            btnEditReason.Click += btnEditReason_Click;
            // 
            // btnAddReason
            // 
            btnAddReason.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddReason.Location = new Point(772, 7);
            btnAddReason.Name = "btnAddReason";
            btnAddReason.Size = new Size(94, 29);
            btnAddReason.TabIndex = 0;
            btnAddReason.Text = "Добавить";
            btnAddReason.UseVisualStyleBackColor = true;
            btnAddReason.Click += btnAddReason_Click;
            // 
            // tabLib
            // 
            tabLib.Controls.Add(gridLibrarians);
            tabLib.Controls.Add(panel7);
            tabLib.Location = new Point(4, 32);
            tabLib.Name = "tabLib";
            tabLib.Size = new Size(1114, 629);
            tabLib.TabIndex = 5;
            tabLib.Text = "Сотрудники";
            tabLib.UseVisualStyleBackColor = true;
            // 
            // gridLibrarians
            // 
            gridLibrarians.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLibrarians.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLibrarians.Dock = DockStyle.Fill;
            gridLibrarians.Location = new Point(0, 42);
            gridLibrarians.MultiSelect = false;
            gridLibrarians.Name = "gridLibrarians";
            gridLibrarians.ReadOnly = true;
            gridLibrarians.RowHeadersVisible = false;
            gridLibrarians.RowHeadersWidth = 51;
            gridLibrarians.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLibrarians.Size = new Size(1114, 587);
            gridLibrarians.TabIndex = 0;
            gridLibrarians.CellFormatting += gridLibrarians_CellFormatting;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnDeleteLibrarian);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(txtSearchLibrarian);
            panel7.Controls.Add(btnEditLibrarian);
            panel7.Controls.Add(btnAddLibrarian);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1114, 42);
            panel7.TabIndex = 17;
            // 
            // btnDeleteLibrarian
            // 
            btnDeleteLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteLibrarian.Location = new Point(1016, 5);
            btnDeleteLibrarian.Name = "btnDeleteLibrarian";
            btnDeleteLibrarian.Size = new Size(95, 31);
            btnDeleteLibrarian.TabIndex = 3;
            btnDeleteLibrarian.Text = "Уволить";
            btnDeleteLibrarian.UseVisualStyleBackColor = true;
            btnDeleteLibrarian.Click += btnDeleteLibrarian_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 8);
            label9.Name = "label9";
            label9.Size = new Size(58, 23);
            label9.TabIndex = 15;
            label9.Text = "Поиск";
            // 
            // txtSearchLibrarian
            // 
            txtSearchLibrarian.Location = new Point(61, 5);
            txtSearchLibrarian.Name = "txtSearchLibrarian";
            txtSearchLibrarian.Size = new Size(267, 30);
            txtSearchLibrarian.TabIndex = 16;
            txtSearchLibrarian.TextChanged += txtSearchLibrarian_TextChanged;
            // 
            // btnEditLibrarian
            // 
            btnEditLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditLibrarian.Location = new Point(876, 5);
            btnEditLibrarian.Name = "btnEditLibrarian";
            btnEditLibrarian.Size = new Size(134, 31);
            btnEditLibrarian.TabIndex = 2;
            btnEditLibrarian.Text = "Редактировать";
            btnEditLibrarian.UseVisualStyleBackColor = true;
            btnEditLibrarian.Click += btnEditLibrarian_Click;
            // 
            // btnAddLibrarian
            // 
            btnAddLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddLibrarian.Location = new Point(773, 4);
            btnAddLibrarian.Name = "btnAddLibrarian";
            btnAddLibrarian.Size = new Size(97, 31);
            btnAddLibrarian.TabIndex = 1;
            btnAddLibrarian.Text = "Добавить";
            btnAddLibrarian.UseVisualStyleBackColor = true;
            btnAddLibrarian.Click += btnAddLibrarian_Click;
            // 
            // tabSpis
            // 
            tabSpis.Controls.Add(gridWriteOffs);
            tabSpis.Controls.Add(panel13);
            tabSpis.Controls.Add(panel12);
            tabSpis.Location = new Point(4, 32);
            tabSpis.Name = "tabSpis";
            tabSpis.Size = new Size(1114, 629);
            tabSpis.TabIndex = 9;
            tabSpis.Text = "Акты списаний";
            tabSpis.UseVisualStyleBackColor = true;
            // 
            // gridWriteOffs
            // 
            gridWriteOffs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWriteOffs.Dock = DockStyle.Fill;
            gridWriteOffs.Location = new Point(0, 47);
            gridWriteOffs.Name = "gridWriteOffs";
            gridWriteOffs.RowHeadersWidth = 51;
            gridWriteOffs.Size = new Size(1114, 531);
            gridWriteOffs.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.Controls.Add(lbWriteOffsTotal);
            panel13.Controls.Add(btnRestoreCopy);
            panel13.Dock = DockStyle.Bottom;
            panel13.Location = new Point(0, 578);
            panel13.Name = "panel13";
            panel13.Size = new Size(1114, 51);
            panel13.TabIndex = 1;
            // 
            // lbWriteOffsTotal
            // 
            lbWriteOffsTotal.AutoSize = true;
            lbWriteOffsTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbWriteOffsTotal.Location = new Point(16, 18);
            lbWriteOffsTotal.Name = "lbWriteOffsTotal";
            lbWriteOffsTotal.Size = new Size(114, 20);
            lbWriteOffsTotal.TabIndex = 1;
            lbWriteOffsTotal.Text = "Итого списано";
            // 
            // btnRestoreCopy
            // 
            btnRestoreCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestoreCopy.Location = new Point(906, 14);
            btnRestoreCopy.Name = "btnRestoreCopy";
            btnRestoreCopy.Size = new Size(200, 29);
            btnRestoreCopy.TabIndex = 0;
            btnRestoreCopy.Text = "Восстановить в фонд";
            btnRestoreCopy.UseVisualStyleBackColor = true;
            btnRestoreCopy.Click += btnRestoreCopy_Click;
            // 
            // panel12
            // 
            panel12.Controls.Add(label17);
            panel12.Controls.Add(label16);
            panel12.Controls.Add(btnFilterWriteOff);
            panel12.Controls.Add(dtpWriteOffEnd);
            panel12.Controls.Add(dtpWriteOffStart);
            panel12.Controls.Add(txtSearchWriteOff);
            panel12.Controls.Add(label15);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1114, 47);
            panel12.TabIndex = 0;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(506, 11);
            label17.Name = "label17";
            label17.Size = new Size(30, 23);
            label17.TabIndex = 6;
            label17.Text = "по";
            // 
            // label16
            // 
            label16.Location = new Point(349, 11);
            label16.Name = "label16";
            label16.Size = new Size(28, 25);
            label16.TabIndex = 5;
            label16.Text = "С";
            // 
            // btnFilterWriteOff
            // 
            btnFilterWriteOff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterWriteOff.Location = new Point(999, 8);
            btnFilterWriteOff.Name = "btnFilterWriteOff";
            btnFilterWriteOff.Size = new Size(107, 29);
            btnFilterWriteOff.TabIndex = 4;
            btnFilterWriteOff.Text = "Применить";
            btnFilterWriteOff.UseVisualStyleBackColor = true;
            btnFilterWriteOff.Click += btnFilterWriteOff_Click;
            // 
            // dtpWriteOffEnd
            // 
            dtpWriteOffEnd.Format = DateTimePickerFormat.Short;
            dtpWriteOffEnd.Location = new Point(549, 9);
            dtpWriteOffEnd.Name = "dtpWriteOffEnd";
            dtpWriteOffEnd.Size = new Size(119, 30);
            dtpWriteOffEnd.TabIndex = 3;
            // 
            // dtpWriteOffStart
            // 
            dtpWriteOffStart.Format = DateTimePickerFormat.Short;
            dtpWriteOffStart.Location = new Point(383, 9);
            dtpWriteOffStart.Name = "dtpWriteOffStart";
            dtpWriteOffStart.Size = new Size(117, 30);
            dtpWriteOffStart.TabIndex = 2;
            // 
            // txtSearchWriteOff
            // 
            txtSearchWriteOff.Location = new Point(72, 9);
            txtSearchWriteOff.Name = "txtSearchWriteOff";
            txtSearchWriteOff.Size = new Size(251, 30);
            txtSearchWriteOff.TabIndex = 1;
            txtSearchWriteOff.TextChanged += txtSearchWriteOff_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(8, 12);
            label15.Name = "label15";
            label15.Size = new Size(58, 23);
            label15.TabIndex = 0;
            label15.Text = "Поиск";
            // 
            // tabOtch
            // 
            tabOtch.Controls.Add(gridReports);
            tabOtch.Controls.Add(panel8);
            tabOtch.Location = new Point(4, 32);
            tabOtch.Name = "tabOtch";
            tabOtch.Size = new Size(1114, 629);
            tabOtch.TabIndex = 6;
            tabOtch.Text = "Отчёты";
            tabOtch.UseVisualStyleBackColor = true;
            // 
            // gridReports
            // 
            gridReports.AllowUserToAddRows = false;
            gridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReports.Dock = DockStyle.Fill;
            gridReports.Location = new Point(0, 43);
            gridReports.Name = "gridReports";
            gridReports.ReadOnly = true;
            gridReports.RowHeadersVisible = false;
            gridReports.RowHeadersWidth = 51;
            gridReports.Size = new Size(1114, 586);
            gridReports.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnExportReport);
            panel8.Controls.Add(btnGenerateReport);
            panel8.Controls.Add(cboReportType);
            panel8.Controls.Add(label2);
            panel8.Controls.Add(label1);
            panel8.Controls.Add(dtpReportStart);
            panel8.Controls.Add(label3);
            panel8.Controls.Add(dtpReportEnd);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1114, 43);
            panel8.TabIndex = 9;
            // 
            // btnExportReport
            // 
            btnExportReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportReport.Location = new Point(1012, 5);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(99, 35);
            btnExportReport.TabIndex = 7;
            btnExportReport.Text = "Экспорт";
            btnExportReport.UseVisualStyleBackColor = true;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerateReport.Location = new Point(864, 5);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(142, 35);
            btnGenerateReport.TabIndex = 6;
            btnGenerateReport.Text = "Сформировать";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // cboReportType
            // 
            cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReportType.FormattingEnabled = true;
            cboReportType.Items.AddRange(new object[] { "Статистика работы сотрудников", "Список должников", "Топ-20 популярных книг", "Неоплаченные штрафы", "Текущее состояние фонда", "Журнал списаний", "Журнал поставок" });
            cboReportType.Location = new Point(102, 8);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(308, 31);
            cboReportType.TabIndex = 1;
            cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 12);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 2;
            label2.Text = "Период: с";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(96, 23);
            label1.TabIndex = 0;
            label1.Text = "Вид отчёта";
            // 
            // dtpReportStart
            // 
            dtpReportStart.Format = DateTimePickerFormat.Short;
            dtpReportStart.Location = new Point(509, 7);
            dtpReportStart.Name = "dtpReportStart";
            dtpReportStart.Size = new Size(127, 30);
            dtpReportStart.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(642, 12);
            label3.Name = "label3";
            label3.Size = new Size(30, 23);
            label3.TabIndex = 4;
            label3.Text = "по";
            // 
            // dtpReportEnd
            // 
            dtpReportEnd.Format = DateTimePickerFormat.Short;
            dtpReportEnd.Location = new Point(678, 7);
            dtpReportEnd.Name = "dtpReportEnd";
            dtpReportEnd.Size = new Size(135, 30);
            dtpReportEnd.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtBackupLog);
            tabPage1.Controls.Add(panel14);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1114, 629);
            tabPage1.TabIndex = 10;
            tabPage1.Text = "Управление БД";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBackupLog
            // 
            txtBackupLog.Dock = DockStyle.Fill;
            txtBackupLog.Location = new Point(0, 37);
            txtBackupLog.Multiline = true;
            txtBackupLog.Name = "txtBackupLog";
            txtBackupLog.ReadOnly = true;
            txtBackupLog.ScrollBars = ScrollBars.Vertical;
            txtBackupLog.Size = new Size(1114, 592);
            txtBackupLog.TabIndex = 4;
            // 
            // panel14
            // 
            panel14.Controls.Add(btnRestore);
            panel14.Controls.Add(btnBackup);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(1114, 37);
            panel14.TabIndex = 5;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestore.Location = new Point(886, 5);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(220, 29);
            btnRestore.TabIndex = 6;
            btnRestore.Text = "Восстановить из файла";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // btnBackup
            // 
            btnBackup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackup.Location = new Point(620, 5);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(260, 29);
            btnBackup.TabIndex = 5;
            btnBackup.Text = "Создать резервную копию";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnLogout.Location = new Point(1014, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 27);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btnChangePassword);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1122, 37);
            panel1.TabIndex = 1;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.BackColor = Color.White;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnChangePassword.Location = new Point(814, 3);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(180, 28);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "Сменить пароль";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 702);
            Controls.Add(txt);
            Controls.Add(panel1);
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АИС \"Библиотека\": Кабинет администоратора";
            FormClosing += AdminMainForm_FormClosing;
            txt.ResumeLayout(false);
            tabIzd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPublishers).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabAut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAuthors).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridGenres).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFines).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabFine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAllFines).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            tabReas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReasons).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabLib.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridLibrarians).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            tabSpis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridWriteOffs).EndInit();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            tabOtch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReports).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel14.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl txt;
        private TabPage tabGenres;
        private DataGridView gridGenres;
        private TabPage tabIzd;
        private TabPage tabAut;
        private Button btnDeleteGenre;
        private Button btnAddGenre;
        private DataGridView gridPublishers;
        private Button btnDeletePublisher;
        private Button btnAddPublisher;
        private DataGridView gridAuthors;
        private Button btnDeleteAuthor;
        private Button btnAddAuthor;
        private Button btnEditAuthor;
        private Button btnEditGenre;
        private Button btnEditPublish;
        private TabPage tabState;
        private DataGridView gridFines;
        private Button btnEditFine;
        private Button btnDeleteFine;
        private Button btnAddFine;
        private TabPage tabLib;
        private Button btnDeleteLibrarian;
        private Button btnEditLibrarian;
        private Button btnAddLibrarian;
        private DataGridView gridLibrarians;
        private Button btnLogout;
        private Panel panel1;
        private TabPage tabPost;
        private Button btnEditSupplier;
        private Button btnDeleteSupplier;
        private Button btnAddSupplier;
        private DataGridView gridSuppliers;
        private Button btnChangePassword;
        private TabPage tabOtch;
        private ComboBox cboReportType;
        private Label label1;
        private DateTimePicker dtpReportStart;
        private Label label2;
        private DataGridView gridReports;
        private Button btnExportReport;
        private Button btnGenerateReport;
        private DateTimePicker dtpReportEnd;
        private Label label3;
        private Panel panel2;
        private TextBox txtSearchGenre;
        private Label label4;
        private Panel panel3;
        private TextBox txtSearchPublisher;
        private Label label5;
        private Label label6;
        private TextBox txtSearchAuthor;
        private TextBox txtSearchSupplier;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel4;
        private Panel panel5;
        private TextBox txtSearchFine;
        private TextBox txtSearchLibrarian;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private TabPage tabReas;
        private DataGridView gridReasons;
        private Panel panel9;
        private TextBox txtSearchReason;
        private Label label10;
        private Button btnDeleteReason;
        private Button btnEditReason;
        private Button btnAddReason;
        private TabPage tabFine;
        private Panel panel11;
        private Panel panel10;
        private Label label13;
        private Label label12;
        private TextBox txtSearFine;
        private Label label11;
        private DataGridView gridAllFines;
        private Button btnAnnulFine;
        private Button btnFilter;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Label label14;
        private ComboBox cboFineStatus;
        private Label lblTotal;
        private TabPage tabSpis;
        private DataGridView gridWriteOffs;
        private Panel panel13;
        private Panel panel12;
        private Label label17;
        private Label label16;
        private Button btnFilterWriteOff;
        private DateTimePicker dtpWriteOffEnd;
        private DateTimePicker dtpWriteOffStart;
        private TextBox txtSearchWriteOff;
        private Label label15;
        private Label lbWriteOffsTotal;
        private Button btnRestoreCopy;
        private Button btnEditAmount;
        private TabPage tabPage1;
        private TextBox txtBackupLog;
        private Panel panel14;
        private Button btnRestore;
        private Button btnBackup;
    }
}