using Newtonsoft.Json;
using Sklad_project_app.Import;


namespace Sklad_project_app
{
    public partial class SuppliesForm : Form
    {
        private PanelMode _currentMode = PanelMode.None;
        private Guid _selectedProductId = Guid.Empty;

        public SuppliesForm()
        {
            InitializeComponent();
            LoadProductsToComboBox();
            ConfigureAccessByRole();
            LoadSupplies();
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
        private void LoadProductsToComboBox()
        {
            using (var db = new SkladContext())
            {
                var products = db.Products
                .Include(p => p.Category)
                .ToList();
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = products;
                cmbProduct.SelectedIndex = -1;
            }
        }
        private void SuppliesCatalogForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToFilter();
            LoadSupplies();
            panelView.Visible = false;
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

        /// <summary>
        /// Асинхронно обновляет скидки на партии товаров на основе оставшегося срока годности.
        /// Если осталось меньше 20% от общего срока — устанавливает скидку 50%.
        /// Если срок вышел — устанавливает скидку 100%.
        /// Сохраняет изменения только если были реальные обновления.
        /// </summary>
        private async Task UpdateDiscountsFromExpiry()
        {
            using var db = new SkladContext();
            var today = DateTime.Now.Date;

            var batches = await db.StockBatches
                .Include(b => b.Product)
                .Where(b => !b.IsWrittenOff && b.Quantity > 0 && b.ExpiryDate != null)
                .ToListAsync();

            var changed = false;

            foreach (var batch in batches)
            {
                var daysLeft = (batch.ExpiryDate!.Value.Date - today).Days;
                var totalDays = batch.TotalDays;
                decimal newDiscount = 0;

                if (daysLeft <= 0)
                {
                    newDiscount = 100;
                }
                else if (totalDays > 0)
                {
                    var percentLeft = (double)daysLeft / totalDays * 100;
                    if (percentLeft <= 20)
                    {
                        newDiscount = 50;
                    }
                }

                if (batch.DiscountPercent != newDiscount)
                {
                    batch.DiscountPercent = newDiscount;
                    changed = true;
                }
            }

            if (changed)
                await db.SaveChangesAsync();
        }

        public void LoadSupplies()
        {
            try
            {
                UpdateDiscountsFromExpiry();
                using (var db = new SkladContext())
                {
                    var allSupplies = db.SuppliesItems
                        .Include(s => s.Product)
                        .ThenInclude(p => p.Category)
                        .Include(s => s.Product)
                        .Include(s => s.Supplies)
                        .OrderBy(s => s.Supplies.SuppliesDate)
                        .ToList();

                    int totalCount = allSupplies.Count;
                    var searchText = txtSearch.Text.Trim().ToLower();
                    var afterSearch = new List<SuppliesItem>();

                    if (string.IsNullOrEmpty(searchText))
                    {
                        afterSearch = allSupplies;
                    }
                    else
                    {
                        foreach (var supply in allSupplies)
                        {
                            var productName = supply.Product.Name.ToLower() ?? "";
                            var productArticle = supply.Product.Article.ToLower() ?? "";

                            if (productName.Contains(searchText) || productArticle.Contains(searchText))
                            {
                                afterSearch.Add(supply);
                            }
                        }
                    }

                    var afterCategory = new List<SuppliesItem>();

                    if (cmbCategory.SelectedIndex <= 0)
                    {
                        afterCategory = afterSearch;
                    }
                    else
                    {
                        var selectedCategoryName = cmbCategory.SelectedItem.ToString();
                        foreach (var supply in afterSearch)
                        {
                            if (supply.Product?.Category != null && supply.Product.Category.Name == selectedCategoryName)
                            {
                                afterCategory.Add(supply);
                            }
                        }
                    }

                    var afterDate = new List<SuppliesItem>();

                    if (cmbDate.SelectedIndex <= 0)
                    {
                        afterDate = afterCategory;
                    }
                    else
                    {
                        string selectedDateStr = cmbDate.SelectedItem.ToString();
                        DateTime selectedDate = DateTime.ParseExact(selectedDateStr, "dd.MM.yyyy", null);

                        foreach (var supply in afterCategory)
                        {
                            var supplyDate = supply.Supplies?.SuppliesDate.Date;

                            if (supplyDate == selectedDate)
                            {
                                afterDate.Add(supply);
                            }
                        }
                    }
                    decimal priceFrom = 0;
                    decimal priceTo = 1000000;
                    decimal.TryParse(txtPriceFrom.Text, out priceFrom);
                    decimal.TryParse(txtPriceTo.Text, out priceTo);

                    if (priceFrom < 0 || priceTo < 0)
                    {
                        MessageBox.Show("Цена не может быть отрицательной", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (priceFrom < 0) priceFrom = 0;
                        if (priceTo < 0) priceTo = 1000000;
                    }

                    if (priceFrom > priceTo)
                    {
                        (priceFrom, priceTo) = (priceTo, priceFrom);
                    }

                    var afterPrice = new List<SuppliesItem>();
                    foreach (var supply in afterDate)
                    {
                        if (supply.PurchasePrice >= priceFrom && supply.PurchasePrice <= priceTo)
                        {
                            afterPrice.Add(supply);
                        }
                    }

                    lblFound.Text = $"Найдено: {afterPrice.Count} из {totalCount}";

                    dgvProducts.Rows.Clear();
                    dgvProducts.Columns.Clear();

                    dgvProducts.Columns.Add("colArticle", "Артикул");
                    dgvProducts.Columns.Add("colProductName", "Товар");
                    dgvProducts.Columns.Add("colCategory", "Категория");
                    dgvProducts.Columns.Add("colQuantity", "Количество");
                    dgvProducts.Columns.Add("colPrice", "Цена закупки");
                    dgvProducts.Columns.Add("colExpiryDate", "Годен до");
                    dgvProducts.Columns.Add("colDate", "Дата поставки");
                    dgvProducts.Columns.Add("colSupplyId", "SupplyId");
                    dgvProducts.Columns.Add("colProductId", "ProductId");
                    dgvProducts.Columns.Add("colId", "ID");
                    dgvProducts.Columns["colId"].Visible = false;

                    dgvProducts.Columns["colSupplyId"].Visible = false;
                    dgvProducts.Columns["colProductId"].Visible = false;
                    dgvProducts.Columns["colId"].Visible = false;

                    foreach (var supply in afterPrice)
                    {
                        var productName = supply.Product.Name ?? "—";
                        var categoryName = supply.Product.Category?.Name ?? "—";
                        var article = supply.Product.Article ?? "—";
                        var supplyDate = supply.Supplies.SuppliesDate.ToString("dd.MM.yyyy") ?? "—";
                        var expiryDate = db.StockBatches
                            .Where(b => b.SuppliesId == supply.SuppliesId && b.ProductId == supply.ProductId)
                            .Select(b => b.ExpiryDate)
                            .FirstOrDefault();
                        var expiryDateStr = expiryDate?.ToString("dd.MM.yyyy") ?? "—";



                        dgvProducts.Rows.Add(
                            article,
                            productName,
                            categoryName,
                            supply.Quantity,
                            CurrencyHelp.Format(supply.PurchasePrice),
                            expiryDateStr,
                            supplyDate,
                            supply.SuppliesId,
                            supply.ProductId,
                            supply.Id
                        );
                    }
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите поставку для просмотра");
                return;
            }

            var selectedRow = dgvProducts.SelectedRows[0];
            string article = "";
            string productName = "";
            string category = "";
            string price = "";
            string quantity = "";
            string date = "";
            string expiryDate = "";

            if (dgvProducts.Columns.Contains("colArticle"))
                article = selectedRow.Cells["colArticle"].Value.ToString();

            if (dgvProducts.Columns.Contains("colProductName"))
                productName = selectedRow.Cells["colProductName"].Value.ToString();

            if (dgvProducts.Columns.Contains("colCategory"))
                category = selectedRow.Cells["colCategory"].Value.ToString();

            if (dgvProducts.Columns.Contains("colPrice"))
                price = selectedRow.Cells["colPrice"].Value.ToString();

            if (dgvProducts.Columns.Contains("colQuantity"))
                quantity = selectedRow.Cells["colQuantity"].Value.ToString();

            if (dgvProducts.Columns.Contains("colDate"))
                date = selectedRow.Cells["colDate"].Value.ToString();

            if (dgvProducts.Columns.Contains("colExpiryDate"))
                expiryDate = selectedRow.Cells["colExpiryDate"].Value.ToString();

            txtArticleView.Text = article;
            txtNameView.Text = productName;
            txtCategoryView.Text = category;
            txtPriceView.Text = price;
            txtRestView.Text = quantity;
            txtDateView.Text = date;
            txtExpirationDate.Text = expiryDate;

            txtArticleView.ReadOnly = true;
            txtNameView.ReadOnly = true;
            txtCategoryView.ReadOnly = true;
            txtPriceView.ReadOnly = true;
            txtRestView.ReadOnly = true;
            txtExpirationDate.ReadOnly = true;

            btnSave.Visible = false;
            dtpDate.Visible = false;
            cmbProduct.Visible = false;
            txtExpirationDate.Visible = true;
            lblExpirationDate.Text = "Годен до:";

            lblPanelTitle.Text = "Просмотр";
            panelView.Visible = true;
            panelView.BringToFront();

            cmbProduct.SelectedIndex = -1;
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            panelView.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSupplies();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbCategory.SelectedIndex = 0;
            cmbDate.SelectedIndex = 0;
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "1000000";
            LoadSupplies();
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
            LoadSupplies();
        }

        private void btnMyShipments_Click(object sender, EventArgs e)
        {
            var form = new MyShipmentsForm();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSupplies();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplies();
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplies();
        }

        private void btnSuplies_Click(object sender, EventArgs e)
        {

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

        private void btnAddComing_Click(object sender, EventArgs e)
        {
            _currentMode = PanelMode.Add;
            txtNameView.ReadOnly = false;
            txtDateView.ReadOnly = false;
            txtPriceView.ReadOnly = false;
            txtRestView.ReadOnly = false;
            txtArticleView.ReadOnly = true;

            dtpDate.Visible = true;
            btnSave.Visible = true;
            cmbProduct.Visible = true;

            txtExpirationDate.Visible = true;
            txtExpirationDate.ReadOnly = false;
            txtExpirationDate.Text = "";
            lblExpirationDate.Visible = true;

            panelView.Visible = true;
            panelView.BringToFront();
            lblPanelTitle.Text = "Добавление";

            txtArticleView.Text = "";
            txtNameView.Text = "";
            txtCategoryView.Text = "";
            txtDateView.Text = "";
            txtPriceView.Text = "";
            txtRestView.Text = "";

            cmbProduct.SelectedIndex = -1;
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"..\..\..\Files";
            ofd.Title = "Выберите JSON файл с поставками";
            ofd.Filter = "JSON файлы (*.json)|*.json";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            btnImport.Enabled = false;
            btnImport.Text = "Импорт...";

            try
            {
                var json = await File.ReadAllTextAsync(ofd.FileName);
                var supplies = JsonConvert.DeserializeObject<List<ImportSupplies>>(json);

                if (supplies == null || supplies.Count == 0)
                {
                    MessageBox.Show("Файл пуст или имеет неверный формат.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверяем ИНН поставщика перед импортом
                var checkResult = await CheckSupplierInnAsync(supplies);
                if (!checkResult.IsAllowed)
                {
                    MessageBox.Show(checkResult.ErrorMessage,
                        "Поставка отклонена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show(
                    "Найдено " + supplies.Count + " позиций. Импортировать?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                var importResult = await ImportSuppliesAsync(supplies, ofd.FileName);

                if (importResult.SkippedCount > 0)
                {
                    MessageBox.Show(
                        "Импорт завершён.\n" +
                        "Импортировано: " + importResult.ImportedCount + " позиций.\n" +
                        "Пропущено: " + importResult.SkippedCount + " позиций.\n\n" +
                        "Причины пропуска:\n" + string.Join("\n", importResult.SkippedReasons),
                        "Результат импорта",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Импорт завершён успешно.\n" +
                        "Импортировано: " + importResult.ImportedCount + " позиций.",
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadSupplies();
            }
            catch (Exception ex)
            {
                Logger.Error(
                    "ERROR-07: Общая ошибка при импорте JSON-файла поставки.\n" +
                    "Пользователь: " + CurrentUser.User?.Login + "\n" +
                    "Файл: " + ofd.FileName + "\n" +
                    "Исключение: " + ex.GetType() + " --- " + ex.Message + "\n" +
                    "Стек: " + ex.StackTrace, ex);

                MessageBox.Show("Ошибка при импорте: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnImport.Enabled = true;
                btnImport.Text = "Импорт";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            int quantity;

            if (!decimal.TryParse(txtPriceView.Text, out price))
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }

            if (!int.TryParse(txtRestView.Text, out quantity))
            {
                MessageBox.Show("Количество должно быть числом");
                return;
            }

            decimal priceInRub;
            if (CurrencyHelp.GetCurrentCurrency() != "RUB")
            {
                priceInRub = price * CurrencyHelp.GetCurrentRate();
            }
            else
            {
                priceInRub = price;
            }

            if (string.IsNullOrWhiteSpace(txtExpirationDate.Text))
            {
                MessageBox.Show("Введите срок годности (количество дней)", "Ошибка");
                return;
            }

            if (!int.TryParse(txtExpirationDate.Text, out int days) || days <= 0)
            {
                MessageBox.Show("Введите корректное количество дней (целое число больше 0)", "Ошибка");
                return;
            }

            DateTime expiryDate = dtpDate.Value.Date.AddDays(days).ToUniversalTime();
            int totalDays = days;

            var today = DateTime.Now.Date;
            int daysLeft = (expiryDate.Date - today).Days;
            decimal discount = 0;

            if (daysLeft <= 0)
            {
                discount = 100;
            }
            else if (totalDays > 0)
            {
                double percentLeft = (double)daysLeft / totalDays * 100;
                if (percentLeft <= 20)
                {
                    discount = 50;
                }
            }

            using (var db = new SkladContext())
            {
                if (cmbProduct.SelectedItem == null)
                {
                    MessageBox.Show("Выберите товар");
                    return;
                }

                var selectedProduct = (Product)cmbProduct.SelectedItem;
                var product = db.Products.Find(selectedProduct.Id);

                if (product == null)
                {
                    MessageBox.Show("Товар не найден");
                    return;
                }
                try
                {
                    var supply = new Supplies
                    {
                        Id = Guid.NewGuid(),
                        SuppliesDate = dtpDate.Value.ToUniversalTime(),
                        UserId = CurrentUser.User.Id,
                    };
                    db.Supplies.Add(supply);
                    await db.SaveChangesAsync();

                    var supplyItem = new SuppliesItem
                    {
                        Id = Guid.NewGuid(),
                        SuppliesId = supply.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        PurchasePrice = priceInRub,
                    };
                    db.SuppliesItems.Add(supplyItem);

                    var stockBatch = new StockBatch
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        SuppliesId = supply.Id,
                        Quantity = quantity,
                        PurchasePrice = priceInRub,
                        ExpiryDate = expiryDate,
                        TotalDays = totalDays,
                        DiscountPercent = discount,
                        IsWrittenOff = false
                    };
                    db.StockBatches.Add(stockBatch);
                    var stock = db.Stocks.FirstOrDefault(s => s.ProductId == product.Id);
                    if (stock != null)
                    {
                        stock.Rest += quantity;
                    }
                    else
                    {
                        stock = new Stock
                        {
                            Id = Guid.NewGuid(),
                            ProductId = product.Id,
                            Rest = quantity,
                            PurchasePrice = priceInRub
                        };
                        db.Stocks.Add(stock);
                    }

                    db.SaveChanges();
                    Logger.Debug($"DEBUG-07: Поставка успешно сохранена.\n" +
                         $"Пользователь: {CurrentUser.User?.Login}\n" +
                         $"SupplyId: {supply.Id} | Дата: {dtpDate.Value:dd.MM.yyyy}\n" +
                         $"Товар: {product.Name} | Артикул: {product.Article}\n" +
                         $"Количество: {quantity} | Цена: {priceInRub} руб.\n" +
                         $"Срок годности: {expiryDate:dd.MM.yyyy} | Осталось дней: {daysLeft} | Скидка: {discount}%\n" +
                         $"Время: {DateTime.Now}");

                }
                catch (Exception ex)
                {
                    Logger.Error($"ERROR-03: Не удалось сохранить поставку.\n" +
                                 $"Пользователь: {CurrentUser.User?.Login}\n" +
                                 $"Товар: {cmbProduct.Text} | Количество: {quantity} | Цена: {price}\n" +
                                 $"Срок годности: {days} дней\n" +
                                 $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                                 $"Стек: {ex.StackTrace}", ex);
                    MessageBox.Show("Ошибка сохранения поставки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            txtArticleView.Text = "";
            txtNameView.Text = "";
            txtPriceView.Text = "";
            txtRestView.Text = "";

            panelView.Visible = false;
            LoadSupplies();
            MessageBox.Show("Поставка сохранена!");
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1) return;

            var product = (Product)cmbProduct.SelectedItem;
            txtNameView.Text = product.Name;
            txtCategoryView.Text = product.Category?.Name ?? "";
            txtArticleView.Text = product.Article;
        }

        private void cmbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExpirationDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {
            var writeoffhistory = new WriteOffHistoryForm();
            writeoffhistory.ShowDialog();
            this.Close();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            var currencyform = new CurrencyForm();
            currencyform.ShowDialog();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var form = new ShipmentHistoryForm();
            form.ShowDialog();
            this.Close();
        }



        /// <summary>
        /// Проверяет ИНН поставщика по таблице чёрного списка в базе данных.
        /// Если контрагент найден — выводит предупреждение с причиной блокировки.
        /// Если не найден — подтверждает что поставщик чист.
        /// </summary>
        private void btnCheckSupplierBlacklist_Click(object sender, EventArgs e)
        {
            var inn = txtSupplierInn.Text.Trim();

            if (string.IsNullOrEmpty(inn))
            {
                MessageBox.Show("Введите ИНН поставщика для проверки.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inn.Length != 10 && inn.Length != 12)
            {
                MessageBox.Show("ИНН должен содержать 10 цифр (юрлицо) или 12 цифр (ИП).",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var ch in inn)
            {
                if (!char.IsDigit(ch))
                {
                    MessageBox.Show("ИНН должен содержать только цифры.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using var db = new SkladContext();
                var found = db.Blacklist.FirstOrDefault(b => b.Inn == inn);

                if (found != null)
                {
                    MessageBox.Show(
                        "ВНИМАНИЕ! Поставщик находится в чёрном списке!\n\n" +
                        "ИНН: " + found.Inn + "\n" +
                        "Наименование: " + (found.Name ?? "не указано") + "\n" +
                        "Причина блокировки: " + found.Reason + "\n" +
                        "Дата добавления: " + found.AddedDate.ToString("dd.MM.yyyy") + "\n\n" +
                        "Приём поставки от данного поставщика не рекомендуется.",
                        "Поставщик в чёрном списке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                        "ИНН " + inn + " не найден в чёрном списке.\n" +
                        "Поставщик не имеет ограничений по базе данных.",
                        "Проверка пройдена",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке контрагента: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Проверяет ИНН поставщика из списка позиций импорта по таблице чёрного списка.
        /// Берёт ИНН из первой позиции, у которой поле SupplierInn не пустое.
        /// Если ИНН отсутствует во всех позициях — предупреждает, но разрешает импорт.
        /// Если ИНН найден в чёрном списке — запрещает импорт и возвращает причину.
        /// </summary>
        private async Task<InnCheckResult> CheckSupplierInnAsync(List<ImportSupplies> supplies)
        {
            var inn = "";
            foreach (var item in supplies)
            {
                if (!string.IsNullOrWhiteSpace(item.SupplierInn))
                {
                    inn = item.SupplierInn.Trim();
                    break;
                }
            }

            if (string.IsNullOrEmpty(inn))
            {
                var warnResult = MessageBox.Show(
                    "В файле не указан ИНН поставщика (поле SupplierInn).\n" +
                    "Проверка по чёрному списку невозможна.\n\n" +
                    "Продолжить импорт без проверки?",
                    "ИНН не указан",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                return new InnCheckResult
                {
                    IsAllowed = warnResult == DialogResult.Yes,
                    ErrorMessage = "Импорт отменён пользователем из-за отсутствия ИНН поставщика."
                };
            }

            if (inn.Length != 10 && inn.Length != 12)
            {
                return new InnCheckResult
                {
                    IsAllowed = false,
                    ErrorMessage =
                        "Неверный формат ИНН поставщика: " + inn + "\n" +
                        "ИНН должен содержать 10 цифр (юрлицо) или 12 цифр (ИП).\n" +
                        "Исправьте файл и повторите импорт."
                };
            }

            foreach (var ch in inn)
            {
                if (!char.IsDigit(ch))
                {
                    return new InnCheckResult
                    {
                        IsAllowed = false,
                        ErrorMessage =
                            "ИНН поставщика содержит недопустимые символы: " + inn + "\n" +
                            "ИНН должен состоять только из цифр.\n" +
                            "Исправьте файл и повторите импорт."
                    };
                }
            }

            // Запрашиваем базу данных асинхронно
            try
            {
                using var db = new SkladContext();
                var blacklistEntry = await db.Blacklist
                    .FirstOrDefaultAsync(b => b.Inn == inn);

                if (blacklistEntry != null)
                {
                    Logger.Warn(
                        "WARN-11: Попытка импорта поставки от заблокированного поставщика.\n" +
                        "Пользователь: " + CurrentUser.User?.Login + "\n" +
                        "ИНН поставщика: " + inn + "\n" +
                        "Причина блокировки: " + blacklistEntry.Reason + "\n" +
                        "Импорт отклонён.");

                    return new InnCheckResult
                    {
                        IsAllowed = false,
                        ErrorMessage =
                            "ПОСТАВКА ОТКЛОНЕНА!\n\n" +
                            "Поставщик находится в чёрном списке.\n\n" +
                            "ИНН: " + blacklistEntry.Inn + "\n" +
                            "Наименование: " + (blacklistEntry.Name ?? "не указано") + "\n" +
                            "Причина блокировки: " + blacklistEntry.Reason + "\n" +
                            "Дата добавления в список: " + blacklistEntry.AddedDate.ToString("dd.MM.yyyy") + "\n\n" +
                            "Обратитесь к администратору для выяснения обстоятельств."
                    };
                }

                Logger.Debug(
                    "DEBUG-11: ИНН поставщика прошёл проверку по чёрному списку.\n" +
                    "Пользователь: " + CurrentUser.User?.Login + "\n" +
                    "ИНН: " + inn + "\n" +
                    "Время: " + DateTime.Now);

                return new InnCheckResult
                {
                    IsAllowed = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                Logger.Error(
                    "ERROR-12: Ошибка при проверке ИНН поставщика по чёрному списку.\n" +
                    "ИНН: " + inn + "\n" +
                    "Исключение: " + ex.GetType() + " --- " + ex.Message, ex);

                // При ошибке подключения к БД спрашиваем пользователя
                var continueResult = MessageBox.Show(
                    "Не удалось выполнить проверку ИНН по чёрному списку.\n" +
                    "Ошибка: " + ex.Message + "\n\n" +
                    "Продолжить импорт без проверки?",
                    "Ошибка проверки",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                return new InnCheckResult
                {
                    IsAllowed = continueResult == DialogResult.Yes,
                    ErrorMessage = "Импорт отменён из-за ошибки проверки ИНН."
                };
            }
        }

        /// <summary>
        /// Выполняет асинхронный импорт позиций поставки в базу данных.
        /// Для каждой позиции создаёт запись поставки, позицию поставки,
        /// партию товара (StockBatch) и обновляет общий остаток (Stock).
        /// Если товар по артикулу не найден — позиция пропускается.
        /// </summary>

        private async Task<ImportResult> ImportSuppliesAsync(List<ImportSupplies> supplies, string fileName)
        {
            var importedCount = 0;
            var skippedCount = 0;
            var skippedReasons = new List<string>();

            using var db = new SkladContext();

            foreach (var item in supplies)
            {
                // Ищем товар по артикулу или названию
                var product = await db.Products.FirstOrDefaultAsync(p =>
                    p.Article == item.Article || p.Name == item.ProductName);

                if (product == null)
                {
                    skippedCount++;
                    skippedReasons.Add(
                        "Товар '" + item.ProductName + "' (арт. " + item.Article + ") не найден в каталоге.");
                    continue;
                }

                var supply = new Supplies
                {
                    Id = Guid.NewGuid(),
                    SuppliesDate = item.Date.ToUniversalTime(),
                    UserId = CurrentUser.User.Id
                };
                db.Supplies.Add(supply);

                var supplyItem = new SuppliesItem
                {
                    Id = Guid.NewGuid(),
                    SuppliesId = supply.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    PurchasePrice = item.Price
                };
                db.SuppliesItems.Add(supplyItem);

                var totalDays = item.ExpiryDays > 0 ? item.ExpiryDays : 365;
                var expiryDate = item.Date.Date.AddDays(totalDays).ToUniversalTime();

                var stockBatch = new StockBatch
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    SuppliesId = supply.Id,
                    Quantity = item.Quantity,
                    PurchasePrice = item.Price,
                    ExpiryDate = expiryDate,
                    TotalDays = totalDays,
                    DiscountPercent = 0,
                    IsWrittenOff = false
                };
                db.StockBatches.Add(stockBatch);

                var stock = await db.Stocks.FirstOrDefaultAsync(s => s.ProductId == product.Id);
                if (stock != null)
                {
                    stock.Rest += item.Quantity;
                }
                else
                {
                    stock = new Stock
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        Rest = item.Quantity,
                        PurchasePrice = item.Price
                    };
                    db.Stocks.Add(stock);
                }

                importedCount++;
            }

            await db.SaveChangesAsync();

            Logger.Debug(
                "DEBUG-08: JSON-файл поставки успешно импортирован.\n" +
                "Пользователь: " + CurrentUser.User?.Login + "\n" +
                "Файл: " + fileName + "\n" +
                "Всего строк: " + supplies.Count +
                " | Импортировано: " + importedCount +
                " | Пропущено: " + skippedCount + "\n" +
                "Время: " + DateTime.Now);

            if (skippedCount > 0)
            {
                Logger.Warn(
                    "WARN-04: Пропущенные строки при импорте JSON.\n" +
                    "Пользователь: " + CurrentUser.User?.Login + "\n" +
                    "Файл: " + fileName + "\n" +
                    "Всего: " + supplies.Count +
                    " | Импортировано: " + importedCount +
                    " | Пропущено: " + skippedCount + "\n" +
                    "Причины: " + string.Join("; ", skippedReasons.Take(5)));
            }

            return new ImportResult
            {
                ImportedCount = importedCount,
                SkippedCount = skippedCount,
                SkippedReasons = skippedReasons
            };
        }

        private void btnCheckApiSupply_Click(object sender, EventArgs e)
        {

        }

        private void lblExpirationDate_Click(object sender, EventArgs e)
        {

        }

        private void lblRestView_Click(object sender, EventArgs e)
        {

        }

        private void txtPriceView_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblArticleEdit_Click(object sender, EventArgs e)
        {

        }
    }

}

