namespace Sklad_project_app.Models
{
    /// <summary>
    /// Чёрный список контрагентов (клиентов и поставщиков).
    /// Используется для проверки ИНН перед отгрузкой или приёмом поставки.
    /// </summary>
    public class Blacklist
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ИНН контрагента (10 цифр для юрлица, 12 — для ИП)
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Наименование компании или ФИО предпринимателя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Причина включения в чёрный список.
        /// Например: налоговый должник, банкрот, дисквалифицированный директор.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Дата добавления в чёрный список
        /// </summary>
        public DateTime AddedDate { get; set; }
    }
}