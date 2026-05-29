namespace Sklad_project_app
{
    partial class HeatMapForm
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
            panelTop = new Panel();
            lblCompany = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            panelLeft = new Panel();
            btnCatalog = new Button();
            btnCategories = new Button();
            btnHistory = new Button();
            btnSuplies = new Button();
            btnReports = new Button();
            btnExpirationDates = new Button();
            btnWrittenOff = new Button();
            btnCurrency = new Button();
            btnHeatMap = new Button();
            panelMain = new Panel();
            lblTitle = new Label();
            lblSelectCategory = new Label();
            cmbZone = new ComboBox();
            btnRefresh = new Button();
            panelMap = new Panel();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelMain.SuspendLayout();
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
            lblUserInfo.Location = new Point(700, 9);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(108, 17);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Пользователь:";
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
            panelLeft.Controls.Add(btnCatalog);
            panelLeft.Controls.Add(btnCategories);
            panelLeft.Controls.Add(btnHistory);
            panelLeft.Controls.Add(btnSuplies);
            panelLeft.Controls.Add(btnReports);
            panelLeft.Controls.Add(btnExpirationDates);
            panelLeft.Controls.Add(btnWrittenOff);
            panelLeft.Controls.Add(btnCurrency);
            panelLeft.Controls.Add(btnHeatMap);
            panelLeft.Location = new Point(0, 35);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(140, 565);
            panelLeft.TabIndex = 1;
            // 
            // btnCatalog
            // 
            btnCatalog.FlatStyle = FlatStyle.Flat;
            btnCatalog.Location = new Point(5, 10);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Size = new Size(128, 30);
            btnCatalog.TabIndex = 0;
            btnCatalog.Text = "Каталог товаров";
            btnCatalog.Click += btnCatalog_Click;
            // 
            // btnCategories
            // 
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Location = new Point(5, 48);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(128, 30);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Категории";
            btnCategories.Click += btnCategories_Click;
            // 
            // btnHistory
            // 
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(5, 86);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(128, 30);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "История отгрузок";
            btnHistory.Click += btnHistory_Click;
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
            // btnReports
            // 
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Location = new Point(5, 158);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(128, 30);
            btnReports.TabIndex = 4;
            btnReports.Text = "Отчеты";
            btnReports.Click += btnReports_Click;
            // 
            // btnExpirationDates
            // 
            btnExpirationDates.FlatStyle = FlatStyle.Flat;
            btnExpirationDates.Location = new Point(5, 194);
            btnExpirationDates.Name = "btnExpirationDates";
            btnExpirationDates.Size = new Size(128, 30);
            btnExpirationDates.TabIndex = 5;
            btnExpirationDates.Text = "Сроки годности";
            btnExpirationDates.Click += btnExpirationDates_Click;
            // 
            // btnWrittenOff
            // 
            btnWrittenOff.FlatStyle = FlatStyle.Flat;
            btnWrittenOff.Location = new Point(5, 230);
            btnWrittenOff.Name = "btnWrittenOff";
            btnWrittenOff.Size = new Size(128, 30);
            btnWrittenOff.TabIndex = 6;
            btnWrittenOff.Text = "Списанное";
            btnWrittenOff.Click += btnWrittenOff_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.FlatStyle = FlatStyle.Flat;
            btnCurrency.Location = new Point(5, 266);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Size = new Size(128, 30);
            btnCurrency.TabIndex = 7;
            btnCurrency.Text = "Валюта";
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnHeatMap
            // 
            btnHeatMap.BackColor = Color.FromArgb(30, 100, 200);
            btnHeatMap.FlatStyle = FlatStyle.Flat;
            btnHeatMap.ForeColor = Color.White;
            btnHeatMap.Location = new Point(5, 302);
            btnHeatMap.Name = "btnHeatMap";
            btnHeatMap.Size = new Size(128, 30);
            btnHeatMap.TabIndex = 8;
            btnHeatMap.Text = "Тепловая карта";
            btnHeatMap.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblSelectCategory);
            panelMain.Controls.Add(cmbZone);
            panelMain.Controls.Add(btnRefresh);
            panelMain.Controls.Add(panelMap);
            panelMain.Location = new Point(140, 35);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(960, 565);
            panelMain.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Тепловая карта";
            // 
            // lblSelectCategory
            // 
            lblSelectCategory.AutoSize = true;
            lblSelectCategory.Font = new Font("Arial", 9F);
            lblSelectCategory.Location = new Point(10, 60);
            lblSelectCategory.Name = "lblSelectCategory";
            lblSelectCategory.Size = new Size(129, 17);
            lblSelectCategory.TabIndex = 1;
            lblSelectCategory.Text = "Выбор категории:";
            // 
            // cmbZone
            // 
            cmbZone.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZone.Location = new Point(145, 56);
            cmbZone.Name = "cmbZone";
            cmbZone.Size = new Size(200, 28);
            cmbZone.TabIndex = 2;
            cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(50, 50, 50);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(793, 53);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить карту";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelMap
            // 
            panelMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMap.AutoScroll = true;
            panelMap.BackColor = Color.White;
            panelMap.BorderStyle = BorderStyle.FixedSingle;
            panelMap.Location = new Point(10, 95);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(930, 450);
            panelMap.TabIndex = 4;
            // 
            // HeatMapForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelMain);
            Name = "HeatMapForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Тепловая карта";
            WindowState = FormWindowState.Maximized;
            Load += HeatMapForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnSuplies;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExpirationDates;
        private System.Windows.Forms.Button btnWrittenOff;
        private System.Windows.Forms.Button btnCurrency;
        private System.Windows.Forms.Button btnHeatMap;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectCategory;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelMap;
    }
}