
namespace Sklad_project_app
{
    partial class ShipmentForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblClient = new Label();
            txtClientName = new TextBox();
            lblClientInn = new Label();
            txtClientInn = new TextBox();
            btnCheckBlacklist = new Button();
            cmbCity = new ComboBox();
            btnCheckWeather = new Button();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            panelTop = new Panel();
            lblCompany = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            lblWarning = new Label();
            panelLeft = new Panel();
            lblShipTitle = new Label();
            lblTotal = new Label();
            btnCancel = new Button();
            btnSubmit = new Button();
            lblRegion = new Label();
            panelActions = new Panel();
            btnRefresh = new Button();
            panelFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblAvailability = new Label();
            cmbAvailability = new ComboBox();
            lblFound = new Label();
            btnReset = new Button();
            dgvShipment = new DataGridView();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShipment).BeginInit();
            SuspendLayout();
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Arial", 8F);
            lblClient.ForeColor = Color.White;
            lblClient.Location = new Point(5, 45);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(133, 16);
            lblClient.TabIndex = 1;
            lblClient.Text = "Клиент (название):";
            // 
            // txtClientName
            // 
            txtClientName.BackColor = Color.FromArgb(80, 80, 80);
            txtClientName.BorderStyle = BorderStyle.FixedSingle;
            txtClientName.ForeColor = Color.White;
            txtClientName.Location = new Point(5, 62);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(130, 27);
            txtClientName.TabIndex = 2;
            // 
            // lblClientInn
            // 
            lblClientInn.AutoSize = true;
            lblClientInn.Font = new Font("Arial", 8F);
            lblClientInn.ForeColor = Color.White;
            lblClientInn.Location = new Point(5, 92);
            lblClientInn.Name = "lblClientInn";
            lblClientInn.Size = new Size(96, 16);
            lblClientInn.TabIndex = 3;
            lblClientInn.Text = "ИНН клиента:";
            // 
            // txtClientInn
            // 
            txtClientInn.BackColor = Color.FromArgb(80, 80, 80);
            txtClientInn.BorderStyle = BorderStyle.FixedSingle;
            txtClientInn.ForeColor = Color.White;
            txtClientInn.Location = new Point(4, 108);
            txtClientInn.Name = "txtClientInn";
            txtClientInn.Size = new Size(130, 27);
            txtClientInn.TabIndex = 4;
            // 
            // btnCheckBlacklist
            // 
            btnCheckBlacklist.BackColor = Color.FromArgb(80, 80, 80);
            btnCheckBlacklist.FlatStyle = FlatStyle.Flat;
            btnCheckBlacklist.ForeColor = Color.White;
            btnCheckBlacklist.Location = new Point(3, 141);
            btnCheckBlacklist.Name = "btnCheckBlacklist";
            btnCheckBlacklist.Size = new Size(130, 28);
            btnCheckBlacklist.TabIndex = 5;
            btnCheckBlacklist.Text = "Проверить клиента";
            btnCheckBlacklist.UseVisualStyleBackColor = false;
            btnCheckBlacklist.Click += btnCheckBlacklist_Click;
            // 
            // cmbCity
            // 
            cmbCity.BackColor = Color.FromArgb(80, 80, 80);
            cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCity.ForeColor = Color.White;
            cmbCity.Location = new Point(3, 201);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(130, 28);
            cmbCity.TabIndex = 7;
            // 
            // btnCheckWeather
            // 
            btnCheckWeather.BackColor = Color.FromArgb(80, 80, 80);
            btnCheckWeather.FlatStyle = FlatStyle.Flat;
            btnCheckWeather.ForeColor = Color.White;
            btnCheckWeather.Location = new Point(3, 235);
            btnCheckWeather.Name = "btnCheckWeather";
            btnCheckWeather.Size = new Size(130, 50);
            btnCheckWeather.TabIndex = 8;
            btnCheckWeather.Text = "Погода в регионе";
            btnCheckWeather.UseVisualStyleBackColor = false;
            btnCheckWeather.Click += btnCheckWeather_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial", 8F);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(4, 297);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(102, 16);
            lblDate.TabIndex = 3;
            lblDate.Text = "Дата отгрузки:";
            lblDate.Click += lblDate_Click;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(3, 316);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(130, 27);
            dtpDate.TabIndex = 4;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // panelTop
            // 
            panelTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTop.BackColor = Color.FromArgb(30, 100, 200);
            panelTop.Controls.Add(lblCompany);
            panelTop.Controls.Add(lblUserInfo);
            panelTop.Controls.Add(btnLogout);
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
            lblUserInfo.Location = new Point(608, 10);
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
            btnLogout.Location = new Point(1018, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(70, 30);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblWarning.ForeColor = Color.Yellow;
            lblWarning.Location = new Point(289, 14);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(409, 18);
            lblWarning.TabIndex = 3;
            lblWarning.Text = "Перед отгрузкой проверьте наличие товара на складе";
            // 
            // panelLeft
            // 
            panelLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelLeft.BackColor = Color.FromArgb(50, 50, 50);
            panelLeft.Controls.Add(lblShipTitle);
            panelLeft.Controls.Add(lblClient);
            panelLeft.Controls.Add(txtClientName);
            panelLeft.Controls.Add(lblClientInn);
            panelLeft.Controls.Add(txtClientInn);
            panelLeft.Controls.Add(btnCheckBlacklist);
            panelLeft.Controls.Add(cmbCity);
            panelLeft.Controls.Add(btnCheckWeather);
            panelLeft.Controls.Add(lblDate);
            panelLeft.Controls.Add(dtpDate);
            panelLeft.Controls.Add(lblTotal);
            panelLeft.Controls.Add(btnCancel);
            panelLeft.Controls.Add(btnSubmit);
            panelLeft.Controls.Add(lblRegion);
            panelLeft.Location = new Point(0, 35);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(140, 565);
            panelLeft.TabIndex = 1;
            // 
            // lblShipTitle
            // 
            lblShipTitle.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblShipTitle.ForeColor = Color.White;
            lblShipTitle.Location = new Point(4, 3);
            lblShipTitle.Name = "lblShipTitle";
            lblShipTitle.Size = new Size(130, 30);
            lblShipTitle.TabIndex = 0;
            lblShipTitle.Text = "ДАННЫЕ ОТГРУЗКИ";
            lblShipTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            lblTotal.BorderStyle = BorderStyle.FixedSingle;
            lblTotal.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(4, 356);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(130, 72);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "ВЗЯТО ТОВАРОВ:\n0";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblTotal.Click += lblTotal_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(80, 80, 80);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(3, 440);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 30);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "ОТМЕНА";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(30, 100, 200);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(3, 476);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(130, 30);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "ОТПРАВИТЬ";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Font = new Font("Arial", 8F);
            lblRegion.ForeColor = Color.White;
            lblRegion.Location = new Point(3, 182);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(119, 16);
            lblRegion.TabIndex = 6;
            lblRegion.Text = "Регион доставки:";
            // 
            // panelActions
            // 
            panelActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelActions.AutoSize = true;
            panelActions.BackColor = Color.FromArgb(50, 50, 50);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(lblWarning);
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
            btnRefresh.Location = new Point(10, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 28);
            btnRefresh.TabIndex = 0;
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
            panelFilters.Controls.Add(lblAvailability);
            panelFilters.Controls.Add(cmbAvailability);
            panelFilters.Controls.Add(lblFound);
            panelFilters.Controls.Add(btnReset);
            panelFilters.Location = new Point(140, 80);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(960, 105);
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
            lblCategory.Location = new Point(198, 8);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 16);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(185, 25);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(160, 28);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new Font("Arial", 8F);
            lblAvailability.Location = new Point(360, 8);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(67, 16);
            lblAvailability.TabIndex = 4;
            lblAvailability.Text = "Наличие:";
            // 
            // cmbAvailability
            // 
            cmbAvailability.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailability.Location = new Point(360, 25);
            cmbAvailability.Name = "cmbAvailability";
            cmbAvailability.Size = new Size(130, 28);
            cmbAvailability.TabIndex = 5;
            // 
            // lblFound
            // 
            lblFound.AutoSize = true;
            lblFound.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblFound.Location = new Point(10, 68);
            lblFound.Name = "lblFound";
            lblFound.Size = new Size(121, 18);
            lblFound.TabIndex = 6;
            lblFound.Text = "Найдено: 0 из 0";
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(147, 63);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(85, 31);
            btnReset.TabIndex = 7;
            btnReset.Text = "Сбросить";
            btnReset.Click += btnReset_Click;
            // 
            // dgvShipment
            // 
            dgvShipment.AllowUserToAddRows = false;
            dgvShipment.AllowUserToDeleteRows = false;
            dgvShipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShipment.BackgroundColor = Color.White;
            dgvShipment.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.Font = new Font("Arial", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvShipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvShipment.ColumnHeadersHeight = 29;
            dgvShipment.EnableHeadersVisualStyles = false;
            dgvShipment.Location = new Point(140, 180);
            dgvShipment.MultiSelect = false;
            dgvShipment.Name = "dgvShipment";
            dgvShipment.RowHeadersVisible = false;
            dgvShipment.RowHeadersWidth = 51;
            dgvShipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShipment.Size = new Size(960, 420);
            dgvShipment.TabIndex = 4;
            dgvShipment.CellContentClick += dgvShipment_CellContentClick;
            // 
            // ShipmentForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 600);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelActions);
            Controls.Add(panelFilters);
            Controls.Add(dgvShipment);
            Name = "ShipmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отгрузка - Кладовщик";
            WindowState = FormWindowState.Maximized;
            Load += ShipmentForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShipment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblShipTitle;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.ComboBox cmbAvailability;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvShipment;
        private System.Windows.Forms.TextBox txtInn;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label lblClientInn;
        private System.Windows.Forms.TextBox txtClientInn;
        private System.Windows.Forms.Button btnCheckBlacklist;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Button btnCheckWeather;
    }
}
