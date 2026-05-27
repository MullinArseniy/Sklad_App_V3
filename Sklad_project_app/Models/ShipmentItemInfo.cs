namespace Sklad_project_app.Models
{
    /// <summary>
    /// Вспомогательный класс для временного хранения товаров в корзине отгрузки
    /// </summary>
    public class ShipmentItemInfo
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Общее количество товара в отгрузке
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Общая сумма по товару
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Список партий, из которых берётся товар (FIFO)
        /// </summary>
        public List<(StockBatch batch, int take)> Batches { get; set; }
    }
}
