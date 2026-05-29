namespace Sklad_project_app
{
    public partial class ExpirationDatesForm : Form
    {
        private PanelMode _currentMode = PanelMode.None;
        private Guid _selectedProductId = Guid.Empty;

        public ExpirationDatesForm()
        {
            InitializeComponent();
            LoadExpiringProducts();
            this.Text = AppResources.CatalogTitle;
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }
        private void SuppliesCatalogForm_Load(object sender, EventArgs e)
        {
            LoadToFilter();
            LoadExpiringProducts();
        }

        private void LoadToFilter()
        {
            cmbDiscount.Items.Clear();
            cmbDiscount.Items.Add("Все");
            cmbDiscount.Items.Add("Норма");
            cmbDiscount.Items.Add("Скидка 50%");
            cmbDiscount.Items.Add("Просрочено");
            cmbDiscount.SelectedIndex = 0;
        }

        public async void LoadExpiringProducts()
        {
            try
            {
                using (var db = new SkladContext())
                {
                    var today = DateTime.Now.Date;

                    var batches = await db.StockBatches
                        .Include(b => b.Product)
                        .ThenInclude(p => p.Category)
                        .Where(b => b.IsWrittenOff == false && b.Quantity > 0 && b.ExpiryDate != null)
                        .ToListAsync();

                    dgvExpiry.Rows.Clear();
                    dgvExpiry.Columns.Clear();

                    dgvExpiry.Columns.Add("colId", "ID");
                    dgvExpiry.Columns.Add("colProduct", "Товар");
                    dgvExpiry.Columns.Add("colCategory", "Категория");
                    dgvExpiry.Columns.Add("colQuantity", "Остаток");
                    dgvExpiry.Columns.Add("colExpiry", "Годен до");
                    dgvExpiry.Columns.Add("colDaysLeft", "Дней осталось");
                    dgvExpiry.Columns.Add("colDiscount", "Скидка");
                    dgvExpiry.Columns.Add("colStatus", "Статус");
                    dgvExpiry.Columns["colId"].Visible = false;

                    string searchText = txtSearch.Text.Trim().ToLower();
                    string selectedStatus = cmbDiscount.SelectedItem?.ToString();

                    foreach (var batch in batches)
                    {
                        string productName = batch.Product?.Name ?? "";
                        if (!string.IsNullOrEmpty(searchText) && !productName.ToLower().Contains(searchText))
                        {
                            continue;
                        }
                        int daysLeft = (batch.ExpiryDate.Value.Date - today).Days;
                        decimal discount = batch.DiscountPercent;
                        string status = "";

                        if (daysLeft <= 0)
                        {
                            status = "Просрочен";
                            daysLeft = 0;
                            Logger.Warn($"WARN-06: Обнаружена просроченная партия товара.\n" +
                                $"Пользователь: {CurrentUser.User?.Login}\n" +
                                $"ProductId: {batch.ProductId} | Название: {batch.Product?.Name}\n" +
                                $"BatchId: {batch.Id}\n" +
                                $"Срок годности: {batch.ExpiryDate:dd.MM.yyyy} | Просрочено на: {-daysLeft} дней\n" +
                                $"Требуется списание.");
                        }
                        else if (discount > 0)
                        {
                            status = "Скидка есть";
                            Logger.Warn($"WARN-05: Товар приближается к истечению срока годности --- активирована скидка.\n" +
                                    $"Пользователь: {CurrentUser.User?.Login}\n" +
                                    $"ProductId: {batch.ProductId} | Название: {batch.Product?.Name}\n" +
                                    $"BatchId: {batch.Id}\n" +
                                    $"Срок годности: {batch.ExpiryDate:dd.MM.yyyy} | Осталось дней: {daysLeft}\n" +
                                    $"Установлена скидка: {discount}%");
                        }
                        else
                        {
                            status = "Норма";
                        }

                        if (selectedStatus != "Все" && status != selectedStatus)
                            continue;

                        dgvExpiry.Rows.Add(
                            batch.Id,
                            batch.Product?.Name ?? "—",
                            batch.Product?.Category?.Name ?? "—",
                            batch.Quantity,
                            batch.ExpiryDate.Value.ToString("dd.MM.yyyy"),
                            daysLeft,
                            $"{discount}%",
                            status
                        );

                        var row = dgvExpiry.Rows[dgvExpiry.Rows.Count - 1];
                        if (status == "Просрочен")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        else if (discount > 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    lblFound.Text = $"Найдено: {dgvExpiry.Rows.Count} из {batches.Count}";
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
            LoadExpiringProducts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbDiscount.SelectedIndex = 0;
            LoadExpiringProducts();
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
            LoadExpiringProducts();
        }

        private void btnMyShipments_Click(object sender, EventArgs e)
        {
            var form = new MyShipmentsForm();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadExpiringProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExpiringProducts();
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExpiringProducts();
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

        private void txtPriceFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            if (dgvExpiry.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для списания");
                return;
            }

            var selectedRow = dgvExpiry.SelectedRows[0];
            var batchId = (Guid)selectedRow.Cells["colId"].Value;
            var status = selectedRow.Cells["colStatus"].Value?.ToString();
            var productName = selectedRow.Cells["colProduct"].Value?.ToString();
            var quantity = selectedRow.Cells["colQuantity"].Value?.ToString();

            if (status != "Просрочен")
            {
                MessageBox.Show("Можно списывать только просроченные товары");
                return;
            }

            var result = MessageBox.Show(
                $"Списать товар '{productName}' в количестве {quantity} шт.?",
                "Подтверждение списания",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new SkladContext())
                {
                    try
                    {
                        var batch = db.StockBatches.Find(batchId);
                        if (batch != null)
                        {
                            decimal lossAmount = batch.Quantity * batch.PurchasePrice;
                            var writeOff = new WriteOff
                            {
                                Id = Guid.NewGuid(),
                                ProductId = batch.ProductId,
                                BatchId = batch.Id,
                                WriteOffDate = DateTime.Now.ToUniversalTime(),
                                Quantity = batch.Quantity,
                                LossAmount = lossAmount,
                                Reason = "Истёк срок годности"
                            };
                            db.WriteOffs.Add(writeOff);

                            batch.IsWrittenOff = true;
                            batch.Quantity = 0;
                            batch.DiscountPercent = 0;

                            var stock = db.Stocks.FirstOrDefault(s => s.ProductId == batch.ProductId);
                            if (stock != null)
                            {
                                stock.Rest -= batch.Quantity;
                            }

                            db.SaveChanges();
                            Logger.Debug($"DEBUG-09: Партия товара списана.\n" +
                                     $"Пользователь: {CurrentUser.User?.Login}\n" +
                                     $"WriteOffId: {writeOff.Id} | BatchId: {batch.Id}\n" +
                                     $"ProductId: {batch.ProductId} | Товар: {productName}\n" +
                                     $"Количество: {batch.Quantity} | Убыток: {lossAmount:F2} руб.\n" +
                                     $"Причина: Истёк срок годности\n" +
                                     $"Время: {DateTime.Now}");

                            MessageBox.Show($"Товар '{productName}' списан");
                            LoadExpiringProducts();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"ERROR-04: Не удалось выполнить списание партии.\n" +
                                     $"Пользователь: {CurrentUser.User?.Login}\n" +
                                     $"BatchId: {batchId} | ProductId: {selectedRow.Cells["colProductId"]?.Value}\n" +
                                     $"Товар: {productName} | Количество: {quantity}\n" +
                                     $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                                     $"Стек: {ex.StackTrace}", ex);
                        MessageBox.Show("Ошибка списания товара", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            var currencyform = new CurrencyForm();
            currencyform.ShowDialog();
            this.Close();
        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {
            var writeoffhistory = new WriteOffHistoryForm();
            writeoffhistory.ShowDialog();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var form = new ShipmentHistoryForm();
            form.ShowDialog();
        }
        private void btnHeatMap_Click(object sender, EventArgs e)
        {
            var form = new HeatMapForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает форму управления чёрным списком контрагентов.
        /// </summary>
        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            var form = new BlacklistForm();
            form.ShowDialog();
        }

    }
}


