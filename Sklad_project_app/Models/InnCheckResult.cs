namespace Sklad_project_app
{
    /// <summary>
    /// Результат проверки ИНН поставщика по чёрному списку.
    /// </summary>
    public class InnCheckResult
    {
        /// <summary>
        /// Разрешён ли импорт (true — поставщик чист, false — заблокирован)
        /// </summary>
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Сообщение об ошибке, если поставщик заблокирован
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
