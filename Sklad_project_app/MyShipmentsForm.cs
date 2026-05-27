namespace Sklad_project_app
{
    public partial class MyShipmentsForm : Form
    {
        public MyShipmentsForm()
        {
            InitializeComponent();
        }

        private void MyShipmentsForm_Load(object sender, EventArgs e)
        {
            LoadMyShipments();
        }

        public void LoadMyShipments()
        {
            using (var db = new SkladContext())
            {
                var currentUserId = CurrentUser.User.Id;

                var allShipments = db.Shipments
                    .Include(s => s.Client)
                    .Include(s => s.ShipmentItems)
                    .ThenInclude(i => i.Product)
                    .ThenInclude(p => p.Stock)
                    .OrderBy(s => s.ShipmentDate)
                    .ToList();

                dgvMyShipments.Rows.Clear();
                dgvMyShipments.Columns.Clear();
                dgvMyShipments.Columns.Add("colId", "№");
                dgvMyShipments.Columns.Add("colClient", "Клиент");
                dgvMyShipments.Columns.Add("colDate", "Дата");
                dgvMyShipments.Columns.Add("colItems", "Товаров");
                dgvMyShipments.Columns.Add("colTotal", "Сумма");

                var number = 1;
                foreach (var shipment in allShipments)
                {
                    if (shipment.UserId != currentUserId)
                    {
                        continue;
                    }

                    var clientName = "—";
                    var date = "—";
                    var itemCount = 0;
                    decimal totalAmount = 0;

                    if (shipment.Client != null)
                    {
                        clientName = shipment.Client.Name;
                    }
                    if (shipment.ShipmentDate != null)
                    {
                        date = shipment.ShipmentDate.Value.ToString("dd.MM.yyyy");
                    }
                    if (shipment.ShipmentItems != null)
                    {
                        itemCount = shipment.ShipmentItems.Count;
                    }
                    var totalQuantity = shipment.ShipmentItems?.Sum(i => i.Quantity) ?? 0;
                    totalAmount = shipment.ShipmentItems?.Sum(i => i.Amount) ?? 0;

                    dgvMyShipments.Rows.Add(number, clientName, date, totalQuantity, CurrencyHelp.Format(totalAmount), shipment.Id);
                    number++;
                }
            }
        }
    }
}