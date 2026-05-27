namespace Sklad_project_app
{
    public partial class StorekeeperCatalogForm : Form
    {
        private Guid _selectedProductId = Guid.Empty;

        public StorekeeperCatalogForm()
        {
            InitializeComponent();
            this.Text = AppResources.CatalogTitle;
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }

        private void StorekeeperCatalogForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToFilter();
            LoadProducts();
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
            }

            cmbAvailability.Items.Clear();
            cmbAvailability.Items.Add(AppResources.FilterAvailAll);
            cmbAvailability.Items.Add(AppResources.FilterAvailIn);
            cmbAvailability.Items.Add(AppResources.FilterAvailOut);
            cmbAvailability.SelectedIndex = 0;
        }

        public async void LoadProducts()
        {
            try
            {
                using (var db = new SkladContext())
                {
                    var allProducts = await db.Products
                        .Include("Category")
                        .Include("Unit")
                        .Include("Stock")
                        .ToListAsync();

                    int totalCount = allProducts.Count;

                    var searchText = txtSearch.Text.Trim().ToLower();
                    var afterSearch = new List<Product>();

                    if (string.IsNullOrEmpty(searchText))
                    {
                        afterSearch = allProducts;
                    }
                    else
                    {
                        foreach (var product in allProducts)
                        {
                            var productName = "";
                            var productArticle = "";

                            if (product.Name != null)
                            {
                                productName = product.Name.ToLower();
                            }
                            if (product.Article != null)
                            {
                                productArticle = product.Article.ToLower();
                            }

                            if (productName.Contains(searchText) || productArticle.Contains(searchText))
                            {
                                afterSearch.Add(product);
                            }
                        }
                    }

                    var afterCategory = new List<Product>();

                    if (cmbCategory.SelectedIndex <= 0)
                    {
                        afterCategory = afterSearch;
                    }
                    else
                    {
                        var selectedCategoryName = cmbCategory.SelectedItem.ToString();
                        foreach (var product in afterSearch)
                        {
                            if (product.Category != null && product.Category.Name == selectedCategoryName)
                            {
                                afterCategory.Add(product);
                            }
                        }
                    }

                    var afterAvailability = new List<Product>();

                    if (cmbAvailability.SelectedIndex == 1)
                    {
                        foreach (var product in afterCategory)
                        {
                            if (product.Stock != null && product.Stock.Rest > 0)
                            {
                                afterAvailability.Add(product);
                            }
                        }
                    }
                    else if (cmbAvailability.SelectedIndex == 2)
                    {
                        foreach (var product in afterCategory)
                        {
                            if (product.Stock == null || product.Stock.Rest == 0)
                            {
                                afterAvailability.Add(product);
                            }
                        }
                    }
                    else
                    {
                        afterAvailability = afterCategory;
                    }

                    decimal priceFrom = 0;
                    decimal priceTo = 1000000;
                    decimal.TryParse(txtPriceFrom.Text, out priceFrom);
                    decimal.TryParse(txtPriceTo.Text, out priceTo);

                    if (priceFrom < 0 || priceTo < 0)
                    {
                        MessageBox.Show(AppResources.MsgNegativePrice, AppResources.MsgInputError,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (priceFrom < 0)
                        {
                            priceFrom = 0;
                        }
                        if (priceTo < 0)
                        {
                            priceTo = 100000;
                        }
                    }

                    var afterPrice = new List<Product>();
                    foreach (var product in afterAvailability)
                    {
                        if (product.Stock != null &&
                            product.Stock.PurchasePrice >= priceFrom &&
                            product.Stock.PurchasePrice <= priceTo)
                        {
                            afterPrice.Add(product);
                        }
                    }

                    lblFound.Text = AppResources.LblFoundFormat + afterPrice.Count
                        + " " + AppResources.LblFoundOf + " " + totalCount;

                    dgvProducts.Rows.Clear();
                    dgvProducts.Columns.Clear();
                    dgvProducts.Columns.Add("colArticle", AppResources.ColArticle);
                    dgvProducts.Columns.Add("colName", AppResources.ColName);
                    dgvProducts.Columns.Add("colCategory", AppResources.ColCategory);
                    dgvProducts.Columns.Add("colUnit", AppResources.ColUnit);
                    dgvProducts.Columns.Add("colPrice", AppResources.ColPrice);
                    dgvProducts.Columns.Add("colRest", AppResources.ColRest);
                    dgvProducts.Columns.Add("colDiscount", "Скидка");
                    dgvProducts.Columns.Add("colId", "ID");
                    dgvProducts.Columns["colId"].Visible = false;

                    foreach (var product in afterPrice)
                    {
                        var price = "—";
                        var rest = "—";
                        var categoryName = "";
                        var unitName = "";
                        var hasDiscount = "Нет";

                        if (product.Stock != null)
                        {
                            var hasActiveDiscount =await db.StockBatches
                        .AnyAsync(b => b.ProductId == product.Id && !b.IsWrittenOff && b.Quantity > 0 && b.DiscountPercent > 0);
                            hasDiscount = hasActiveDiscount ? "Да" : "Нет";
                            price = CurrencyHelp.Format(product.Stock.PurchasePrice);
                            rest = product.Stock.Rest.ToString();
                        }

                        if (product.Category != null)
                        {
                            categoryName = product.Category.Name;
                        }
                        if (product.Unit != null)
                        {
                            unitName = product.Unit.Name;
                        }

                        int rowIndex = dgvProducts.Rows.Add(product.Article, product.Name,
                            categoryName, unitName, price, rest, hasDiscount, product.Id);

                        if (hasDiscount == "Да")
                        {
                            dgvProducts.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                    }
                }
            }
            //FATAL-04 — Потеря соединения с БД в процессе работы (все повторные попытки исчерпаны)
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
                MessageBox.Show(AppResources.MsgSelectView);
                return;
            }

            var selectedRow = dgvProducts.SelectedRows[0];
            var idValue = selectedRow.Cells["colId"].Value?.ToString();

            Guid productId;
            if (!Guid.TryParse(idValue, out productId))
            {
                return;
            }

            _selectedProductId = productId;
            LoadProductToViewPanel(_selectedProductId);
            lblPanelTitle.Text = AppResources.PanelView;
            panelView.Visible = true;
            panelView.BringToFront();
        }

        private void LoadProductToViewPanel(Guid productId)
        {
            using (var db = new SkladContext())
            {
                var allProducts = db.Products
                    .Include("Category")
                    .Include("Unit")
                    .Include("Stock")
                    .ToList();

                Product foundProduct = null;
                foreach (var product in allProducts)
                {
                    if (product.Id == productId)
                    {
                        foundProduct = product;
                        break;
                    }
                }

                if (foundProduct == null)
                {
                    return;
                }

                txtArticleView.Text = foundProduct.Article;
                txtNameView.Text = foundProduct.Name;

                if (foundProduct.Category != null)
                {
                    txtCategoryView.Text = foundProduct.Category.Name;
                }
                else
                {
                    txtCategoryView.Text = "";
                }

                if (foundProduct.Unit != null)
                {
                    txtUnitView.Text = foundProduct.Unit.Name;
                }
                else
                {
                    txtUnitView.Text = "";
                }

                if (foundProduct.Stock != null)
                {
                    txtPriceView.Text = foundProduct.Stock.PurchasePrice.ToString("0") + " руб.";
                    txtRestView.Text = foundProduct.Stock.Rest.ToString();
                }
                else
                {
                    txtPriceView.Text = "—";
                    txtRestView.Text = "—";
                }
            }
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            panelView.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbCategory.SelectedIndex = 0;
            cmbAvailability.SelectedIndex = 0;
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "1000000";
            LoadProducts();
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
            panelView.Visible = false;
            LoadProducts();
        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            var form = new ShipmentForm();
            form.ShowDialog();
            LoadProducts();
        }

        private void btnMyShipments_Click(object sender, EventArgs e)
        {
            var form = new MyShipmentsForm();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cmbAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSuplies_Click(object sender, EventArgs e)
        {
            var suppliesForm = new SuppliesForm();
            suppliesForm.ShowDialog();
            LoadProducts();
        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {
            var writeoffhistory = new WriteOffHistoryForm();
            writeoffhistory.ShowDialog();
        }
    }
}