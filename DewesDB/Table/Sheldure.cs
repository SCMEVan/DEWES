using System;
using Interfaces.Enums;

namespace DEWESDb.Table
{
    public class Schedule
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid ScheduleId  { get; set; }

        /// <summary>
        /// Типа данных
        /// </summary>
        public EDataType EDataSourceType { get; set; }
        /// <summary>
        /// Формат источника и приемника данных
        /// </summary>
        public EDataFormat EDataSourceFormat { get; set; }
        
        /// <summary>
        /// Имя библиотеки источника
        /// </summary>
        public string DataSourceName { get; set; }
        
        /// <summary>
        /// Имя библиотеки приемника
        /// </summary>
        public string DataSinkName { get; set; }

        /// <summary>
        /// Время создания задачи
        /// </summary>
        public DateTime DateTimeCreate { get; set; }

        /// <summary>
        /// Интервал выполнения
        /// </summary>
        public string Interval { get; set; }
    }
}