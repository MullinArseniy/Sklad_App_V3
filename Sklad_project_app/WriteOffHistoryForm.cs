namespace Sklad_project_app
{
    public partial class WriteOffHistoryForm : Form
    {
        private PanelMode _currentMode = PanelMode.None;
        private Guid _selectedProductId = Guid.Empty;

        public WriteOffHistoryForm()
        {
            InitializeComponent();
            LoadWriteOffHistory();
            ConfigureAccessByRole();
            this.Text = AppResources.CatalogTitle;
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }

        private void ConfigureAccessByRole()
        {
            bool isAdmin = CurrentUser.RoleName == "Администратор";
            bool isStorekeeper = CurrentUser.RoleName == "Кладовщик";
            btnReports.Visible = isAdmin;
            btnExpirationDates.Visible = isAdmin;
            btnCurrency.Visible = isAdmin;
            btnHistory.Visible = isAdmin;
            btnSuplies.Visible = true;
            btnShipment.Visible = isStorekeeper;
            btnMyShipments.Visible = isStorekeeper;
            btnWrittenOff.Visible = true;
            if (isAdmin)
            {
                btnWrittenOff.Location = new Point(5, 194);
                btnHistory.Location = new Point(5, 48);
                btnSuplies.Location = new Point(5, 86);
                btnReports.Location = new Point(5, 122);
                btnExpirationDates.Location = new Point(5, 158);
                btnCurrency.Location = new Point(5, 229);
            }
            else if (isStorekeeper)
            {
                btnWrittenOff.Location = new Point(5, 158);
                btnSuplies.Location = new Point(5, 122);
            }
            btnWrittenOff.Parent?.PerformLayout();
        }
        private void SuppliesCatalogForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToFilter();
            LoadWriteOffHistory();
        }

        private void LoadCategoriesToFilter()
        {
            using (var db = new SkladContext())
            {
                var categories = db.Categories.ToList();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add(AppResources.FilterAll);
                foreach (var category in categories)
                {
                    cmbCategory.Items.Add(category.Name);
                }
                cmbCategory.SelectedIndex = 0;

                var allSupplies = db.Supplies.ToList();
                var uniqueDates = new List<DateTime>();

                foreach (var supply in allSupplies)
                {
                    DateTime dateOnly = supply.SuppliesDate.Date;
                    if (!uniqueDates.Contains(dateOnly))
                    {
                        uniqueDates.Add(dateOnly);
                    }
                }

                uniqueDates.Sort((a, b) => b.CompareTo(a));

                cmbDate.Items.Clear();
                cmbDate.Items.Add("Все даты");

                foreach (var date in uniqueDates)
                {
                    cmbDate.Items.Add(date.ToString("dd.MM.yyyy"));
                }

                cmbDate.SelectedIndex = 0;
            }
        }

        public void LoadWriteOffHistory()
        {
            try
            {
                using (var db = new SkladContext())
                {
                    var allWriteOffs = db.WriteOffs
                        .Include(w => w.Product)
                        .ThenInclude(p => p.Category)
                        .OrderByDescending(w => w.WriteOffDate)
                        .ToList();

                    int totalCount = allWriteOffs.Count;

                    // Поиск по названию товара
                    var searchText = txtSearch.Text.Trim().ToLower();
                    var afterSearch = new List<WriteOff>();

                    if (string.IsNullOrEmpty(searchText))
                    {
                        afterSearch = allWriteOffs;
                    }
                    else
                    {
                        foreach (var writeOff in allWriteOffs)
                        {
                            var productName = writeOff.Product?.Name?.ToLower() ?? "";
                            if (productName.Contains(searchText))
                            {
                                afterSearch.Add(writeOff);
                            }
                        }
                    }

                    // Фильтр по категории
                    var afterCategory = new List<WriteOff>();

                    if (cmbCategory.SelectedIndex <= 0 || cmbCategory.SelectedItem.ToString() == "Все")
                    {
                        afterCategory = afterSearch;
                    }
                    else
                    {
                        var selectedCategoryName = cmbCategory.SelectedItem.ToString();
                        foreach (var writeOff in afterSearch)
                        {
                            if (writeOff.Product?.Category?.Name == selectedCategoryName)
                            {
                                afterCategory.Add(writeOff);
                            }
                        }
                    }

                    // Фильтр по убытку
                    decimal lossFrom = 0;
                    decimal lossTo = 1000000;
                    decimal.TryParse(txtLossFrom.Text, out lossFrom);
                    decimal.TryParse(txtLossTo.Text, out lossTo);

                    if (lossFrom < 0) lossFrom = 0;
                    if (lossTo < 0) lossTo = 1000000;
                    if (lossFrom > lossTo) (lossFrom, lossTo) = (lossTo, lossFrom);

                    var afterLoss = new List<WriteOff>();
                    foreach (var writeOff in afterCategory)
                    {
                        if (writeOff.LossAmount >= lossFrom && writeOff.LossAmount <= lossTo)
                        {
                            afterLoss.Add(writeOff);
                        }
                    }

                    lblFound.Text = $"Найдено: {afterLoss.Count} из {totalCount}";

                    // Настройка таблицы
                    dgvWriteOffs.Rows.Clear();
                    dgvWriteOffs.Columns.Clear();

                    dgvWriteOffs.Columns.Add("colDate", "Дата списания");
                    dgvWriteOffs.Columns.Add("colProduct", "Товар");
                    dgvWriteOffs.Columns.Add("colCategory", "Категория");
                    dgvWriteOffs.Columns.Add("colQuantity", "Количество");
                    dgvWriteOffs.Columns.Add("colLoss", "Убыток");
                    dgvWriteOffs.Columns.Add("colReason", "Причина");

                    decimal totalLoss = 0;

                    foreach (var writeOff in afterLoss)
                    {
                        totalLoss += writeOff.LossAmount;

                        dgvWriteOffs.Rows.Add(
                            writeOff.WriteOffDate.ToString("dd.MM.yyyy"),
                            writeOff.Product?.Name ?? "—",
                            writeOff.Product?.Category?.Name ?? "—",
                            writeOff.Quantity,
                            CurrencyHelp.Format(writeOff.LossAmount),
                            writeOff.Reason
                        );
                    }

                    //lblTotalLoss.Text = $"Общая сумма убытков: {CurrencyHelp.Format(totalLoss)}";
                }
            }
            catch (Exception ex)
            {
                Logger.Fatal($"FATAL-04: Соединение с базой данных утеряно и не восстановлено.\n" +
                             $"Активный пользователь: {CurrentUser.User?.Login} | Роль: {CurrentUser.RoleName}\n" +
                             $"Текущая операция: Загрузка каталога товаров\n" +
                             $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                             $"Приложение будет завершено.", ex);
                MessageBox.Show("Потеряно соединение с базой данных.\nПриложение будет закрыто.",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWriteOffHistory();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbCategory.SelectedIndex = 0;
            cmbDate.SelectedIndex = 0;
            txtLossFrom.Text = "0";
            txtLossTo.Text = "1000000";
            LoadWriteOffHistory();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            CurrentUser.RoleName = null;
            var loginForm = Application.OpenForms.OfType<LoginForm>().FirstOrDefault();
            loginForm.ClearFields();
            loginForm.Show();
            loginForm.BringToFront();
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != loginForm)
                    form.Close();
            }
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var form = new ShipmentForm();
            form.ShowDialog();
            LoadWriteOffHistory();
        }

        private void btnMyShipments_Click(object sender, EventArgs e)
        {
            var form = new MyShipmentsForm();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadWriteOffHistory();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWriteOffHistory();
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWriteOffHistory();
        }

        private void btnSuplies_Click(object sender, EventArgs e)
        {
            var suppliesForm = new SuppliesForm();
            suppliesForm.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
            this.Close();
        }

        private void btnExpirationDates_Click(object sender, EventArgs e)
        {
            var expirationdates = new ExpirationDatesForm();
            expirationdates.ShowDialog();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new CurrencyForm();
            settingsForm.ShowDialog();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var form = new ShipmentHistoryForm();
            form.ShowDialog();
        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {

        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            var currencyform = new CurrencyForm();
            currencyform.ShowDialog();
            this.Close();
        }
    }

}


