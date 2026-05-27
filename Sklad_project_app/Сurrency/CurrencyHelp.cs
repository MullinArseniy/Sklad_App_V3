namespace Sklad_project_app.Сurrency
{
    /// <summary>
    /// Загружает курсы валют из API
    /// </summary>
    public static class CurrencyHelp
    {
        private static string _currentCurrency = "RUB";
        private static Dictionary<string, decimal> _allRates = new Dictionary<string, decimal>();
        /// <summary>
        /// Установить текущую валюту
        /// </summary>
        /// <param name="currency"></param>
        public static void SetCurrency(string currency)
        {
            _currentCurrency = currency;
        }
        /// <summary>
        /// Получить текущую валюту
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCurrency()
        {
            return _currentCurrency;
        }
        /// <summary>
        /// Загружает курсы валют из API
        /// </summary>
        /// <param name="rates"></param>
        public static void SetRates(Dictionary<string, decimal> rates)
        {
            _allRates = rates;
        }
        /// <summary>
        /// >Конвертировать сумму из рублей в текущую валюту
        /// </summary>
        /// <param name="amountInRub"></param>
        /// <returns></returns>
        public static decimal Convert(decimal amountInRub)
        {
            if (_currentCurrency == "RUB") return amountInRub;

            decimal rate = _allRates.GetValueOrDefault(_currentCurrency, 1);
            return rate > 0 ? amountInRub / rate : amountInRub;
        }
        /// <summary>
        /// >Получить текущий курс выбранной валюты
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentRate()
        {
            if (_currentCurrency == "RUB") return 1;
            return _allRates.GetValueOrDefault(_currentCurrency, 1);
        }
        /// <summary>
        /// >Отформатировать цену с символом валюты
        /// </summary>
        /// <param name="amountInRub"></param>
        /// <returns></returns>
        public static string Format(decimal amountInRub)
        {
            decimal converted = Convert(amountInRub);
            return $"{converted:F2} {_currentCurrency}";
        }
    }
}
