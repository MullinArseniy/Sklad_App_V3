namespace Sklad_project_app
{
    partial class WriteOffHistoryForm
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
            btnShipment = new Button();
            btnMyShipments = new Button();
            btnHeatMap = new Button();
            btnBlacklist = new Button();
            panelActions = new Panel();
            btnRefresh = new Button();
            panelFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDate = new Label();
            cmbDate = new ComboBox();
            lblPrice = new Label();
            txtLossFrom = new TextBox();
            txtLossTo = new TextBox();
            lblFound = new Label();
            btnReset = new Button();
            dgvWriteOffs = new DataGridView();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWriteOffs).BeginInit();
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
            panelLeft.Controls.Add(btnShipment);
            panelLeft.Controls.Add(btnMyShipments);
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
            btnHistory.Location = new Point(7, 302);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(128, 30);
            btnHistory.TabIndex = 11;
            btnHistory.Text = "История отгрузок";
            btnHistory.Click += btnHistory_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.ImageAlign = ContentAlignment.TopCenter;
            btnCurrency.Location = new Point(6, 266);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Size = new Size(128, 30);
            btnCurrency.TabIndex = 10;
            btnCurrency.Text = "Валюта";
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnWrittenOff
            // 
            btnWrittenOff.FlatStyle = FlatStyle.Flat;
            btnWrittenOff.ImageAlign = ContentAlignment.TopCenter;
            btnWrittenOff.Location = new Point(5, 230);
            btnWrittenOff.Name = "btnWrittenOff";
            btnWrittenOff.Size = new Size(129, 30);
            btnWrittenOff.TabIndex = 9;
            btnWrittenOff.Text = "Списанное";
            btnWrittenOff.Click += btnWrittenOff_Click;
            // 
            // btnExpirationDates
            // 
            btnExpirationDates.FlatStyle = FlatStyle.Flat;
            btnExpirationDates.ImageAlign = ContentAlignment.TopCenter;
            btnExpirationDates.Location = new Point(5, 194);
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
            btnReports.Location = new Point(6, 158);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(128, 30);
            btnReports.TabIndex = 4;
            btnReports.Text = "Отчеты";
            btnReports.Click += btnReports_Click;
            // 
            // btnSuplies
            // 
            btnSuplies.FlatStyle = FlatStyle.Flat;
            btnSuplies.Location = new Point(5, 122);
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
            // btnShipment
            // 
            btnShipment.FlatStyle = FlatStyle.Flat;
            btnShipment.Location = new Point(5, 48);
            btnShipment.Name = "btnShipment";
            btnShipment.Size = new Size(128, 30);
            btnShipment.TabIndex = 1;
            btnShipment.Text = "Отгрузка";
            btnShipment.Click += btnShipment_Click;
            // 
            // btnMyShipments
            // 
            btnMyShipments.FlatStyle = FlatStyle.Flat;
            btnMyShipments.Location = new Point(5, 86);
            btnMyShipments.Name = "btnMyShipments";
            btnMyShipments.Size = new Size(128, 30);
            btnMyShipments.TabIndex = 2;
            btnMyShipments.Text = "Мои отгрузки";
            btnMyShipments.Click += btnMyShipments_Click;
            // 
            // btnHeatMap
            // 
            btnHeatMap.FlatStyle = FlatStyle.Flat;
            btnHeatMap.Location = new Point(6, 374);
            btnHeatMap.Name = "btnHeatMap";
            btnHeatMap.Size = new Size(128, 30);
            btnHeatMap.TabIndex = 11;
            btnHeatMap.Text = "Тепловая карта";
            btnHeatMap.Click += btnHeatMap_Click;
            // 
            // btnBlacklist
            // 
            btnBlacklist.FlatStyle = FlatStyle.Flat;
            btnBlacklist.Location = new Point(7, 338);
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
            panelActions.Controls.Add(btnRefresh);
            panelActions.Location = new Point(140, 35);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(960, 45);
            panelActions.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(70, 70, 70);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(10, 6);
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
            panelFilters.Controls.Add(lblCategory);
            panelFilters.Controls.Add(cmbCategory);
            panelFilters.Controls.Add(lblDate);
            panelFilters.Controls.Add(cmbDate);
            panelFilters.Controls.Add(lblPrice);
            panelFilters.Controls.Add(txtLossFrom);
            panelFilters.Controls.Add(txtLossTo);
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
            lblSearch.Size = new Size(188, 16);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск (название / артикул):";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Arial", 8F);
            lblCategory.Location = new Point(204, 8);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 16);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(204, 25);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(160, 28);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial", 8F);
            lblDate.Location = new Point(379, 8);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(43, 16);
            lblDate.TabIndex = 4;
            lblDate.Text = "Дата:";
            // 
            // cmbDate
            // 
            cmbDate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDate.Location = new Point(379, 25);
            cmbDate.Name = "cmbDate";
            cmbDate.Size = new Size(130, 28);
            cmbDate.TabIndex = 5;
            cmbDate.SelectedIndexChanged += cmbDate_SelectedIndexChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Arial", 8F);
            lblPrice.Location = new Point(524, 8);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(45, 16);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Цена:";
            // 
            // txtLossFrom
            // 
            txtLossFrom.Location = new Point(524, 25);
            txtLossFrom.Name = "txtLossFrom";
            txtLossFrom.Size = new Size(70, 27);
            txtLossFrom.TabIndex = 7;
            txtLossFrom.Text = "0";
            // 
            // txtLossTo
            // 
            txtLossTo.Location = new Point(604, 25);
            txtLossTo.Name = "txtLossTo";
            txtLossTo.Size = new Size(70, 27);
            txtLossTo.TabIndex = 8;
            txtLossTo.Text = "1000000";
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
            // dgvWriteOffs
            // 
            dgvWriteOffs.AllowUserToAddRows = false;
            dgvWriteOffs.AllowUserToDeleteRows = false;
            dgvWriteOffs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvWriteOffs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWriteOffs.BackgroundColor = Color.White;
            dgvWriteOffs.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWriteOffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWriteOffs.ColumnHeadersHeight = 29;
            dgvWriteOffs.EnableHeadersVisualStyles = false;
            dgvWriteOffs.Location = new Point(140, 180);
            dgvWriteOffs.MultiSelect = false;
            dgvWriteOffs.Name = "dgvWriteOffs";
            dgvWriteOffs.ReadOnly = true;
            dgvWriteOffs.RowHeadersVisible = false;
            dgvWriteOffs.RowHeadersWidth = 51;
            dgvWriteOffs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWriteOffs.Size = new Size(960, 420);
            dgvWriteOffs.TabIndex = 5;
            // 
            // WriteOffHistoryForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelActions);
            Controls.Add(panelFilters);
            Controls.Add(dgvWriteOffs);
            Name = "WriteOffHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Списанное";
            WindowState = FormWindowState.Maximized;
            Load += SuppliesCatalogForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWriteOffs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.Button btnMyShipments;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtLossFrom;
        private System.Windows.Forms.TextBox txtLossTo;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvWriteOffs;
        private Button btnSuplies;
        private Button btnReports;
        private Button btnExpirationDates;
        private Button btnWrittenOff;
        private Button btnCurrency;
        private Button btnHistory;
        private Button btnHeatMap;
        private Button btnBlacklist;
    }
}