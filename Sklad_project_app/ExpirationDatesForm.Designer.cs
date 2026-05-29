namespace Sklad_project_app
{
    partial class ExpirationDatesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblCompany = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            panelLeft = new Panel();
            btnHistory = new Button();
            btnCurrency = new Button();
            btnWrittenOff = new Button();
            btnExpirationDates = new Button();
            btnReports = new Button();
            btnSuplies = new Button();
            btnCatalog = new Button();
            btnHeatMap = new Button();
            btnBlacklist = new Button();
            panelActions = new Panel();
            btnWriteOff = new Button();
            btnRefresh = new Button();
            panelFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblDiscount = new Label();
            cmbDiscount = new ComboBox();
            lblFound = new Label();
            btnReset = new Button();
            dgvExpiry = new DataGridView();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpiry).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(30, 100, 200);
            panelTop.Controls.Add(lblCompany);
            panelTop.Controls.Add(lblUserInfo);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1100, 35);
            panelTop.TabIndex = 0;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblCompany.ForeColor = Color.White;
            lblCompany.Location = new Point(10, 8);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(463, 19);
            lblCompany.TabIndex = 0;
            lblCompany.Text = "ООО \"Птички-тупички\" - система управления складом";
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Arial", 9F);
            lblUserInfo.ForeColor = Color.White;
            lblUserInfo.Location = new Point(664, 8);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(88, 17);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Кладовщик:";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(210, 220, 235);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(1018, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(70, 30);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelLeft
            // 
            panelLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelLeft.BackColor = Color.FromArgb(240, 240, 240);
            panelLeft.BorderStyle = BorderStyle.FixedSingle;
            panelLeft.Controls.Add(btnHistory);
            panelLeft.Controls.Add(btnCurrency);
            panelLeft.Controls.Add(btnWrittenOff);
            panelLeft.Controls.Add(btnExpirationDates);
            panelLeft.Controls.Add(btnReports);
            panelLeft.Controls.Add(btnSuplies);
            panelLeft.Controls.Add(btnCatalog);
            panelLeft.Controls.Add(btnHeatMap);
            panelLeft.Controls.Add(btnBlacklist);
            panelLeft.Location = new Point(0, 35);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(140, 565);
            panelLeft.TabIndex = 1;
            // 
            // btnHistory
            // 
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(5, 48);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(128, 30);
            btnHistory.TabIndex = 12;
            btnHistory.Text = "История отгрузок";
            btnHistory.Click += btnHistory_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.ImageAlign = ContentAlignment.TopCenter;
            btnCurrency.Location = new Point(5, 229);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Size = new Size(128, 30);
            btnCurrency.TabIndex = 11;
            btnCurrency.Text = "Валюта";
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnWrittenOff
            // 
            btnWrittenOff.FlatStyle = FlatStyle.Flat;
            btnWrittenOff.ImageAlign = ContentAlignment.TopCenter;
            btnWrittenOff.Location = new Point(5, 194);
            btnWrittenOff.Name = "btnWrittenOff";
            btnWrittenOff.Size = new Size(129, 30);
            btnWrittenOff.TabIndex = 8;
            btnWrittenOff.Text = "Списанное";
            btnWrittenOff.Click += btnWrittenOff_Click;
            // 
            // btnExpirationDates
            // 
            btnExpirationDates.FlatStyle = FlatStyle.Flat;
            btnExpirationDates.ImageAlign = ContentAlignment.TopCenter;
            btnExpirationDates.Location = new Point(5, 158);
            btnExpirationDates.Name = "btnExpirationDates";
            btnExpirationDates.Size = new Size(129, 30);
            btnExpirationDates.TabIndex = 5;
            btnExpirationDates.Text = "Сроки годности";
            btnExpirationDates.Click += btnExpirationDates_Click;
            // 
            // btnReports
            // 
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.ImageAlign = ContentAlignment.TopCenter;
            btnReports.Location = new Point(6, 122);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(128, 30);
            btnReports.TabIndex = 4;
            btnReports.Text = "Отчеты";
            btnReports.Click += btnReports_Click;
            // 
            // btnSuplies
            // 
            btnSuplies.FlatStyle = FlatStyle.Flat;
            btnSuplies.Location = new Point(5, 86);
            btnSuplies.Name = "btnSuplies";
            btnSuplies.Size = new Size(128, 30);
            btnSuplies.TabIndex = 3;
            btnSuplies.Text = "Поставки";
            btnSuplies.Click += btnSuplies_Click;
            // 
            // btnCatalog
            // 
            btnCatalog.BackColor = Color.FromArgb(30, 100, 200);
            btnCatalog.FlatStyle = FlatStyle.Flat;
            btnCatalog.ForeColor = Color.White;
            btnCatalog.Location = new Point(5, 10);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Size = new Size(128, 30);
            btnCatalog.TabIndex = 0;
            btnCatalog.Text = "Каталог";
            btnCatalog.UseVisualStyleBackColor = false;
            btnCatalog.Click += btnCatalog_Click;
            // 
            // btnHeatMap
            // 
            btnHeatMap.FlatStyle = FlatStyle.Flat;
            btnHeatMap.Location = new Point(5, 301);
            btnHeatMap.Name = "btnHeatMap";
            btnHeatMap.Size = new Size(128, 30);
            btnHeatMap.TabIndex = 11;
            btnHeatMap.Text = "Тепловая карта";
            btnHeatMap.Click += btnHeatMap_Click;
            // 
            // btnBlacklist
            // 
            btnBlacklist.FlatStyle = FlatStyle.Flat;
            btnBlacklist.Location = new Point(6, 265);
            btnBlacklist.Name = "btnBlacklist";
            btnBlacklist.Size = new Size(128, 30);
            btnBlacklist.TabIndex = 12;
            btnBlacklist.Text = "Черный список";
            btnBlacklist.Click += btnBlacklist_Click;
            // 
            // panelActions
            // 
            panelActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelActions.AutoSize = true;
            panelActions.BackColor = Color.FromArgb(50, 50, 50);
            panelActions.Controls.Add(btnWriteOff);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Location = new Point(140, 35);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(960, 45);
            panelActions.TabIndex = 2;
            // 
            // btnWriteOff
            // 
            btnWriteOff.BackColor = Color.FromArgb(70, 70, 70);
            btnWriteOff.FlatStyle = FlatStyle.Flat;
            btnWriteOff.ForeColor = Color.White;
            btnWriteOff.Location = new Point(144, 8);
            btnWriteOff.Name = "btnWriteOff";
            btnWriteOff.Size = new Size(121, 28);
            btnWriteOff.TabIndex = 6;
            btnWriteOff.Text = "Списать";
            btnWriteOff.UseVisualStyleBackColor = false;
            btnWriteOff.Click += btnWriteOff_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(70, 70, 70);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(14, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(121, 28);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelFilters
            // 
            panelFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFilters.AutoSize = true;
            panelFilters.BackColor = Color.FromArgb(230, 235, 245);
            panelFilters.Controls.Add(lblSearch);
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(lblDiscount);
            panelFilters.Controls.Add(cmbDiscount);
            panelFilters.Controls.Add(lblFound);
            panelFilters.Controls.Add(btnReset);
            panelFilters.Location = new Point(140, 80);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(960, 102);
            panelFilters.TabIndex = 3;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Arial", 8F);
            lblSearch.Location = new Point(10, 8);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(124, 16);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск (название):";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Arial", 8F);
            lblDiscount.Location = new Point(209, 8);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(57, 16);
            lblDiscount.TabIndex = 4;
            lblDiscount.Text = "Скидка:";
            // 
            // cmbDiscount
            // 
            cmbDiscount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiscount.Location = new Point(209, 25);
            cmbDiscount.Name = "cmbDiscount";
            cmbDiscount.Size = new Size(130, 28);
            cmbDiscount.TabIndex = 5;
            cmbDiscount.SelectedIndexChanged += cmbDate_SelectedIndexChanged;
            // 
            // lblFound
            // 
            lblFound.AutoSize = true;
            lblFound.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblFound.Location = new Point(10, 69);
            lblFound.Name = "lblFound";
            lblFound.Size = new Size(121, 18);
            lblFound.TabIndex = 9;
            lblFound.Text = "Найдено: 0 из 0";
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(149, 61);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 33);
            btnReset.TabIndex = 10;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvExpiry
            // 
            dgvExpiry.AllowUserToAddRows = false;
            dgvExpiry.AllowUserToDeleteRows = false;
            dgvExpiry.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExpiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpiry.BackgroundColor = Color.White;
            dgvExpiry.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvExpiry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvExpiry.ColumnHeadersHeight = 29;
            dgvExpiry.EnableHeadersVisualStyles = false;
            dgvExpiry.Location = new Point(140, 180);
            dgvExpiry.MultiSelect = false;
            dgvExpiry.Name = "dgvExpiry";
            dgvExpiry.ReadOnly = true;
            dgvExpiry.RowHeadersVisible = false;
            dgvExpiry.RowHeadersWidth = 51;
            dgvExpiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpiry.Size = new Size(960, 420);
            dgvExpiry.TabIndex = 5;
            // 
            // ExpirationDatesForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelActions);
            Controls.Add(panelFilters);
            Controls.Add(dgvExpiry);
            Name = "ExpirationDatesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сроки годности";
            WindowState = FormWindowState.Maximized;
            Load += SuppliesCatalogForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpiry).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvExpiry;
        private Button btnSuplies;
        private Button btnReports;
        private Button btnExpirationDates;
        private Button btnWriteOff;
        private Button btnWrittenOff;
        private Button btnCurrency;
        private Button btnHistory;
        private Button btnHeatMap;
        private Button btnBlacklist;

    }
}