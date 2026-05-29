namespace Sklad_project_app
{
    partial class ReportsForm
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
            btnCurrency = new Button();
            btnHistory = new Button();
            btnWrittenOff = new Button();
            btnExpirationDates = new Button();
            btnReports = new Button();
            btnSuplies = new Button();
            btnCatalog = new Button();
            btnHeatMap = new Button();
            btnBlacklist = new Button();
            panelActions = new Panel();
            btnExport = new Button();
            btnRefresh = new Button();
            panelFilters = new Panel();
            label1 = new Label();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            lblPrice = new Label();
            lblCategory = new Label();
            txtProfitFrom = new TextBox();
            txtProfitTo = new TextBox();
            cmbClient = new ComboBox();
            lblFound = new Label();
            btnReset = new Button();
            dgvReports = new DataGridView();
            panelView = new Panel();
            lblPanelTitle = new Label();
            lblArticleView = new Label();
            txtArticleView = new TextBox();
            lblNameView = new Label();
            txtNameView = new TextBox();
            lblCategoryView = new Label();
            txtCategoryView = new TextBox();
            lblUnitView = new Label();
            txtUnitView = new TextBox();
            lblPriceView = new Label();
            txtPriceView = new TextBox();
            lblRestView = new Label();
            txtRestView = new TextBox();
            btnCloseView = new Button();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panelView.SuspendLayout();
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
            panelLeft.Controls.Add(btnCurrency);
            panelLeft.Controls.Add(btnHistory);
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
            // btnHistory
            // 
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(6, 48);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(128, 30);
            btnHistory.TabIndex = 10;
            btnHistory.Text = "История отгрузок";
            btnHistory.Click += btnHistory_Click;
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
            btnReports.Location = new Point(5, 122);
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
            btnCatalog.Text = "Каталог товаров";
            btnCatalog.UseVisualStyleBackColor = false;
            btnCatalog.Click += btnCatalog_Click;
            // 
            // btnHeatMap
            // 
            btnHeatMap.FlatStyle = FlatStyle.Flat;
            btnHeatMap.Location = new Point(6, 298);
            btnHeatMap.Name = "btnHeatMap";
            btnHeatMap.Size = new Size(128, 30);
            btnHeatMap.TabIndex = 11;
            btnHeatMap.Text = "Тепловая карта";
            btnHeatMap.Click += btnHeatMap_Click;
            // 
            // btnBlacklist
            // 
            btnBlacklist.FlatStyle = FlatStyle.Flat;
            btnBlacklist.Location = new Point(6, 262);
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
            panelActions.Controls.Add(btnExport);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Location = new Point(140, 35);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(960, 45);
            panelActions.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(70, 70, 70);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(10, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(121, 28);
            btnExport.TabIndex = 0;
            btnExport.Text = "Экспорт";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(70, 70, 70);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(137, 8);
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
            panelFilters.Controls.Add(label1);
            panelFilters.Controls.Add(dtpDateTo);
            panelFilters.Controls.Add(dtpDateFrom);
            panelFilters.Controls.Add(lblPrice);
            panelFilters.Controls.Add(lblCategory);
            panelFilters.Controls.Add(txtProfitFrom);
            panelFilters.Controls.Add(txtProfitTo);
            panelFilters.Controls.Add(cmbClient);
            panelFilters.Controls.Add(lblFound);
            panelFilters.Controls.Add(btnReset);
            panelFilters.Location = new Point(140, 80);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(960, 102);
            panelFilters.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 8F);
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(60, 16);
            label1.TabIndex = 11;
            label1.Text = "Период:";
            // 
            // dtpDateTo
            // 
            dtpDateTo.Location = new Point(182, 25);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(158, 27);
            dtpDateTo.TabIndex = 7;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Location = new Point(10, 25);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(158, 27);
            dtpDateFrom.TabIndex = 6;
            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Arial", 8F);
            lblPrice.Location = new Point(524, 8);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(70, 16);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Прибыль:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Arial", 8F);
            lblCategory.Location = new Point(354, 8);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 16);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Клиент:";
            // 
            // txtProfitFrom
            // 
            txtProfitFrom.Location = new Point(524, 25);
            txtProfitFrom.Name = "txtProfitFrom";
            txtProfitFrom.Size = new Size(70, 27);
            txtProfitFrom.TabIndex = 7;
            txtProfitFrom.Text = "0";
            txtProfitFrom.TextChanged += txtProfitFrom_TextChanged;
            // 
            // txtProfitTo
            // 
            txtProfitTo.Location = new Point(604, 25);
            txtProfitTo.Name = "txtProfitTo";
            txtProfitTo.Size = new Size(70, 27);
            txtProfitTo.TabIndex = 8;
            txtProfitTo.Text = "1000000";
            // 
            // cmbClient
            // 
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.Location = new Point(353, 24);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(160, 28);
            cmbClient.TabIndex = 3;
            cmbClient.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
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
            btnReset.Location = new Point(148, 61);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 33);
            btnReset.TabIndex = 10;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.BackgroundColor = Color.White;
            dgvReports.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReports.ColumnHeadersHeight = 29;
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.Location = new Point(140, 180);
            dgvReports.MultiSelect = false;
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersVisible = false;
            dgvReports.RowHeadersWidth = 51;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(960, 420);
            dgvReports.TabIndex = 5;
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(50, 50, 50);
            panelView.Controls.Add(lblPanelTitle);
            panelView.Controls.Add(lblArticleView);
            panelView.Controls.Add(txtArticleView);
            panelView.Controls.Add(lblNameView);
            panelView.Controls.Add(txtNameView);
            panelView.Controls.Add(lblCategoryView);
            panelView.Controls.Add(txtCategoryView);
            panelView.Controls.Add(lblUnitView);
            panelView.Controls.Add(txtUnitView);
            panelView.Controls.Add(lblPriceView);
            panelView.Controls.Add(txtPriceView);
            panelView.Controls.Add(lblRestView);
            panelView.Controls.Add(txtRestView);
            panelView.Controls.Add(btnCloseView);
            panelView.Location = new Point(0, 155);
            panelView.Name = "panelView";
            panelView.Size = new Size(140, 445);
            panelView.TabIndex = 4;
            panelView.Visible = false;
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblPanelTitle.ForeColor = Color.White;
            lblPanelTitle.Location = new Point(5, 8);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(130, 30);
            lblPanelTitle.TabIndex = 0;
            lblPanelTitle.Text = "ПРОСМОТР ТОВАРА";
            lblPanelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArticleView
            // 
            lblArticleView.AutoSize = true;
            lblArticleView.Font = new Font("Arial", 8F);
            lblArticleView.ForeColor = Color.White;
            lblArticleView.Location = new Point(5, 42);
            lblArticleView.Name = "lblArticleView";
            lblArticleView.Size = new Size(64, 16);
            lblArticleView.TabIndex = 1;
            lblArticleView.Text = "Артикул:";
            // 
            // txtArticleView
            // 
            txtArticleView.BackColor = Color.FromArgb(80, 80, 80);
            txtArticleView.BorderStyle = BorderStyle.FixedSingle;
            txtArticleView.ForeColor = Color.White;
            txtArticleView.Location = new Point(5, 58);
            txtArticleView.Name = "txtArticleView";
            txtArticleView.ReadOnly = true;
            txtArticleView.Size = new Size(130, 27);
            txtArticleView.TabIndex = 2;
            // 
            // lblNameView
            // 
            lblNameView.AutoSize = true;
            lblNameView.Font = new Font("Arial", 8F);
            lblNameView.ForeColor = Color.White;
            lblNameView.Location = new Point(5, 86);
            lblNameView.Name = "lblNameView";
            lblNameView.Size = new Size(109, 16);
            lblNameView.TabIndex = 3;
            lblNameView.Text = "Наименование:";
            // 
            // txtNameView
            // 
            txtNameView.BackColor = Color.FromArgb(80, 80, 80);
            txtNameView.BorderStyle = BorderStyle.FixedSingle;
            txtNameView.ForeColor = Color.White;
            txtNameView.Location = new Point(5, 102);
            txtNameView.Name = "txtNameView";
            txtNameView.ReadOnly = true;
            txtNameView.Size = new Size(130, 27);
            txtNameView.TabIndex = 4;
            // 
            // lblCategoryView
            // 
            lblCategoryView.AutoSize = true;
            lblCategoryView.Font = new Font("Arial", 8F);
            lblCategoryView.ForeColor = Color.White;
            lblCategoryView.Location = new Point(5, 130);
            lblCategoryView.Name = "lblCategoryView";
            lblCategoryView.Size = new Size(79, 16);
            lblCategoryView.TabIndex = 5;
            lblCategoryView.Text = "Категория:";
            // 
            // txtCategoryView
            // 
            txtCategoryView.BackColor = Color.FromArgb(80, 80, 80);
            txtCategoryView.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryView.ForeColor = Color.White;
            txtCategoryView.Location = new Point(5, 146);
            txtCategoryView.Name = "txtCategoryView";
            txtCategoryView.ReadOnly = true;
            txtCategoryView.Size = new Size(130, 27);
            txtCategoryView.TabIndex = 6;
            // 
            // lblUnitView
            // 
            lblUnitView.AutoSize = true;
            lblUnitView.Font = new Font("Arial", 8F);
            lblUnitView.ForeColor = Color.White;
            lblUnitView.Location = new Point(5, 174);
            lblUnitView.Name = "lblUnitView";
            lblUnitView.Size = new Size(108, 16);
            lblUnitView.TabIndex = 7;
            lblUnitView.Text = "Ед. измерения:";
            // 
            // txtUnitView
            // 
            txtUnitView.BackColor = Color.FromArgb(80, 80, 80);
            txtUnitView.BorderStyle = BorderStyle.FixedSingle;
            txtUnitView.ForeColor = Color.White;
            txtUnitView.Location = new Point(5, 190);
            txtUnitView.Name = "txtUnitView";
            txtUnitView.ReadOnly = true;
            txtUnitView.Size = new Size(130, 27);
            txtUnitView.TabIndex = 8;
            // 
            // lblPriceView
            // 
            lblPriceView.AutoSize = true;
            lblPriceView.Font = new Font("Arial", 8F);
            lblPriceView.ForeColor = Color.White;
            lblPriceView.Location = new Point(5, 218);
            lblPriceView.Name = "lblPriceView";
            lblPriceView.Size = new Size(98, 16);
            lblPriceView.TabIndex = 9;
            lblPriceView.Text = "Цена закупки:";
            // 
            // txtPriceView
            // 
            txtPriceView.BackColor = Color.FromArgb(80, 80, 80);
            txtPriceView.BorderStyle = BorderStyle.FixedSingle;
            txtPriceView.ForeColor = Color.White;
            txtPriceView.Location = new Point(5, 234);
            txtPriceView.Name = "txtPriceView";
            txtPriceView.ReadOnly = true;
            txtPriceView.Size = new Size(130, 27);
            txtPriceView.TabIndex = 10;
            // 
            // lblRestView
            // 
            lblRestView.AutoSize = true;
            lblRestView.Font = new Font("Arial", 8F);
            lblRestView.ForeColor = Color.White;
            lblRestView.Location = new Point(5, 262);
            lblRestView.Name = "lblRestView";
            lblRestView.Size = new Size(65, 16);
            lblRestView.TabIndex = 11;
            lblRestView.Text = "Остаток:";
            // 
            // txtRestView
            // 
            txtRestView.BackColor = Color.FromArgb(80, 80, 80);
            txtRestView.BorderStyle = BorderStyle.FixedSingle;
            txtRestView.ForeColor = Color.White;
            txtRestView.Location = new Point(5, 278);
            txtRestView.Name = "txtRestView";
            txtRestView.ReadOnly = true;
            txtRestView.Size = new Size(130, 27);
            txtRestView.TabIndex = 12;
            // 
            // btnCloseView
            // 
            btnCloseView.BackColor = Color.FromArgb(80, 80, 80);
            btnCloseView.FlatStyle = FlatStyle.Flat;
            btnCloseView.ForeColor = Color.White;
            btnCloseView.Location = new Point(5, 315);
            btnCloseView.Name = "btnCloseView";
            btnCloseView.Size = new Size(130, 28);
            btnCloseView.TabIndex = 13;
            btnCloseView.Text = "ЗАКРЫТЬ";
            btnCloseView.UseVisualStyleBackColor = false;
            btnCloseView.Click += btnCloseView_Click;
            // 
            // ReportsForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelActions);
            Controls.Add(panelFilters);
            Controls.Add(panelView);
            Controls.Add(dgvReports);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчеты";
            WindowState = FormWindowState.Maximized;
            Load += ReportsForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panelView.ResumeLayout(false);
            panelView.PerformLayout();
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtProfitFrom;
        private System.Windows.Forms.TextBox txtProfitTo;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Label lblPanelTitle;
        private System.Windows.Forms.Label lblArticleView;
        private System.Windows.Forms.TextBox txtArticleView;
        private System.Windows.Forms.Label lblNameView;
        private System.Windows.Forms.TextBox txtNameView;
        private System.Windows.Forms.Label lblCategoryView;
        private System.Windows.Forms.TextBox txtCategoryView;
        private System.Windows.Forms.Label lblUnitView;
        private System.Windows.Forms.TextBox txtUnitView;
        private System.Windows.Forms.Label lblPriceView;
        private System.Windows.Forms.TextBox txtPriceView;
        private System.Windows.Forms.Label lblRestView;
        private System.Windows.Forms.TextBox txtRestView;
        private System.Windows.Forms.Button btnCloseView;
        private Button btnSuplies;
        private Button btnReports;
        private Button btnExpirationDates;
        private DateTimePicker dtpDateFrom;
        private DateTimePicker dtpDateTo;
        private Label label1;
        private Button btnWrittenOff;
        private Button btnHistory;
        private Button btnCurrency;
        private Button btnHeatMap;
        private Button btnBlacklist;
    }
}