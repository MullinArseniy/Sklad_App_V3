namespace Sklad_project_app.Import
{
    /// <summary>
    /// Модель для импорта поставок из JSON-файла.
    /// Каждый объект в массиве описывает одну позицию поставки.
    /// </summary>
    public class ImportSupplies
    {
        /// <summary>
        /// ИНН поставщика. Проверяется по чёрному списку перед импортом.
        /// Одинаковый для всех позиций одного файла.
        /// </summary>
        public string SupplierInn { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена закупки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Срок годности в днях от даты поставки
        /// </summary>
        public int ExpiryDays { get; set; }
    }
}