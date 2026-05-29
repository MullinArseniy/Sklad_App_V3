namespace Sklad_project_app.Models
{
    /// <summary>
    /// Списание товара
    /// </summary>
    public class WriteOff
    {
        /// <summary>
        /// Уникальный идентификатор списания
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ID товара (внешний ключ)
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// ID партии (внешний ключ)
        /// </summary>
        public Guid BatchId { get; set; }
        /// <summary>
        /// Дата списания
        /// </summary>
        public DateTime WriteOffDate { get; set; }
        /// <summary>
        /// Количество списанного товара
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Сумма убытка
        /// </summary>
        public decimal LossAmount { get; set; }
        /// <summary>
        /// Причина списания
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Товар (навигационное свойство)
        /// </summary>
        public virtual Product Product { get; set; }
        /// <summary>
        /// Партия (навигационное свойство)
        /// </summary>
        public virtual StockBatch StockBatch { get; set; }
    }
}
