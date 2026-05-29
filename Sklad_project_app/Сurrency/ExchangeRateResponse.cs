namespace Sklad_project_app.Сurrency
{
    /// <summary>
    ///  Класс для десериализации JSON-ответа от API курсов валют
    /// </summary>
    public class ExchangeRateResponse
    {
        /// <summary>
        /// Словарь курсов валют
        /// </summary>
        public Dictionary<string, double> rates { get; set; }
    }
}
