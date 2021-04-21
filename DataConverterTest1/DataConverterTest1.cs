using System;
using Interfaces;
using Interfaces.Enums;

namespace DataConverterTest1
{
    /// <summary>
    /// Тестовый класс конвертации
    /// </summary>
    public class DataConverterTest1 : IDataConverter
    {
        /// <summary>
        /// Формат приемника
        /// </summary>
        public EDataFormat SourceDataFormat => EDataFormat.Edf1;
        
        /// <summary>
        /// Формат источника
        /// </summary>
        public EDataFormat SinkDataFormat => EDataFormat.Edf4;
        
        /// <summary>
        /// Конвертирует формат
        /// </summary>
        /// <param name="convertibleObject">Конвертируемый объект</param>
        /// <returns>Конвертированный объект</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object convertibleObject)
        {
            throw new NotImplementedException();
        }
    }
}