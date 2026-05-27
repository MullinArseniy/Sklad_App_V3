namespace Sklad_project_app
{
    public partial class HeatMapForm : Form
    {
        public HeatMapForm()
        {
            InitializeComponent();

            if (CurrentUser.IsAdmin)
            {
                lblUserInfo.Text = AppResources.LblAdmin
                    + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
            }
            else
            {
                lblUserInfo.Text = AppResources.LblStorekeeper
                    + CurrentUser.User.Surname + " " + CurrentUser.User.Name;
            }
        }

        private void HeatMapForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToCombo();
            BuildHeatMap();
        }

        private void LoadCategoriesToCombo()
        {
            using var db = new SkladContext();
            var categories = db.Categories.ToList();

            cmbZone.Items.Clear();
            cmbZone.Items.Add("Все категории");

            foreach (var cat in categories)
            {
                cmbZone.Items.Add(cat.Name);
            }

            cmbZone.SelectedIndex = 0;
        }

        private void BuildHeatMap()
        {
            panelMap.Controls.Clear();

            using var db = new SkladContext();
            var today = DateTime.Now.Date;

            // Загружаем все активные партии
            var query = db.StockBatches
                .Include(b => b.Product)
                .ThenInclude(p => p.Category)
                .Where(b => !b.IsWrittenOff && b.Quantity > 0 && b.ExpiryDate != null);

            // Если выбрана конкретная категория — фильтруем
            if (cmbZone.SelectedIndex > 0)
            {
                var selectedCategory = cmbZone.SelectedItem.ToString();
                query = query.Where(b => b.Product.Category.Name == selectedCategory);
            }

            var batches = query.ToList();

            if (batches.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "Нет данных для отображения.\nДобавьте поставки со сроком годности.",
                    Font = new Font("Arial", 12F),
                    Location = new Point(20, 20),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };
                panelMap.Controls.Add(lblEmpty);
                return;
            }

            // Определяем сколько колонок делаем в таблице
            var cols = 5;
            var cellWidth = 160;
            var cellHeight = 90;
            var paddingX = 10;
            var paddingY = 10;

            for (var i = 0; i < batches.Count; i++)
            {
                var batch = batches[i];

                var row = i / cols;
                var col = i % cols;

                var x = paddingX + col * (cellWidth + paddingX);
                var y = paddingY + row * (cellHeight + paddingY);

                var cell = CreateCell(batch, today, x, y, cellWidth, cellHeight);
                panelMap.Controls.Add(cell);
            }

            // Добавляем легенду
            AddLegend(batches.Count, cols, cellWidth, cellHeight, paddingX, paddingY);
        }

        private Panel CreateCell(StockBatch batch, DateTime today, int x, int y, int w, int h)
        {
            var daysLeft = (batch.ExpiryDate!.Value.Date - today).Days;

            // Определяем цвет ячейки по оставшимся дням
            var cellColor = GetCellColor(daysLeft);

            var cell = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = cellColor,
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            // Название товара
            var lblName = new Label
            {
                Text = batch.Product?.Name ?? "—",
                Font = new Font("Arial", 8F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(4, 4),
                Size = new Size(w - 8, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Срок годности
            var lblExpiry = new Label
            {
                Text = "Годен до: " + batch.ExpiryDate.Value.ToString("dd.MM.yyyy"),
                Font = new Font("Arial", 7F),
                ForeColor = Color.Black,
                Location = new Point(4, 34),
                Size = new Size(w - 8, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Остаток дней
            var daysText = daysLeft <= 0 ? "ПРОСРОЧЕН!" : $"Осталось: {daysLeft} дн.";
            var lblDays = new Label
            {
                Text = daysText,
                Font = new Font("Arial", 7F, FontStyle.Bold),
                ForeColor = daysLeft <= 0 ? Color.DarkRed : Color.Black,
                Location = new Point(4, 52),
                Size = new Size(w - 8, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Количество
            var lblQty = new Label
            {
                Text = $"Кол-во: {batch.Quantity} шт.",
                Font = new Font("Arial", 7F),
                ForeColor = Color.Black,
                Location = new Point(4, 68),
                Size = new Size(w - 8, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            cell.Controls.Add(lblName);
            cell.Controls.Add(lblExpiry);
            cell.Controls.Add(lblDays);
            cell.Controls.Add(lblQty);

            // Подсказка при наведении
            var toolTip = new ToolTip();
            var tipText = $"Товар: {batch.Product?.Name}\n" +
                          $"Категория: {batch.Product?.Category?.Name}\n" +
                          $"Срок годности: {batch.ExpiryDate.Value:dd.MM.yyyy}\n" +
                          $"Осталось дней: {(daysLeft <= 0 ? "ПРОСРОЧЕН" : daysLeft.ToString())}\n" +
                          $"Количество: {batch.Quantity} шт.\n" +
                          $"Скидка: {batch.DiscountPercent}%";

            toolTip.SetToolTip(cell, tipText);
            foreach (Control c in cell.Controls)
            {
                toolTip.SetToolTip(c, tipText);
            }

            return cell;
        }

        private Color GetCellColor(int daysLeft)
        {
            if (daysLeft <= 0)
            {
                // Просрочен — тёмно-красный
                return Color.FromArgb(220, 50, 50);
            }
            else if (daysLeft <= 3)
            {
                // Критически мало — красный
                return Color.FromArgb(255, 80, 80);
            }
            else if (daysLeft <= 7)
            {
                // Мало — оранжевый
                return Color.FromArgb(255, 160, 0);
            }
            else if (daysLeft <= 14)
            {
                // Нормально — жёлтый
                return Color.FromArgb(255, 230, 0);
            }
            else if (daysLeft <= 30)
            {
                // Хорошо — светло-зелёный
                return Color.FromArgb(150, 220, 100);
            }
            else
            {
                // Отлично — зелёный
                return Color.FromArgb(80, 200, 80);
            }
        }

        private void AddLegend(int count, int cols, int cellW, int cellH, int padX, int padY)
        {
            var rows = (count + cols - 1) / cols;
            var legendY = padY + rows * (cellH + padY) + 20;

            var lblLegendTitle = new Label
            {
                Text = "Легенда:",
                Font = new Font("Arial", 9F, FontStyle.Bold),
                Location = new Point(padX, legendY),
                AutoSize = true
            };
            panelMap.Controls.Add(lblLegendTitle);

            // Данные легенды: цвет, описание
            var legendItems = new[]
            {
                (Color.FromArgb(80, 200, 80),     "Более 30 дней — отлично"),
                (Color.FromArgb(150, 220, 100),   "14–30 дней — хорошо"),
                (Color.FromArgb(255, 230, 0),     "7–14 дней — нормально"),
                (Color.FromArgb(255, 160, 0),     "3–7 дней — скоро истекает"),
                (Color.FromArgb(255, 80, 80),     "1–3 дня — критично"),
                (Color.FromArgb(220, 50, 50),     "Просрочен — списать!")
            };

            for (var i = 0; i < legendItems.Length; i++)
            {
                var (color, text) = legendItems[i];
                var lx = padX + i * 200;

                var colorBox = new Panel
                {
                    Location = new Point(lx, legendY + 22),
                    Size = new Size(20, 20),
                    BackColor = color,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var lblText = new Label
                {
                    Text = text,
                    Font = new Font("Arial", 7F),
                    Location = new Point(lx + 24, legendY + 24),
                    AutoSize = true
                };

                panelMap.Controls.Add(colorBox);
                panelMap.Controls.Add(lblText);
            }
        }

        private void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildHeatMap();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildHeatMap();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            CurrentUser.RoleName = null;
            var loginForm = Application.OpenForms.OfType<LoginForm>().FirstOrDefault();
            loginForm?.ClearFields();
            loginForm?.Show();
            loginForm?.BringToFront();
            foreach (var form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != loginForm)
                    form.Close();
            }
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var form = new CategoriesForm();
            form.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var form = new ShipmentHistoryForm();
            form.ShowDialog();
        }

        private void btnSuplies_Click(object sender, EventArgs e)
        {
            var form = new SuppliesForm();
            form.ShowDialog();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm();
            form.ShowDialog();
            this.Close();
        }

        private void btnExpirationDates_Click(object sender, EventArgs e)
        {
            var form = new ExpirationDatesForm();
            form.ShowDialog();
            this.Close();
        }

        private void btnWrittenOff_Click(object sender, EventArgs e)
        {
            var form = new WriteOffHistoryForm();
            form.ShowDialog();
            this.Close();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            var form = new CurrencyForm();
            form.ShowDialog();
            this.Close();
        }
    }
}