namespace Sklad_project_app
{
    public static class Logger
    {
        private static string _logPath = "logs.txt";

        /// <summary>
        /// Уровни логирования
        /// </summary>
        public enum LogLevel
        {
            FATAL,  // Катастрофические ошибки, после которых приложение завершается
            ERROR,  // Ошибки операций, данные не сохранены
            WARN,   // Предупреждения, потенциальные проблемы
            DEBUG   // Детальная информация для отладки
        }

        /// <summary>
        /// Запись FATAL - система не может продолжать работу
        /// </summary>
        public static void Fatal(string message, Exception ex = null)
        {
            string errorMsg = message;
            if (ex != null)
            {
                errorMsg += $"\nИсключение: {ex.GetType()} --- {ex.Message}\n{ex.StackTrace}";
            }
            WriteLog("FATAL", errorMsg);
        }

        /// <summary>
        /// Запись ERROR - операция завершилась неудачей
        /// </summary>
        public static void Error(string message, Exception ex = null)
        {
            string errorMsg = message;
            if (ex != null)
            {
                errorMsg += $"\nИсключение: {ex.GetType()} --- {ex.Message}";
            }
            WriteLog("ERROR", errorMsg);
        }

        /// <summary>
        /// Запись WARN - операция выполнена, но что-то пошло не так
        /// </summary>
        public static void Warn(string message)
        {
            WriteLog("WARN", message);
        }

        /// <summary>
        /// Запись DEBUG - детальная информация для разработчика
        /// </summary>
        public static void Debug(string message)
        {
            WriteLog("DEBUG", message);
        }

        private static void WriteLog(string level, string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                File.AppendAllText(_logPath, logEntry + Environment.NewLine);
            }
            catch { }
        }

        /// <summary>
        /// Показать окно с логами
        /// </summary>
        public static void ShowLogs()
        {
            if (File.Exists(_logPath))
            {
                string logs = File.ReadAllText(_logPath);
                MessageBox.Show(logs.Length > 10000 ? logs.Substring(0, 10000) + "..." : logs,
                    "Лог файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Лог файл не найден", "Логи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
