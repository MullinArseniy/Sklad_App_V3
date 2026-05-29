using System;
using System.Collections.Generic;
using System.Text;

namespace Sklad_project_app
{
    public class ImportResult
    {
        /// <summary>
        /// Количество успешно импортированных позиций
        /// </summary>
        public int ImportedCount { get; set; }

        /// <summary>
        /// Количество пропущенных позиций
        /// </summary>
        public int SkippedCount { get; set; }

        /// <summary>
        /// Список причин пропуска позиций
        /// </summary>
        public List<string> SkippedReasons { get; set; } = new List<string>();
    }
}
