using System.Data;
using System.Text;


namespace Sklad_project_app
{
    public partial class ReportsForm : Form
    {
        private Guid _selectedProductId = Guid.Empty;

        public ReportsForm()
        {
            InitializeComponent();
            this.Text = AppResources.CatalogTitle;
            txtProfitFrom.Text = "-1000000";
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadClientsToFilter();
            LoadReports();
            panelView.Visible = false;
        }

        private void LoadClientsToFilter()
        {
            using (var db = new SkladContext())
            {
                var clients = db.Clients.ToList();
                cmbClient.Items.Clear();
                cmbClient.Items.Add("Все");
                foreach (var client in clients)
                {
                    cmbClient.Items.Add(client.Name);
                }
                cmbClient.SelectedIndex = 0;
            }
        }

        public void LoadReports()
        {
            try
            {
                using (var db = new SkladContext())
                {
                    var allShipments = db.Shipments
                        .Include(s => s.Client)
                        .Include(s => s.ShipmentItems)
                        .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.Stock)
                        .OrderBy(s => s.ShipmentDate)
                        .ToList();

                    // Загружаем все поставки для расчёта себестоимости
                    var allSupplies = db.SuppliesItems
                        .Include(s => s.Supplies)
                        .ToList();

                    int totalCount = allShipments.Count;

                    DateTime dateFrom = dtpDateFrom.Value.Date;
                    DateTime dateTo = dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1);

                    var afterDate = new List<Shipment>();
                    foreach (var shipment in allShipments)
                    {
                        if (shipment.ShipmentDate >= dateFrom && shipment.ShipmentDate <= dateTo)
                        {
                            afterDate.Add(shipment);
                        }
                    }

                    var afterClient = new List<Shipment>();

                    if (cmbClient.SelectedIndex <= 0 || cmbClient.SelectedItem.ToString() == "Все")
                    {
                        afterClient = afterDate;
                    }
                    else
                    {
                        string selectedClientName = cmbClient.SelectedItem.ToString();
                        foreach (var shipment in afterDate)
                        {
                            if (shipment.Client != null && shipment.Client.Name == selectedClientName)
                            {
                                afterClient.Add(shipment);
                            }
                        }
                    }

                    decimal profitFrom = -1000000;
                    decimal profitTo = 1000000;

                    if (!string.IsNullOrWhiteSpace(txtProfitFrom.Text))
                        decimal.TryParse(txtProfitFrom.Text, out profitFrom);
                    if (!string.IsNullOrWhiteSpace(txtProfitTo.Text))
                        decimal.TryParse(txtProfitTo.Text, out profitTo);

                    if (profitFrom > profitTo)
                    {
                        (profitFrom, profitTo) = (profitTo, profitFrom);
                    }

                    var afterProfit = new List<Shipment>();
                    foreach (var shipment in afterClient)
                    {
                        decimal shipmentProfit = 0;
                        foreach (var item in shipment.ShipmentItems)
                        {
                            decimal catalogPrice = item.Product?.Stock?.PurchasePrice ?? 0;
                            decimal calculatedAmount = catalogPrice * item.Quantity;

                            var supplies = allSupplies
                                .Where(s => s.ProductId == item.ProductId && s.Supplies.SuppliesDate <= shipment.ShipmentDate)
                                .ToList();

                            decimal totalCost = supplies.Sum(s => s.PurchasePrice * s.Quantity);
                            decimal totalQty = supplies.Sum(s => s.Quantity);
                            decimal avgPrice = totalQty > 0 ? totalCost / totalQty : 0;

                            shipmentProfit += calculatedAmount - (avgPrice * item.Quantity);
                        }

                        if (shipmentProfit >= profitFrom && shipmentProfit <= profitTo)
                        {
                            afterProfit.Add(shipment);
                        }
                    }

                    lblFound.Text = $"Найдено: {afterProfit.Count} из {totalCount}";

                    dgvReports.Rows.Clear();
                    dgvReports.Columns.Clear();
                    dgvReports.Columns.Add("colDate", "Дата");
                    dgvReports.Columns.Add("colClient", "Покупатель");
                    dgvReports.Columns.Add("colAmount", "Сумма");
                    dgvReports.Columns.Add("colProfit", "Прибыль");

                    decimal totalAmount = 0;
                    decimal totalProfit = 0;

                    foreach (var shipment in afterProfit)
                    {
                        decimal shipmentAmount = 0;
                        decimal shipmentProfit = 0;

                        foreach (var item in shipment.ShipmentItems)
                        {
                            decimal catalogPrice = item.Product?.Stock?.PurchasePrice ?? 0;
                            decimal calculatedAmount = catalogPrice * item.Quantity;
                            shipmentAmount += calculatedAmount;

                            var supplies = allSupplies
                                .Where(s => s.ProductId == item.ProductId && s.Supplies.SuppliesDate <= shipment.ShipmentDate)
                                .ToList();

                            decimal totalCost = supplies.Sum(s => s.PurchasePrice * s.Quantity);
                            decimal totalQty = supplies.Sum(s => s.Quantity);
                            decimal avgPrice = totalQty > 0 ? totalCost / totalQty : 0;

                            decimal cost = avgPrice * item.Quantity;
                            decimal profit = calculatedAmount - cost;

                            shipmentProfit += profit;
                        }

                        totalAmount += shipmentAmount;
                        totalProfit += shipmentProfit;

                        dgvReports.Rows.Add(
                            shipment.ShipmentDate?.ToString("dd.MM.yyyy") ?? "—",
                            shipment.Client?.Name ?? "—",
                            CurrencyHelp.Format(shipmentAmount),
                            CurrencyHelp.Format(shipmentProfit)
                        );
                    }

                    // Убытки
                    var allWriteOffs = db.WriteOffs.ToList();
                    var filteredByDate = new List<WriteOff>();
                    foreach (var w in allWriteOffs)
                    {
                        if (w.WriteOffDate >= dateFrom && w.WriteOffDate <= dateTo)
                        {
                            filteredByDate.Add(w);
                        }
                    }

                    decimal totalWriteOffLoss = filteredByDate.Sum(w => w.LossAmount);
                    string formattedLoss = CurrencyHelp.Format(totalWriteOffLoss);
                    dgvReports.Rows.Add("Убыток (списанное):", "", "", $"-{formattedLoss}");
                    decimal netProfit = totalProfit - totalWriteOffLoss;
                    dgvReports.Rows.Add("ИТОГО:", "", CurrencyHelp.Format(totalAmount), CurrencyHelp.Format(netProfit));
                }
            }
            catch (Exception ex)
            {
                Logger.Fatal($"FATAL-04: Ошибка при формировании отчёта.\n" +
                             $"Активный пользователь: {CurrentUser.User?.Login} | Роль: {CurrentUser.RoleName}\n" +
                             $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                             $"Стек: {ex.StackTrace}", ex);
                MessageBox.Show("Потеряно соединение с базой данных.\nПриложение будет закрыто.",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                string dateFrom = dtpDateFrom.Value.ToString("dd.MM.yyyy");
                string dateTo = dtpDateTo.Value.ToString("dd.MM.yyyy");

                // Формируем имя файла
                saveDialog.FileName = $"Отчет_{dateFrom}-{dateTo}.csv";
                saveDialog.Filter = "CSV files (*.csv)|*.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveDialog.FileName);
                }
            }
        }

        private void ExportToCSV(string filePath)
        {
            try
            {
                var sb = new StringBuilder();

                // Заголовки
                sb.AppendLine("Дата;Покупатель;Сумма, руб.;Прибыль, руб.");

                // Данные из DataGridView (кроме последней строки "ИТОГО")
                for (int i = 0; i < dgvReports.Rows.Count - 1; i++)
                {
                    var row = dgvReports.Rows[i];
                    if (row.IsNewRow) continue;

                    var date = row.Cells["colDate"].Value?.ToString() ?? "";
                    var client = row.Cells["colClient"].Value?.ToString() ?? "";
                    var amount = row.Cells["colAmount"].Value?.ToString() ?? "";
                    var profit = row.Cells["colProfit"].Value?.ToString() ?? "";

                    sb.AppendLine($"{date};{client};{amount};{profit}");
                }

                // Итоговая строка
                var lastRow = dgvReports.Rows[dgvReports.Rows.Count - 1];
                sb.AppendLine($"ИТОГО;;{lastRow.Cells["colAmount"].Value?.ToString() ?? ""};{lastRow.Cells["colProfit"].Value?.ToString() ?? ""}");

                // Сохраняем файл
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                MessageBox.Show($"Отчёт сохранён:\n{filePath}", "Экспорт выполнен",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR-08: Не удалось экспортировать отчёт в CSV.\n" +
                             $"Пользователь: {CurrentUser.User?.Login}\n" +
                             $"Путь сохранения: {filePath}\n" +
                             $"Период отчёта: {dtpDateFrom.Value:dd.MM.yyyy} - {dtpDateTo.Value:dd.MM.yyyy}\n" +
                             $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                             $"Стек: {ex.StackTrace}", ex);
                MessageBox.Show($"Ошибка при экспорте отчёта: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            panelView.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
            LoadClientsToFilter();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbClient.SelectedIndex = 0;
            txtProfitFrom.Text = "0";
            txtProfitTo.Text = "1000000";
            LoadReports();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void btnSuplies_Click(object sender, EventArgs e)
        {
            var suppliesForm = new SuppliesForm();
            suppliesForm.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

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

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void txtProfitFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {
            var writeoffhistory = new WriteOffHistoryForm();
            writeoffhistory.ShowDialog();
            this.Close();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var form = new ShipmentHistoryForm();
            form.ShowDialog();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            var currencyform = new CurrencyForm();
            currencyform.ShowDialog();
            this.Close();
        }
    }
}

