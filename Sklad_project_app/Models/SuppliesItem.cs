namespace Sklad_project_app.Models
{
    /// <summary>
    /// Детали поставки
    /// </summary>
    public class SuppliesItem
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// >ID поставки (внешний ключ)
        /// </summary>
        public Guid SuppliesId { get; set; }
        /// <summary>
        /// ID товара (внешний ключ)
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Количество товара в поставке
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена закупки (в рублях)
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// Шапка поставки (навигационное свойство)
        /// </summary>
        public virtual Supplies Supplies { get; set; }
        /// <summary>
        /// Товар (навигационное свойство)
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
