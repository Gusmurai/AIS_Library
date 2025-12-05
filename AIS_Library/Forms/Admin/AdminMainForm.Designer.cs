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
            tabPage1 = new TabPage();
            gridGenres = new DataGridView();
            panel2 = new Panel();
            txtSearchGenre = new TextBox();
            label4 = new Label();
            btnAddGenre = new Button();
            btnEditGenre = new Button();
            btnDeleteGenre = new Button();
            tabPage2 = new TabPage();
            gridPublishers = new DataGridView();
            panel3 = new Panel();
            txtSearchPublisher = new TextBox();
            label5 = new Label();
            btnDeletePublisher = new Button();
            btnAddPublisher = new Button();
            btnEditPublish = new Button();
            tabPage3 = new TabPage();
            gridAuthors = new DataGridView();
            panel4 = new Panel();
            label6 = new Label();
            txtSearchAuthor = new TextBox();
            btnDeleteAuthor = new Button();
            btnAddAuthor = new Button();
            btnEditAuthor = new Button();
            tabPage4 = new TabPage();
            gridSuppliers = new DataGridView();
            panel5 = new Panel();
            label7 = new Label();
            txtSearchSupplier = new TextBox();
            btnDeleteSupplier = new Button();
            btnAddSupplier = new Button();
            btnEditSupplier = new Button();
            tabPage5 = new TabPage();
            gridFines = new DataGridView();
            panel6 = new Panel();
            btnEditFine = new Button();
            label8 = new Label();
            txtSearchFine = new TextBox();
            btnDeleteFine = new Button();
            btnAddFine = new Button();
            tabPage6 = new TabPage();
            gridLibrarians = new DataGridView();
            panel7 = new Panel();
            btnDeleteLibrarian = new Button();
            label9 = new Label();
            txtSearchLibrarian = new TextBox();
            btnEditLibrarian = new Button();
            btnAddLibrarian = new Button();
            tabPage7 = new TabPage();
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
            btnLogout = new Button();
            panel1 = new Panel();
            btnChangePassword = new Button();
            txt.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridGenres).BeginInit();
            panel2.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPublishers).BeginInit();
            panel3.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAuthors).BeginInit();
            panel4.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).BeginInit();
            panel5.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFines).BeginInit();
            panel6.SuspendLayout();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLibrarians).BeginInit();
            panel7.SuspendLayout();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridReports).BeginInit();
            panel8.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txt
            // 
            txt.Controls.Add(tabPage1);
            txt.Controls.Add(tabPage2);
            txt.Controls.Add(tabPage3);
            txt.Controls.Add(tabPage4);
            txt.Controls.Add(tabPage5);
            txt.Controls.Add(tabPage6);
            txt.Controls.Add(tabPage7);
            txt.Dock = DockStyle.Fill;
            txt.Location = new Point(0, 31);
            txt.Name = "txt";
            txt.SelectedIndex = 0;
            txt.Size = new Size(1122, 671);
            txt.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gridGenres);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1114, 638);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Жанры";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridGenres
            // 
            gridGenres.AllowUserToAddRows = false;
            gridGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridGenres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGenres.Dock = DockStyle.Fill;
            gridGenres.Location = new Point(3, 38);
            gridGenres.MultiSelect = false;
            gridGenres.Name = "gridGenres";
            gridGenres.ReadOnly = true;
            gridGenres.RowHeadersVisible = false;
            gridGenres.RowHeadersWidth = 51;
            gridGenres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridGenres.Size = new Size(1108, 597);
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
            panel2.Size = new Size(1108, 35);
            panel2.TabIndex = 14;
            // 
            // txtSearchGenre
            // 
            txtSearchGenre.Location = new Point(61, 6);
            txtSearchGenre.Name = "txtSearchGenre";
            txtSearchGenre.Size = new Size(269, 27);
            txtSearchGenre.TabIndex = 15;
            txtSearchGenre.TextChanged += txtSearchGenre_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
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
            btnEditGenre.Location = new Point(871, 2);
            btnEditGenre.Name = "btnEditGenre";
            btnEditGenre.Size = new Size(139, 32);
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
            // tabPage2
            // 
            tabPage2.Controls.Add(gridPublishers);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1114, 638);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Издательства";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridPublishers
            // 
            gridPublishers.AllowUserToAddRows = false;
            gridPublishers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPublishers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPublishers.Dock = DockStyle.Fill;
            gridPublishers.Location = new Point(3, 37);
            gridPublishers.Name = "gridPublishers";
            gridPublishers.ReadOnly = true;
            gridPublishers.RowHeadersVisible = false;
            gridPublishers.RowHeadersWidth = 51;
            gridPublishers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridPublishers.Size = new Size(1108, 598);
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
            panel3.Size = new Size(1108, 34);
            panel3.TabIndex = 14;
            // 
            // txtSearchPublisher
            // 
            txtSearchPublisher.Location = new Point(61, 5);
            txtSearchPublisher.Name = "txtSearchPublisher";
            txtSearchPublisher.Size = new Size(267, 27);
            txtSearchPublisher.TabIndex = 15;
            txtSearchPublisher.TextChanged += txtSearchPublisher_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 7);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 14;
            label5.Text = "Поиск";
            // 
            // btnDeletePublisher
            // 
            btnDeletePublisher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeletePublisher.Location = new Point(1014, 2);
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
            btnAddPublisher.Location = new Point(766, 2);
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
            btnEditPublish.Location = new Point(866, 2);
            btnEditPublish.Name = "btnEditPublish";
            btnEditPublish.Size = new Size(142, 31);
            btnEditPublish.TabIndex = 13;
            btnEditPublish.Text = "Редактировать";
            btnEditPublish.UseVisualStyleBackColor = true;
            btnEditPublish.Click += btnEditPublish_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(gridAuthors);
            tabPage3.Controls.Add(panel4);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1114, 638);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Авторы";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridAuthors
            // 
            gridAuthors.AllowUserToAddRows = false;
            gridAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAuthors.Dock = DockStyle.Fill;
            gridAuthors.Location = new Point(0, 36);
            gridAuthors.Name = "gridAuthors";
            gridAuthors.ReadOnly = true;
            gridAuthors.RowHeadersVisible = false;
            gridAuthors.RowHeadersWidth = 51;
            gridAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAuthors.Size = new Size(1114, 602);
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
            panel4.Size = new Size(1114, 36);
            panel4.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 10);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 14;
            label6.Text = "Поиск";
            // 
            // txtSearchAuthor
            // 
            txtSearchAuthor.Location = new Point(61, 7);
            txtSearchAuthor.Name = "txtSearchAuthor";
            txtSearchAuthor.Size = new Size(266, 27);
            txtSearchAuthor.TabIndex = 13;
            txtSearchAuthor.TextChanged += txtSearchAuthor_TextChanged;
            // 
            // btnDeleteAuthor
            // 
            btnDeleteAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteAuthor.Location = new Point(1017, 4);
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
            btnAddAuthor.Location = new Point(774, 4);
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
            btnEditAuthor.Location = new Point(874, 4);
            btnEditAuthor.Name = "btnEditAuthor";
            btnEditAuthor.Size = new Size(137, 29);
            btnEditAuthor.TabIndex = 12;
            btnEditAuthor.Text = "Редактировать";
            btnEditAuthor.UseVisualStyleBackColor = true;
            btnEditAuthor.Click += btnEditAuthor_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(gridSuppliers);
            tabPage4.Controls.Add(panel5);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1114, 638);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Поставщики";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridSuppliers
            // 
            gridSuppliers.AllowUserToAddRows = false;
            gridSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSuppliers.Dock = DockStyle.Fill;
            gridSuppliers.Location = new Point(3, 37);
            gridSuppliers.MultiSelect = false;
            gridSuppliers.Name = "gridSuppliers";
            gridSuppliers.ReadOnly = true;
            gridSuppliers.RowHeadersVisible = false;
            gridSuppliers.RowHeadersWidth = 51;
            gridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSuppliers.Size = new Size(1108, 598);
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
            panel5.Size = new Size(1108, 34);
            panel5.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 8);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 15;
            label7.Text = "Поиск";
            // 
            // txtSearchSupplier
            // 
            txtSearchSupplier.Location = new Point(61, 4);
            txtSearchSupplier.Name = "txtSearchSupplier";
            txtSearchSupplier.Size = new Size(263, 27);
            txtSearchSupplier.TabIndex = 16;
            txtSearchSupplier.TextChanged += txtSearchSupplier_TextChanged;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteSupplier.Location = new Point(1016, 2);
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
            btnAddSupplier.Location = new Point(766, 0);
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
            btnEditSupplier.Location = new Point(866, 0);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(145, 34);
            btnEditSupplier.TabIndex = 13;
            btnEditSupplier.Text = "Редактировать";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(gridFines);
            tabPage5.Controls.Add(panel6);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1114, 638);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Штрафные статьи";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // gridFines
            // 
            gridFines.AllowUserToAddRows = false;
            gridFines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridFines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFines.Dock = DockStyle.Fill;
            gridFines.Location = new Point(0, 38);
            gridFines.MultiSelect = false;
            gridFines.Name = "gridFines";
            gridFines.ReadOnly = true;
            gridFines.RowHeadersVisible = false;
            gridFines.RowHeadersWidth = 51;
            gridFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridFines.Size = new Size(1114, 600);
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
            panel6.Size = new Size(1114, 38);
            panel6.TabIndex = 17;
            // 
            // btnEditFine
            // 
            btnEditFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditFine.Location = new Point(887, 3);
            btnEditFine.Name = "btnEditFine";
            btnEditFine.Size = new Size(124, 32);
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
            label8.Size = new Size(52, 20);
            label8.TabIndex = 15;
            label8.Text = "Поиск";
            // 
            // txtSearchFine
            // 
            txtSearchFine.Location = new Point(58, 8);
            txtSearchFine.Name = "txtSearchFine";
            txtSearchFine.Size = new Size(270, 27);
            txtSearchFine.TabIndex = 16;
            txtSearchFine.TextChanged += txtSearchFine_TextChanged;
            // 
            // btnDeleteFine
            // 
            btnDeleteFine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteFine.Location = new Point(1017, 3);
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
            btnAddFine.Location = new Point(787, 3);
            btnAddFine.Name = "btnAddFine";
            btnAddFine.Size = new Size(94, 32);
            btnAddFine.TabIndex = 7;
            btnAddFine.Text = "Добавить";
            btnAddFine.UseVisualStyleBackColor = true;
            btnAddFine.Click += btnAddFine_Click;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(gridLibrarians);
            tabPage6.Controls.Add(panel7);
            tabPage6.Location = new Point(4, 29);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1114, 638);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Сотрудники";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // gridLibrarians
            // 
            gridLibrarians.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLibrarians.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLibrarians.Dock = DockStyle.Fill;
            gridLibrarians.Location = new Point(0, 35);
            gridLibrarians.MultiSelect = false;
            gridLibrarians.Name = "gridLibrarians";
            gridLibrarians.ReadOnly = true;
            gridLibrarians.RowHeadersVisible = false;
            gridLibrarians.RowHeadersWidth = 51;
            gridLibrarians.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLibrarians.Size = new Size(1114, 603);
            gridLibrarians.TabIndex = 0;
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
            panel7.Size = new Size(1114, 35);
            panel7.TabIndex = 17;
            // 
            // btnDeleteLibrarian
            // 
            btnDeleteLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteLibrarian.Location = new Point(1016, 2);
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
            label9.Size = new Size(52, 20);
            label9.TabIndex = 15;
            label9.Text = "Поиск";
            // 
            // txtSearchLibrarian
            // 
            txtSearchLibrarian.Location = new Point(61, 5);
            txtSearchLibrarian.Name = "txtSearchLibrarian";
            txtSearchLibrarian.Size = new Size(267, 27);
            txtSearchLibrarian.TabIndex = 16;
            txtSearchLibrarian.TextChanged += txtSearchLibrarian_TextChanged;
            // 
            // btnEditLibrarian
            // 
            btnEditLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditLibrarian.Location = new Point(891, 3);
            btnEditLibrarian.Name = "btnEditLibrarian";
            btnEditLibrarian.Size = new Size(119, 31);
            btnEditLibrarian.TabIndex = 2;
            btnEditLibrarian.Text = "Редактировать";
            btnEditLibrarian.UseVisualStyleBackColor = true;
            btnEditLibrarian.Click += btnEditLibrarian_Click;
            // 
            // btnAddLibrarian
            // 
            btnAddLibrarian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddLibrarian.Location = new Point(788, 3);
            btnAddLibrarian.Name = "btnAddLibrarian";
            btnAddLibrarian.Size = new Size(97, 31);
            btnAddLibrarian.TabIndex = 1;
            btnAddLibrarian.Text = "Добавить";
            btnAddLibrarian.UseVisualStyleBackColor = true;
            btnAddLibrarian.Click += btnAddLibrarian_Click;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(gridReports);
            tabPage7.Controls.Add(panel8);
            tabPage7.Location = new Point(4, 29);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1114, 638);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Отчёты";
            tabPage7.UseVisualStyleBackColor = true;
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
            gridReports.Size = new Size(1114, 595);
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
            cboReportType.Items.AddRange(new object[] { "Статистика работы сотрудников", "Список должников", "Рейтинг популярных книг" });
            cboReportType.Location = new Point(90, 7);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(236, 28);
            cboReportType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 15);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "Период: с";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "Вид отчёта";
            // 
            // dtpReportStart
            // 
            dtpReportStart.Format = DateTimePickerFormat.Short;
            dtpReportStart.Location = new Point(434, 10);
            dtpReportStart.Name = "dtpReportStart";
            dtpReportStart.Size = new Size(105, 27);
            dtpReportStart.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(545, 15);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 4;
            label3.Text = "по";
            // 
            // dtpReportEnd
            // 
            dtpReportEnd.Format = DateTimePickerFormat.Short;
            dtpReportEnd.Location = new Point(578, 10);
            dtpReportEnd.Name = "dtpReportEnd";
            dtpReportEnd.Size = new Size(103, 27);
            dtpReportEnd.TabIndex = 5;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(1023, 3);
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
            panel1.Size = new Size(1122, 31);
            panel1.TabIndex = 1;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangePassword.BackColor = Color.White;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Location = new Point(873, 2);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(144, 28);
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
            txt.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridGenres).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPublishers).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAuthors).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFines).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridLibrarians).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridReports).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl txt;
        private TabPage tabPage1;
        private DataGridView gridGenres;
        private TabPage tabPage2;
        private TabPage tabPage3;
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
        private TabPage tabPage5;
        private DataGridView gridFines;
        private Button btnEditFine;
        private Button btnDeleteFine;
        private Button btnAddFine;
        private TabPage tabPage6;
        private Button btnDeleteLibrarian;
        private Button btnEditLibrarian;
        private Button btnAddLibrarian;
        private DataGridView gridLibrarians;
        private Button btnLogout;
        private Panel panel1;
        private TabPage tabPage4;
        private Button btnEditSupplier;
        private Button btnDeleteSupplier;
        private Button btnAddSupplier;
        private DataGridView gridSuppliers;
        private Button btnChangePassword;
        private TabPage tabPage7;
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
    }
}