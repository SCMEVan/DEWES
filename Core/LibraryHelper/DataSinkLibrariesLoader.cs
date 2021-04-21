using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Enums;

namespace Core.LibraryHelper
{
    /// <summary>
    /// Загрузчик библиотеки приемников
    /// </summary>
    public class DataSinkLibrariesLoader : LibraryLoader<IDataSink>
    {
        /// <summary>
        /// Папка библиотек приемников
        /// </summary>
        protected override string LibrariesFolder => "DataSinkLibraries";
        
        /// <summary>
        /// Имена приемников
        /// </summary>
        public List<string> DataSinkNames => Instances.Select(m => m.Name).ToList();

        /// <summary>
        /// Возвращает формат приемника по имени
        /// </summary>
        /// <param name="sourceName">Имя приемника</param>
        /// <returns>Формат приемника</returns>
        public EDataFormat GetDataFormatByName(string sourceName) => Instances.Single(m => m.Name == sourceName).DataFormat;

        /// <summary>
        /// Возвращает все приемники с учетом конвертеров
        /// </summary>
        /// <param name="sourceDataFormat">Формат источника</param>
        /// <param name="converterFormats">Формат приемника</param>
        /// <returns>Приемники с учетом конвертеров</returns>
        public List<IDataSink> GetValidSink(EDataFormat sourceDataFormat, List<(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat)> converterFormats)
        {
            return Instances.Where(m => m.DataFormat == sourceDataFormat ||
                                        converterFormats.Contains((sourceDataFormat, m.DataFormat)))
                .ToList();
        }
    }
}