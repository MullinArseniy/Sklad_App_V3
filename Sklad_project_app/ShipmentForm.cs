namespace Sklad_project_app
{
    public partial class ShipmentForm : Form
    {
        private Dictionary<Guid, ShipmentItemInfo> _shipmentItems = new Dictionary<Guid, ShipmentItemInfo>();

        public ShipmentForm()
        {
            InitializeComponent();
            lblUserInfo.Text = AppResources.LblStorekeeper
                + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
        }

        private void ShipmentForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToFilter();
            LoadProducts();
            LoadCitiesToComboBox();
            dtpDate.Value = DateTime.Today;
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
                        .Include("Stock")
                        .ToListAsync();

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

                    dgvShipment.Rows.Clear();
                    dgvShipment.Columns.Clear();

                    dgvShipment.Columns.Add("colArticle", AppResources.ColArticle);
                    dgvShipment.Columns.Add("colName", AppResources.ColName);
                    dgvShipment.Columns.Add("colCategory", AppResources.ColCategory);
                    dgvShipment.Columns.Add("colPrice", "Цена");
                    dgvShipment.Columns.Add("colDiscount", "Скидка");
                    dgvShipment.Columns.Add("colRest", AppResources.ColRest);

                    var btnMinus = new DataGridViewButtonColumn();
                    btnMinus.Name = "colMinus";
                    btnMinus.HeaderText = "";
                    btnMinus.Text = "-";
                    btnMinus.UseColumnTextForButtonValue = true;
                    dgvShipment.Columns.Add(btnMinus);

                    dgvShipment.Columns.Add("colQty", "Взято");

                    var btnPlus = new DataGridViewButtonColumn();
                    btnPlus.Name = "colPlus";
                    btnPlus.HeaderText = "";
                    btnPlus.Text = "+";
                    btnPlus.UseColumnTextForButtonValue = true;
                    dgvShipment.Columns.Add(btnPlus);

                    dgvShipment.Columns.Add("colId", "ID");
                    dgvShipment.Columns["colId"].Visible = false;

                    foreach (var product in afterAvailability)
                    {
                        var price = "—";
                        var discount = "Нет";
                        var rest = "0";
                        var categoryName = "";

                        if (product.Stock != null)
                        {
                            var maxDiscount = await db.StockBatches
                                .Where(b => b.ProductId == product.Id && !b.IsWrittenOff && b.Quantity > 0)
                                .OrderByDescending(b => b.DiscountPercent)
                                .Select(b => b.DiscountPercent)
                                .FirstOrDefaultAsync();

                            decimal originalPrice = product.Stock.PurchasePrice;

                            if (maxDiscount > 0)
                            {
                                decimal discountedPrice = originalPrice * (1 - maxDiscount / 100);
                                price = $"{CurrencyHelp.Format(originalPrice)} → {CurrencyHelp.Format(discountedPrice)}";
                                discount = $"{maxDiscount}%";
                            }
                            else
                            {
                                price = CurrencyHelp.Format(originalPrice);
                                discount = "Нет";
                            }

                            rest = product.Stock.Rest.ToString();
                        }

                        if (product.Category != null)
                        {
                            categoryName = product.Category.Name;
                        }

                        int qty = 0;
                        if (_shipmentItems.ContainsKey(product.Id))
                        {
                            qty = _shipmentItems[product.Id].Quantity;
                        }

                        int rowIndex = dgvShipment.Rows.Add(
                            product.Article,
                            product.Name,
                            categoryName,
                            price,
                            discount,
                            rest,
                            "-",
                            qty.ToString(),
                            "+",
                            product.Id
                        );

                        if (discount != "Нет")
                        {
                            dgvShipment.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                    }

                    UpdateTotal();
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

        private void UpdateTotal()
        {
            int total = _shipmentItems.Values.Sum(i => i.Quantity);
            decimal totalAmount = _shipmentItems.Values.Sum(i => i.TotalPrice);

            lblTotal.Text = $"{AppResources.LblTotalItems}\n{total} шт.\nСумма: {CurrencyHelp.Format(totalAmount)}";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var clientName = txtClientName.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show(AppResources.MsgClientEmpty);
                return;
            }

            if (_shipmentItems.Count == 0)
            {
                MessageBox.Show(AppResources.MsgNoItems);
                return;
            }

            using (var db = new SkladContext())
            {
                try
                {
                    decimal totalAmount = 0;
                    foreach (var item in _shipmentItems.Values)
                    {
                        var available = await db.StockBatches
                            .Where(b => b.ProductId == item.ProductId && !b.IsWrittenOff && b.Quantity > 0)
                            .SumAsync(b => b.Quantity);

                        if (available < item.Quantity)
                        {
                            // WARN-09: Финальная проверка остатков перед отгрузкой не пройдена
                            Logger.Warn($"WARN-09: Финальная проверка остатков перед отгрузкой не пройдена.\n" +
                                        $"Пользователь: {CurrentUser.User?.Login}\n" +
                                        $"ProductId: {item.ProductId} | Товар: {item.ProductName}\n" +
                                        $"Запрошено: {item.Quantity} | Актуальный остаток: {available}\n" +
                                        $"Отгрузка не создана.");
                            MessageBox.Show($"Недостаточно товара: {item.ProductName}\n" +
                                           $"Доступно: {available} шт., запрошено: {item.Quantity} шт.");
                            return;
                        }
                    }

                    var foundClient = await db.Clients.FirstOrDefaultAsync(c => c.Name == clientName);
                    if (foundClient == null)
                    {
                        foundClient = new Client { Id = Guid.NewGuid(), Name = clientName };
                        db.Clients.Add(foundClient);
                        await db.SaveChangesAsync();
                    }

                    var newShipment = new Shipment
                    {
                        Id = Guid.NewGuid(),
                        ClientId = foundClient.Id,
                        UserId = CurrentUser.User.Id,
                        ShipmentDate = dtpDate.Value.ToUniversalTime()
                    };
                    db.Shipments.Add(newShipment);
                    db.SaveChanges();

                    Logger.Debug($"DEBUG-06: Отгрузка успешно создана.\n" +
                         $"Пользователь: {CurrentUser.User?.Login}\n" +
                         $"ShipmentId: {newShipment.Id} | Клиент: {clientName}\n" +
                         $"Дата: {dtpDate.Value:dd.MM.yyyy}\n" +
                         $"Позиций: {_shipmentItems.Count} | Сумма: {totalAmount:F2} руб.\n" +
                         $"Время: {DateTime.Now}");

                    foreach (var item in _shipmentItems.Values)
                    {
                        foreach (var (batch, take) in item.Batches)
                        {
                            var currentBatch = db.StockBatches.Find(batch.Id);
                            currentBatch.Quantity -= take;

                            decimal priceWithDiscount = batch.PurchasePrice * (1 - batch.DiscountPercent / 100);

                            db.ShipmentItems.Add(new ShipmentItem
                            {
                                Id = Guid.NewGuid(),
                                ShipmentId = newShipment.Id,
                                ProductId = item.ProductId,
                                Quantity = take,
                                Amount = priceWithDiscount * take
                            });
                        }

                        // общий остаток
                        var stock = await db.Stocks.FirstOrDefaultAsync(s => s.ProductId == item.ProductId);
                        if (stock != null)
                        {
                            stock.Rest -= item.Quantity;
                        }
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Error($"ERROR-02: Не удалось сохранить отгрузку.\n" +
                                 $"Пользователь: {CurrentUser.User?.Login} | Роль: {CurrentUser.RoleName}\n" +
                                 $"Клиент: {clientName} | Дата: {dtpDate.Value:dd.MM.yyyy}\n" +
                                 $"Количество позиций: {_shipmentItems.Count}\n" +
                                 $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                                 $"Стек: {ex.StackTrace}", ex);
                    MessageBox.Show("Ошибка сохранения отгрузки", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show(AppResources.MsgShipSuccess);
            _shipmentItems.Clear();
            this.Close();
        }

        private List<(StockBatch batch, int take)> GetBatchesForShipment(Guid productId, int quantity)
        {
            using (var db = new SkladContext())
            {
                var batches = db.StockBatches
                    .Where(b => b.ProductId == productId && !b.IsWrittenOff && b.Quantity > 0)
                    .OrderBy(b => b.ExpiryDate)
                    .ToList();

                var result = new List<(StockBatch batch, int take)>();
                int remaining = quantity;

                foreach (var batch in batches)
                {
                    if (remaining <= 0) break;

                    int take = Math.Min(remaining, batch.Quantity);
                    result.Add((batch, take));
                    remaining -= take;
                }

                if (remaining > 0)
                {
                    throw new Exception($"Недостаточно товара. Не хватает {remaining} шт.");
                }

                return result;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _shipmentItems.Clear();
            this.Close();
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
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dgvShipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var idValue = dgvShipment.Rows[e.RowIndex].Cells["colId"].Value?.ToString();
            if (!Guid.TryParse(idValue, out Guid productId)) return;

            //Получаем остаток
            string restStr = dgvShipment.Rows[e.RowIndex].Cells["colRest"].Value?.ToString();
            int rest = int.TryParse(restStr, out int r) ? r : 0;

            string productName = dgvShipment.Rows[e.RowIndex].Cells["colName"].Value?.ToString();
            string article = dgvShipment.Rows[e.RowIndex].Cells["colArticle"].Value?.ToString();

            if (e.ColumnIndex == dgvShipment.Columns["colPlus"].Index)
            {
                //Получаем текущее количество
                int currentQty = _shipmentItems.ContainsKey(productId) ? _shipmentItems[productId].Quantity : 0;
                if (currentQty + 1 <= rest)
                {
                    int newQty = currentQty + 1;

                    try
                    {
                        //Получаем партии по FIFO
                        var batches = GetBatchesForShipment(productId, newQty);
                        decimal totalPrice = batches.Sum(b => b.batch.PurchasePrice * (1 - b.batch.DiscountPercent / 100) * b.take);

                        _shipmentItems[productId] = new ShipmentItemInfo
                        {
                            ProductId = productId,
                            ProductName = productName,
                            Quantity = newQty,
                            TotalPrice = totalPrice,
                            Batches = batches
                        };

                        dgvShipment.Rows[e.RowIndex].Cells["colQty"].Value = newQty.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Logger.Warn($"WARN-03: Попытка отгрузить количество, превышающее остаток.\n" +
                        $"Пользователь: {CurrentUser.User?.Login}\n" +
                        $"ProductId: {productId} | Артикул: {article} | Товар: {productName}\n" +
                        $"Текущее количество: {currentQty} | Запрошено: {currentQty + 1} | Доступно: {rest}\n" +
                        $"Время: {DateTime.Now}");
                    MessageBox.Show(AppResources.MsgNotEnough);
                }
            }
            else if (e.ColumnIndex == dgvShipment.Columns["colMinus"].Index)
            {
                int currentQty = _shipmentItems.ContainsKey(productId) ? _shipmentItems[productId].Quantity : 0;

                if (currentQty > 0)
                {
                    int newQty = currentQty - 1;

                    if (newQty == 0)
                    {
                        _shipmentItems.Remove(productId);
                    }
                    else
                    {
                        try
                        {
                            var batches = GetBatchesForShipment(productId, newQty);
                            decimal totalPrice = batches.Sum(b => b.batch.PurchasePrice * (1 - b.batch.DiscountPercent / 100) * b.take);

                            _shipmentItems[productId] = new ShipmentItemInfo
                            {
                                ProductId = productId,
                                ProductName = productName,
                                Quantity = newQty,
                                TotalPrice = totalPrice,
                                Batches = batches
                            };
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    dgvShipment.Rows[e.RowIndex].Cells["colQty"].Value = newQty.ToString();
                }
            }

            UpdateTotal();
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


        /// <summary>
        /// Загружает список городов из таблицы cities_weather в выпадающий список.
        /// </summary>
        private void LoadCitiesToComboBox()
        {
            try
            {
                using var db = new SkladContext();
                var cities = db.CitiesWeather
                    .OrderBy(c => c.CityName)
                    .ToList();

                cmbCity.Items.Clear();
                cmbCity.Items.Add("-- Выберите город --");

                foreach (var city in cities)
                {
                    cmbCity.Items.Add(city.CityName);
                }

                cmbCity.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке списка городов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверяет ИНН клиента по таблице чёрного списка в базе данных.
        /// Если контрагент найден — выводит предупреждение с причиной блокировки.
        /// Если не найден — сообщает что контрагент чист.
        /// </summary>
        private void btnCheckBlacklist_Click(object sender, EventArgs e)
        {
            var inn = txtClientInn.Text.Trim();

            if (string.IsNullOrEmpty(inn))
            {
                MessageBox.Show("Введите ИНН клиента для проверки.",
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
                        "ВНИМАНИЕ! Клиент находится в чёрном списке!\n\n" +
                        "ИНН: " + found.Inn + "\n" +
                        "Наименование: " + (found.Name ?? "не указано") + "\n" +
                        "Причина блокировки: " + found.Reason + "\n" +
                        "Дата добавления: " + found.AddedDate.ToString("dd.MM.yyyy") + "\n\n" +
                        "Отгрузка данному клиенту не рекомендуется.",
                        "Контрагент в чёрном списке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                        "ИНН " + inn + " не найден в чёрном списке.\n" +
                        "Клиент не имеет ограничений по базе данных.",
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
        /// Показывает погодные данные для выбранного города из базы данных.
        /// Предупреждает о погодных рисках для груза (мороз, жара).
        /// </summary>
        private void btnCheckWeather_Click(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex <= 0)
            {
                MessageBox.Show("Выберите город доставки из списка.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCityName = cmbCity.SelectedItem.ToString();

            try
            {
                using var db = new SkladContext();
                var city = db.CitiesWeather.FirstOrDefault(c => c.CityName == selectedCityName);

                if (city == null)
                {
                    MessageBox.Show("Данные о погоде для города " + selectedCityName + " не найдены.",
                        "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var warning = GetWeatherWarning(city.TemperatureMin, city.TemperatureMax);

                var message =
                    "Город: " + city.CityName + "\n" +
                    "Регион: " + (city.Region ?? "не указан") + "\n" +
                    "Температура: от " + city.TemperatureMin + " до " + city.TemperatureMax + " градусов Цельсия\n" +
                    "Описание: " + (city.WeatherDescription ?? "нет данных") + "\n" +
                    "Данные актуальны на: " + city.UpdatedAt.ToString("dd.MM.yyyy") +
                    warning;

                MessageBox.Show(message, "Погода в городе доставки",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных о погоде: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возвращает текстовое предупреждение о погодных рисках для груза.
        /// Анализирует минимальную и максимальную температуру.
        /// </summary>
        private string GetWeatherWarning(decimal tempMin, decimal tempMax)
        {
            if (tempMin < -15)
            {
                return "\n\nВНИМАНИЕ! Аномальный мороз!\n" +
                       "Рекомендуется использовать термоконтейнер и оформить страховку груза.";
            }

            if (tempMax > 35)
            {
                return "\n\nВНИМАНИЕ! Аномальная жара!\n" +
                       "Рекомендуется использовать рефрижератор и оформить страховку груза.";
            }

            if (tempMin < -5)
            {
                return "\n\nМорозная погода.\n" +
                       "Для хрупких и замерзающих товаров рекомендуется утепление.";
            }

            if (tempMax > 25)
            {
                return "\n\nТёплая погода.\n" +
                       "Для скоропортящихся товаров требуется холодильная транспортировка.";
            }

            return "\n\nПогодные условия благоприятны для доставки.";
        }

        private void txtRegion_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}