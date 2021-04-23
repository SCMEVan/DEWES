using Interfaces.Enums;

namespace Core.Schedule
{
    /// <summary>
    /// Параметр для класса <class name="DataTransferJob" />
    /// </summary>
    public class DataTransferJobParameter
    {
        public DataTransferJobParameter(string dataSourceName, string dataSinkName, EDataType dataSourceType, EDataFormat dataSourceFormat)
        {
            DataSourceName = dataSourceName;
            DataSinkName = dataSinkName;
            DataSourceFormat = dataSourceFormat;
            DataSourceType = dataSourceType;
        }

        /// <summary>
        /// Имя класса источника
        /// </summary>
        public string DataSourceName { get; set; }
        
        /// <summary>
        /// Имя класса приемника
        /// </summary>
        public string DataSinkName { get; set; }
        
        /// <summary>
        /// Тип данных источника
        /// </summary>
        public EDataType DataSourceType { get; set; }
        
        /// <summary>
        /// Тип данных приемника
        /// </summary>
        public EDataFormat DataSourceFormat { get; set; }
    }
}