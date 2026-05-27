namespace Sklad_project_app
{
    partial class SuppliesForm
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
            panelView = new Panel();
            lblExpirationDate = new Label();
            txtExpirationDate = new TextBox();
            lblArticleEdit = new Label();
            cmbProduct = new ComboBox();
            txtArticleView = new TextBox();
            lblSupplierInn = new Label();
            txtSupplierInn = new TextBox();
            btnCheckSupplierBlacklist = new Button();
            btnSave = new Button();
            dtpDate = new DateTimePicker();
            lblPanelTitle = new Label();
            lblNameView = new Label();
            txtNameView = new TextBox();
            lblCategoryView = new Label();
            txtCategoryView = new TextBox();
            lblUnitView = new Label();
            txtDateView = new TextBox();
            lblPriceView = new Label();
            txtPriceView = new TextBox();
            lblRestView = new Label();
            txtRestView = new TextBox();
            btnCloseView = new Button();
            btnHistory = new Button();
            btnCurrency = new Button();
            btnWrittenOff = new Button();
            btnExpirationDates = new Button();
            btnReports = new Button();
            btnSuplies = new Button();
            btnCatalog = new Button();
            btnShipment = new Button();
            btnMyShipments = new Button();
            panelActions = new Panel();
            btnImport = new Button();
            btnAddComing = new Button();
            btnView = new Button();
            btnRefresh = new Button();
            panelFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDate = new Label();
            cmbDate = new ComboBox();
            lblPrice = new Label();
            txtPriceFrom = new TextBox();
            txtPriceTo = new TextBox();
            lblFound = new Label();
            btnReset = new Button();
            dgvProducts = new DataGridView();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelView.SuspendLayout();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            panelLeft.Controls.Add(panelView);
            panelLeft.Controls.Add(btnHistory);
            panelLeft.Controls.Add(btnCurrency);
            panelLeft.Controls.Add(btnWrittenOff);
            panelLeft.Controls.Add(btnExpirationDates);
            panelLeft.Controls.Add(btnReports);
            panelLeft.Controls.Add(btnSuplies);
            panelLeft.Controls.Add(btnCatalog);
            panelLeft.Controls.Add(btnShipment);
            panelLeft.Controls.Add(btnMyShipments);
            panelLeft.Location = new Point(0, 35);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(140, 565);
            panelLeft.TabIndex = 1;
            // 
            // panelView
            // 
            panelView.BackColor = Color.FromArgb(50, 50, 50);
            panelView.Controls.Add(lblExpirationDate);
            panelView.Controls.Add(txtExpirationDate);
            panelView.Controls.Add(lblArticleEdit);
            panelView.Controls.Add(cmbProduct);
            panelView.Controls.Add(txtArticleView);
            panelView.Controls.Add(lblSupplierInn);
            panelView.Controls.Add(txtSupplierInn);
            panelView.Controls.Add(btnCheckSupplierBlacklist);
            panelView.Controls.Add(btnSave);
            panelView.Controls.Add(dtpDate);
            panelView.Controls.Add(lblPanelTitle);
            panelView.Controls.Add(lblNameView);
            panelView.Controls.Add(txtNameView);
            panelView.Controls.Add(lblCategoryView);
            panelView.Controls.Add(txtCategoryView);
            panelView.Controls.Add(lblUnitView);
            panelView.Controls.Add(txtDateView);
            panelView.Controls.Add(lblPriceView);
            panelView.Controls.Add(txtPriceView);
            panelView.Controls.Add(lblRestView);
            panelView.Controls.Add(txtRestView);
            panelView.Controls.Add(btnCloseView);
            panelView.Location = new Point(-1, -1);
            panelView.Name = "panelView";
            panelView.Size = new Size(140, 565);
            panelView.TabIndex = 4;
            panelView.Visible = false;
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Font = new Font("Arial", 8F);
            lblExpirationDate.ForeColor = Color.White;
            lblExpirationDate.Location = new Point(6, 417);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(106, 16);
            lblExpirationDate.TabIndex = 15;
            lblExpirationDate.Text = "Срок годности:";
            // 
            // txtExpirationDate
            // 
            txtExpirationDate.BackColor = Color.FromArgb(80, 80, 80);
            txtExpirationDate.BorderStyle = BorderStyle.FixedSingle;
            txtExpirationDate.ForeColor = Color.White;
            txtExpirationDate.Location = new Point(5, 436);
            txtExpirationDate.Name = "txtExpirationDate";
            txtExpirationDate.ReadOnly = true;
            txtExpirationDate.Size = new Size(130, 27);
            txtExpirationDate.TabIndex = 16;
            txtExpirationDate.TextChanged += txtExpirationDate_TextChanged;
            // 
            // lblArticleEdit
            // 
            lblArticleEdit.AutoSize = true;
            lblArticleEdit.Font = new Font("Arial", 8F);
            lblArticleEdit.ForeColor = Color.White;
            lblArticleEdit.Location = new Point(4, 164);
            lblArticleEdit.Name = "lblArticleEdit";
            lblArticleEdit.Size = new Size(64, 16);
            lblArticleEdit.TabIndex = 7;
            lblArticleEdit.Text = "Артикул:";
            lblArticleEdit.Click += lblArticleEdit_Click;
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(3, 133);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(130, 28);
            cmbProduct.TabIndex = 6;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            // 
            // txtArticleView
            // 
            txtArticleView.BackColor = Color.FromArgb(80, 80, 80);
            txtArticleView.BorderStyle = BorderStyle.FixedSingle;
            txtArticleView.ForeColor = Color.White;
            txtArticleView.Location = new Point(3, 181);
            txtArticleView.Name = "txtArticleView";
            txtArticleView.Size = new Size(130, 27);
            txtArticleView.TabIndex = 6;
            // 
            // lblSupplierInn
            // 
            lblSupplierInn.AutoSize = true;
            lblSupplierInn.Font = new Font("Arial", 8F);
            lblSupplierInn.ForeColor = Color.White;
            lblSupplierInn.Location = new Point(3, 20);
            lblSupplierInn.Name = "lblSupplierInn";
            lblSupplierInn.Size = new Size(121, 16);
            lblSupplierInn.TabIndex = 23;
            lblSupplierInn.Text = "ИНН поставщика:";
            // 
            // txtSupplierInn
            // 
            txtSupplierInn.BackColor = Color.FromArgb(80, 80, 80);
            txtSupplierInn.BorderStyle = BorderStyle.FixedSingle;
            txtSupplierInn.ForeColor = Color.White;
            txtSupplierInn.Location = new Point(3, 39);
            txtSupplierInn.Name = "txtSupplierInn";
            txtSupplierInn.Size = new Size(130, 27);
            txtSupplierInn.TabIndex = 24;
            // 
            // btnCheckSupplierBlacklist
            // 
            btnCheckSupplierBlacklist.BackColor = Color.FromArgb(80, 80, 80);
            btnCheckSupplierBlacklist.FlatStyle = FlatStyle.Flat;
            btnCheckSupplierBlacklist.ForeColor = Color.White;
            btnCheckSupplierBlacklist.Location = new Point(3, 72);
            btnCheckSupplierBlacklist.Name = "btnCheckSupplierBlacklist";
            btnCheckSupplierBlacklist.Size = new Size(130, 33);
            btnCheckSupplierBlacklist.TabIndex = 25;
            btnCheckSupplierBlacklist.Text = "Проверить поставщика";
            btnCheckSupplierBlacklist.UseVisualStyleBackColor = false;
            btnCheckSupplierBlacklist.Click += btnCheckSupplierBlacklist_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(80, 80, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(6, 525);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 28);
            btnSave.TabIndex = 14;
            btnSave.Text = "СОХРАНИТЬ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(5, 289);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(130, 27);
            dtpDate.TabIndex = 6;
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblPanelTitle.ForeColor = Color.White;
            lblPanelTitle.Location = new Point(3, 0);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(130, 30);
            lblPanelTitle.TabIndex = 0;
            lblPanelTitle.Text = "ПРОСМОТР ТОВАРА";
            lblPanelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNameView
            // 
            lblNameView.AutoSize = true;
            lblNameView.Font = new Font("Arial", 8F);
            lblNameView.ForeColor = Color.White;
            lblNameView.Location = new Point(3, 114);
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
            txtNameView.Location = new Point(3, 133);
            txtNameView.Name = "txtNameView";
            txtNameView.ReadOnly = true;
            txtNameView.Size = new Size(130, 27);
            txtNameView.TabIndex = 4;
            txtNameView.Visible = false;
            // 
            // lblCategoryView
            // 
            lblCategoryView.AutoSize = true;
            lblCategoryView.Font = new Font("Arial", 8F);
            lblCategoryView.ForeColor = Color.White;
            lblCategoryView.Location = new Point(4, 211);
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
            txtCategoryView.Location = new Point(3, 233);
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
            lblUnitView.Location = new Point(4, 266);
            lblUnitView.Name = "lblUnitView";
            lblUnitView.Size = new Size(106, 16);
            lblUnitView.TabIndex = 7;
            lblUnitView.Text = "Дата поставки:";
            // 
            // txtDateView
            // 
            txtDateView.BackColor = Color.FromArgb(80, 80, 80);
            txtDateView.BorderStyle = BorderStyle.FixedSingle;
            txtDateView.ForeColor = Color.White;
            txtDateView.Location = new Point(5, 289);
            txtDateView.Name = "txtDateView";
            txtDateView.ReadOnly = true;
            txtDateView.Size = new Size(130, 27);
            txtDateView.TabIndex = 8;
            // 
            // lblPriceView
            // 
            lblPriceView.AutoSize = true;
            lblPriceView.Font = new Font("Arial", 8F);
            lblPriceView.ForeColor = Color.White;
            lblPriceView.Location = new Point(5, 319);
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
            txtPriceView.Location = new Point(5, 338);
            txtPriceView.Name = "txtPriceView";
            txtPriceView.ReadOnly = true;
            txtPriceView.Size = new Size(130, 27);
            txtPriceView.TabIndex = 10;
            txtPriceView.TextChanged += txtPriceView_TextChanged;
            // 
            // lblRestView
            // 
            lblRestView.AutoSize = true;
            lblRestView.Font = new Font("Arial", 8F);
            lblRestView.ForeColor = Color.White;
            lblRestView.Location = new Point(4, 368);
            lblRestView.Name = "lblRestView";
            lblRestView.Size = new Size(87, 16);
            lblRestView.TabIndex = 11;
            lblRestView.Text = "Количество:";
            // 
            // txtRestView
            // 
            txtRestView.BackColor = Color.FromArgb(80, 80, 80);
            txtRestView.BorderStyle = BorderStyle.FixedSingle;
            txtRestView.ForeColor = Color.White;
            txtRestView.Location = new Point(5, 387);
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
            btnCloseView.Location = new Point(5, 491);
            btnCloseView.Name = "btnCloseView";
            btnCloseView.Size = new Size(130, 28);
            btnCloseView.TabIndex = 13;
            btnCloseView.Text = "ЗАКРЫТЬ";
            btnCloseView.UseVisualStyleBackColor = false;
            btnCloseView.Click += btnCloseView_Click;
            // 
            // btnHistory
            // 
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(7, 299);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(128, 30);
            btnHistory.TabIndex = 10;
            btnHistory.Text = "История отгрузок";
            btnHistory.Click += btnHistory_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.ImageAlign = ContentAlignment.TopCenter;
            btnCurrency.Location = new Point(5, 265);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Size = new Size(128, 30);
            btnCurrency.TabIndex = 9;
            btnCurrency.Text = "Валюта";
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnWrittenOff
            // 
            btnWrittenOff.FlatStyle = FlatStyle.Flat;
            btnWrittenOff.ImageAlign = ContentAlignment.TopCenter;
            btnWrittenOff.Location = new Point(5, 229);
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
            // panelActions
            // 
            panelActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelActions.AutoSize = true;
            panelActions.BackColor = Color.FromArgb(50, 50, 50);
            panelActions.Controls.Add(btnImport);
            panelActions.Controls.Add(btnAddComing);
            panelActions.Controls.Add(btnView);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Location = new Point(140, 35);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(960, 45);
            panelActions.TabIndex = 2;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(70, 70, 70);
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(137, 8);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(121, 28);
            btnImport.TabIndex = 3;
            btnImport.Text = "Импорт";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnAddComing
            // 
            btnAddComing.BackColor = Color.FromArgb(70, 70, 70);
            btnAddComing.FlatStyle = FlatStyle.Flat;
            btnAddComing.ForeColor = Color.White;
            btnAddComing.Location = new Point(10, 8);
            btnAddComing.Name = "btnAddComing";
            btnAddComing.Size = new Size(121, 28);
            btnAddComing.TabIndex = 2;
            btnAddComing.Text = "Добавить ";
            btnAddComing.UseVisualStyleBackColor = false;
            btnAddComing.Click += btnAddComing_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(70, 70, 70);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(264, 8);
            btnView.Name = "btnView";
            btnView.Size = new Size(121, 28);
            btnView.TabIndex = 0;
            btnView.Text = "Просмотреть";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(70, 70, 70);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(391, 8);
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
            panelFilters.Controls.Add(txtPriceFrom);
            panelFilters.Controls.Add(txtPriceTo);
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
            // txtPriceFrom
            // 
            txtPriceFrom.Location = new Point(524, 25);
            txtPriceFrom.Name = "txtPriceFrom";
            txtPriceFrom.Size = new Size(70, 27);
            txtPriceFrom.TabIndex = 7;
            txtPriceFrom.Text = "0";
            txtPriceFrom.TextChanged += txtPriceFrom_TextChanged;
            // 
            // txtPriceTo
            // 
            txtPriceTo.Location = new Point(604, 25);
            txtPriceTo.Name = "txtPriceTo";
            txtPriceTo.Size = new Size(70, 27);
            txtPriceTo.TabIndex = 8;
            txtPriceTo.Text = "1000000";
            txtPriceTo.TextChanged += txtPriceTo_TextChanged;
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
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.Location = new Point(140, 180);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(960, 420);
            dgvProducts.TabIndex = 5;
            // 
            // SuppliesForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(dgvProducts);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelActions);
            Controls.Add(panelFilters);
            Name = "SuppliesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поставки";
            WindowState = FormWindowState.Maximized;
            Load += SuppliesCatalogForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelView.ResumeLayout(false);
            panelView.PerformLayout();
            panelActions.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
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
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPriceFrom;
        private System.Windows.Forms.TextBox txtPriceTo;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Label lblPanelTitle;
        private System.Windows.Forms.Label lblNameView;
        private System.Windows.Forms.Label lblCategoryView;
        private System.Windows.Forms.TextBox txtCategoryView;
        private System.Windows.Forms.Label lblUnitView;
        private System.Windows.Forms.Label lblPriceView;
        private System.Windows.Forms.TextBox txtPriceView;
        private System.Windows.Forms.Label lblRestView;
        private System.Windows.Forms.TextBox txtRestView;
        private System.Windows.Forms.Button btnCloseView;
        private System.Windows.Forms.TextBox txtNameView;
        private Button btnSuplies;
        private Button btnReports;
        private Button btnExpirationDates;
        private Button btnImport;
        private Button btnAddComing;
        private DateTimePicker dtpDate;
        private TextBox txtDateView;
        private Button btnSave;
        private ComboBox cmbProduct;
        private TextBox txtArticleView;
        private Label lblArticleEdit;
        private Label lblExpirationDate;
        private TextBox txtExpirationDate;
        private Button btnWrittenOff;
        private Button btnCurrency;
        private Button btnHistory;
        private System.Windows.Forms.Label lblInnSupply;
        private System.Windows.Forms.TextBox txtInnSupply;
        private System.Windows.Forms.Button btnCheckApiSupply;
        private System.Windows.Forms.Label lblSupplierInn;
        private System.Windows.Forms.TextBox txtSupplierInn;
        private System.Windows.Forms.Button btnCheckSupplierBlacklist;
        
    }
}