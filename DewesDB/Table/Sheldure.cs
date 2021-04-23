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
        /// Id источника
        /// </summary>
        public Guid DataSourceId { get; set; }
        /// <summary>
        /// Источник
        /// </summary>
        public DataSource DataSource { get; set; }
        
        /// <summary>
        /// Id приемника
        /// </summary>
        public Guid DataSinkId { get; set; }
        /// <summary>
        /// Приемник
        /// </summary>
        public DataSink DataSink { get; set; }
    }
}