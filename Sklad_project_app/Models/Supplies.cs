namespace Sklad_project_app.Models
{
    /// <summary>
    ///  Шапка поставки
    /// </summary>
    public class Supplies
    {
        /// <summary>
        /// Уникальный идентификатор поставки
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTime SuppliesDate { get; set; }
        /// <summary>
        /// ID пользователя, принявшего поставку
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Пользователь (навигационное свойство)
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Список товаров в поставке
        /// </summary>
        public virtual ICollection<SuppliesItem> SuppliesItems { get; set; }
    }
}
