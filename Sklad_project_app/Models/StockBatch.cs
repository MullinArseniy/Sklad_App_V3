namespace Sklad_project_app.Models
{
    /// <summary>
    /// Партия товара. Хранит информацию о каждой поставке
    /// </summary>
    public class StockBatch
    {
        /// <summary>
        /// Уникальный идентификатор партии
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ID товара (внешний ключ)
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// ID поставки (внешний ключ)
        /// </summary>
        public Guid SuppliesId { get; set; }
        /// <summary>
        /// Количество товара в партии
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена закупки
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// Дата истечения срока годности
        /// </summary>
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Процент скидки
        /// </summary>
        public decimal DiscountPercent { get; set; }
        /// <summary>
        /// Флаг: списана ли партия
        /// </summary>
        public bool IsWrittenOff { get; set; }
        /// <summary>
        /// Общий срок годности в днях
        /// </summary>
        public int TotalDays { get; set; }
        /// <summary>
        /// Товар (навигационное свойство)
        /// </summary>
        public virtual Product Product { get; set; }
        /// <summary>
        /// >Поставка (навигационное свойство)
        /// </summary>
        public virtual Supplies Supply { get; set; }
    }
}
