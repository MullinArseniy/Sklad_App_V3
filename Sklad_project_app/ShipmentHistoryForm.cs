namespace Sklad_project_app
{
    public partial class ShipmentHistoryForm : Form
    {
        public ShipmentHistoryForm()
        {
            InitializeComponent();
        }

        private void ShipmentHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            using (var db = new SkladContext())
            {
                var shipments = db.Shipments
                    .Include("Client")
                    .Include("User")
                    .OrderBy(s => s.ShipmentDate)
                    .ToList();

                dgvHistory.Rows.Clear();
                dgvHistory.Columns.Clear();
                dgvHistory.Columns.Add("colShipId", "№");
                dgvHistory.Columns.Add("colShipClient", "Клиент");
                dgvHistory.Columns.Add("colShipUser", "Кладовщик");
                dgvHistory.Columns.Add("colShipDate", "Дата");
                dgvHistory.Columns.Add("colTotalAmount", "Сумма");
                dgvHistory.Columns.Add("colShipIdHidden", "ID");
                dgvHistory.Columns["colShipIdHidden"].Visible = false;

                var number = 1;
                foreach (var shipment in shipments)
                {
                    var clientName = "—";
                    var userName = "—";
                    var date = "—";
                    decimal totalAmount = db.ShipmentItems
                    .Where(i => i.ShipmentId == shipment.Id)
                    .Sum(i => i.Amount);

                    if (shipment.Client != null)
                    {
                        clientName = shipment.Client.Name;
                    }
                    if (shipment.User != null)
                    {
                        userName = shipment.User.Surname + " " + shipment.User.Name;
                    }
                    if (shipment.ShipmentDate != null)
                    {
                        date = shipment.ShipmentDate.Value.ToString("dd.MM.yyyy");
                    }

                    dgvHistory.Rows.Add(number, clientName, userName, date, CurrencyHelp.Format(totalAmount), shipment.Id);
                    number++;
                }
            }
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                return;
            }

            var idValue = dgvHistory.SelectedRows[0].Cells["colShipIdHidden"].Value?.ToString();

            Guid shipmentId;
            if (!Guid.TryParse(idValue, out shipmentId))
            {
                return;
            }

            LoadShipmentItems(shipmentId);
        }

        private void LoadShipmentItems(Guid shipmentId)
        {
            using (var db = new SkladContext())
            {
                var allItems = db.ShipmentItems
                    .Include("Product")
                    .Where(i => i.ShipmentId == shipmentId)
                    .ToList();

                dgvHistoryItems.Rows.Clear();
                dgvHistoryItems.Columns.Clear();
                dgvHistoryItems.Columns.Add("colItemName", "Товар");
                dgvHistoryItems.Columns.Add("colItemQty", "Количество");
                dgvHistoryItems.Columns.Add("colItemAmount", "Сумма");

                foreach (var item in allItems)
                {
                    if (item.ShipmentId == shipmentId)
                    {
                        var productName = "—";
                        if (item.Product != null)
                        {
                            productName = item.Product.Name;
                        }
                        dgvHistoryItems.Rows.Add(productName, item.Quantity, CurrencyHelp.Format(item.Amount));
                    }
                }
            }
        }
    }
}