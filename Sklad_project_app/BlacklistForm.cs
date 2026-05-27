namespace Sklad_project_app
{
    /// <summary>
    /// Форма управления чёрным списком контрагентов.
    /// Доступна только администратору.
    /// </summary>
    public partial class BlacklistForm : Form
    {
        public BlacklistForm()
        {
            InitializeComponent();
        }

        private void BlacklistForm_Load(object sender, EventArgs e)
        {
            LoadBlacklist();
        }

        /// <summary>
        /// Загружает все записи чёрного списка из базы данных в таблицу.
        /// </summary>
        private void LoadBlacklist()
        {
            try
            {
                using var db = new SkladContext();
                var list = db.Blacklist.OrderBy(b => b.AddedDate).ToList();

                dgvBlacklist.Rows.Clear();
                dgvBlacklist.Columns.Clear();
                dgvBlacklist.Columns.Add("colInn", "ИНН");
                dgvBlacklist.Columns.Add("colName", "Наименование");
                dgvBlacklist.Columns.Add("colReason", "Причина блокировки");
                dgvBlacklist.Columns.Add("colDate", "Дата добавления");
                dgvBlacklist.Columns.Add("colId", "ID");
                dgvBlacklist.Columns["colId"].Visible = false;

                foreach (var item in list)
                {
                    dgvBlacklist.Rows.Add(
                        item.Inn,
                        item.Name ?? "не указано",
                        item.Reason,
                        item.AddedDate.ToString("dd.MM.yyyy"),
                        item.Id
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке чёрного списка: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавляет нового контрагента в чёрный список.
        /// Проверяет заполненность полей и уникальность ИНН.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var inn = txtInn.Text.Trim();
            var name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(inn))
            {
                MessageBox.Show("Введите ИНН контрагента.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inn.Length != 10 && inn.Length != 12)
            {
                MessageBox.Show("ИНН должен содержать 10 или 12 цифр.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var ch in inn)
            {
                if (!char.IsDigit(ch))
                {
                    MessageBox.Show("ИНН должен содержать только цифры.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (cmbReason.SelectedItem == null)
            {
                MessageBox.Show("Выберите причину блокировки.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reason = cmbReason.SelectedItem.ToString();

            try
            {
                using var db = new SkladContext();
                var existing = db.Blacklist.FirstOrDefault(b => b.Inn == inn);

                if (existing != null)
                {
                    MessageBox.Show("Контрагент с ИНН " + inn + " уже есть в чёрном списке.",
                        "Уже в списке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newEntry = new Blacklist
                {
                    Id = Guid.NewGuid(),
                    Inn = inn,
                    Name = string.IsNullOrEmpty(name) ? null : name,
                    Reason = reason,
                    AddedDate = DateTime.Now
                };

                db.Blacklist.Add(newEntry);
                db.SaveChanges();

                MessageBox.Show("Контрагент успешно добавлен в чёрный список.",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInn.Text = "";
                txtName.Text = "";
                cmbReason.SelectedIndex = 0;
                LoadBlacklist();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаляет выбранного контрагента из чёрного списка после подтверждения.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBlacklist.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idValue = dgvBlacklist.SelectedRows[0].Cells["colId"].Value?.ToString();

            if (!Guid.TryParse(idValue, out var id))
            {
                MessageBox.Show("Ошибка определения записи.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                "Удалить выбранного контрагента из чёрного списка?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using var db = new SkladContext();
                var entry = db.Blacklist.Find(id);

                if (entry != null)
                {
                    db.Blacklist.Remove(entry);
                    db.SaveChanges();
                    MessageBox.Show("Запись удалена из чёрного списка.",
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBlacklist();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрывает форму управления чёрным списком.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}