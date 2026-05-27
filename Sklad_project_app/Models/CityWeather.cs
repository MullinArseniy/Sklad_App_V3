namespace Sklad_project_app.Models
{
    /// <summary>
    /// Город с данными о погоде для логистических расчётов.
    /// Используется при отгрузке для предупреждения о погодных рисках.
    /// </summary>
    public class CityWeather
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Регион или область
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Минимальная температура по прогнозу (в градусах Цельсия)
        /// </summary>
        public decimal TemperatureMin { get; set; }

        /// <summary>
        /// Максимальная температура по прогнозу (в градусах Цельсия)
        /// </summary>
        public decimal TemperatureMax { get; set; }

        /// <summary>
        /// Текстовое описание погодных условий
        /// </summary>
        public string WeatherDescription { get; set; }

        /// <summary>
        /// Дата обновления данных о погоде
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}