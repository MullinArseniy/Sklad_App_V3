namespace Sklad_project_app
{
    public partial class CurrencyForm : Form
    {
        private Dictionary<string, decimal> _allRates = new Dictionary<string, decimal>();
        private DateTime _lastUpdate = DateTime.Now;

        public CurrencyForm()
        {
            InitializeComponent();
            LoadCurrencies();
            LoadExchangeRates();
            LoadCurrentCurrency();
            this.Text = AppResources.CatalogTitle;
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }

        private void LoadCurrencies()
        {
            dgvCurrencies.Rows.Clear();
            dgvCurrencies.Columns.Clear();

            dgvCurrencies.Columns.Add("colCurrency", "Валюта");
            dgvCurrencies.Columns.Add("colRate", "Курс к RUB");
            dgvCurrencies.Columns.Add("colDate", "Дата обновления");

            if (_allRates.Count == 0)
            {
                dgvCurrencies.Rows.Add("USD", "84.50", DateTime.Now.ToString("dd.MM.yyyy"));
                dgvCurrencies.Rows.Add("EUR", "97.00", DateTime.Now.ToString("dd.MM.yyyy"));
            }
            decimal priceFrom = 0;
            decimal priceTo = 1000000;
            decimal.TryParse(txtPriceFrom.Text, out priceFrom);
            decimal.TryParse(txtPriceTo.Text, out priceTo);

            if (priceFrom < 0) priceFrom = 0;
            if (priceTo < 0) priceTo = 1000000;

            if (priceFrom > priceTo)
            {
                (priceFrom, priceTo) = (priceTo, priceFrom);
            }
            int filteredCount = 0;
            foreach (var rate in _allRates.OrderBy(r => r.Key))
            {
                if (rate.Value >= priceFrom && rate.Value <= priceTo)
                {
                    dgvCurrencies.Rows.Add(
                        rate.Key,
                        rate.Value.ToString("F2"),
                        _lastUpdate.ToString("dd.MM.yyyy")
                    );
                    filteredCount++;
                }
            }
            lblFound.Text = $"Найдено: {filteredCount} из {_allRates.Count}";
        }
        private async void btnUpdateCurrency_Click(object sender, EventArgs e)
        {
            await LoadExchangeRates();
        }

        private void LoadCurrentCurrency()
        {
            string currency = CurrencyHelp.GetCurrentCurrency();
            lblCurrentCurrency.Text = $"Текущая валюта: {currency}";
        }

        private async Task LoadExchangeRates()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = "https://api.exchangerate-api.com/v4/latest/RUB";
                    var response = await client.GetStringAsync(url);
                    var data = JsonSerializer.Deserialize<ExchangeRateResponse>(response);
                    // WARN-10 - API курса валют вернул пустой ответ
                    if (data?.rates == null || data.rates.Count == 0)
                    {
                        Logger.Warn($"WARN-10: API курса валют вернул неожиданный ответ.\n" +
                                    $"Ответ не содержит данных о курсах.\n" +
                                    $"Курс не обновлён.");
                        MessageBox.Show("Не удалось получить курсы валют. Используются сохранённые значения.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (data?.rates != null)
                    {
                        _allRates.Clear();

                        foreach (var rate in data.rates)
                        {
                            if (rate.Value > 0)
                            {
                                _allRates[rate.Key] = 1 / (decimal)rate.Value;
                            }
                        }

                        _lastUpdate = DateTime.Now;
                        CurrencyHelp.SetRates(_allRates);
                        LoadCurrencies();
                        Logger.Debug($"DEBUG-10: Курс валюты успешно загружен.\n" +
                         $"Пользователь: {CurrentUser.User?.Login}\n" +
                         $"USD: {_allRates.GetValueOrDefault("USD", 0):F2} руб. | EUR: {_allRates.GetValueOrDefault("EUR", 0):F2} руб.\n" +
                         $"Загружено валют: {_allRates.Count}\n" +
                         $"Время: {DateTime.Now}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR-05: Не удалось загрузить курс валют.\n" +
                     $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                     $"Стек: {ex.StackTrace}", ex);
                MessageBox.Show("Не удалось обновить курсы валют. Используются сохранённые значения.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCloseView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _ = LoadExchangeRates();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "1000000";
            LoadCurrencies();
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
        }

        private void btnMyShipments_Click(object sender, EventArgs e)
        {
            var form = new MyShipmentsForm();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            dgvCurrencies.Rows.Clear();

            var filtered = _allRates
                .Where(r => r.Key.ToLower().Contains(search))
                .OrderBy(r => r.Key);

            int count = 0;
            foreach (var rate in filtered)
            {
                dgvCurrencies.Rows.Add(
                    rate.Key,
                    rate.Value.ToString("F2"),
                    _lastUpdate.ToString("dd.MM.yyyy")
                );
                count++;
            }

            if (string.IsNullOrEmpty(search))
            {
                lblFound.Text = $"Найдено: {_allRates.Count} из {_allRates.Count}";
            }
            else
            {
                lblFound.Text = $"Найдено: {count} из {_allRates.Count}";
            }
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
            var currencyform = new CurrencyForm();
            currencyform.ShowDialog();
            this.Close();
        }

        private void txtPriceFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvCurrencies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите валюту из таблицы");
                return;
            }

            var selectedRow = dgvCurrencies.SelectedRows[0];
            string currencyCode = selectedRow.Cells["colCurrency"].Value?.ToString();

            if (string.IsNullOrEmpty(currencyCode)) return;

            try
            {
                CurrencyHelp.SetCurrency(currencyCode);
                LoadCurrentCurrency();

                foreach (Form form in Application.OpenForms)
                {
                    if (form is StorekeeperCatalogForm catalog)
                        catalog.LoadProducts();
                    else if (form is SuppliesForm supplies)
                        supplies.LoadSupplies();
                    else if (form is ReportsForm reports)
                        reports.LoadReports();
                    else if (form is MyShipmentsForm myShipments)
                        myShipments.LoadMyShipments();
                    else if (form is AdminCatalogForm catalog2)
                        catalog2.LoadProducts();
                    else if (form is ShipmentForm shipment)
                        shipment.LoadProducts();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR-06: Не удалось сохранить настройки валюты.\n" +
                             $"Пользователь: {CurrentUser.User?.Login}\n" +
                             $"Выбранная валюта: {currencyCode}\n" +
                             $"Исключение: {ex.GetType()} --- {ex.Message}", ex);
                MessageBox.Show("Ошибка сохранения настроек валюты", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show($"Валюта изменена на {currencyCode}");
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
