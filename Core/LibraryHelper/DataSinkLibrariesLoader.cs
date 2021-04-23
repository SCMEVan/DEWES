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
    public class DataSinkLibrariesLoader : LibraryLoaderWithName<IDataSink>
    {
        private readonly Dictionary<EDataFormat, List<IDataSink>> _dataSinksByFormat = new Dictionary<EDataFormat, List<IDataSink>>();
        
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
        /// Получает все доступные приемника по формату источника
        /// </summary>
        /// <param name="sourceDataFormat">Формат источника</param>
        /// <returns>Приемники способные принять данные в заданном формате</returns>
        public List<IDataSink> GetValidSink(EDataFormat sourceDataFormat) => _dataSinksByFormat[sourceDataFormat];

        /// <summary>
        /// Загружает библиотеку, подготавливает функцию GetValidSink
        /// </summary>
        /// <param name="converterFormats">Пары форматов конвертера</param>
        /// <param name="routFolder">Корневая папка библиотек</param>
        public void LoadLibraries(List<(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat)> converterFormats, string routFolder = null)
        {
            base.LoadLibraries(routFolder);
            foreach (EDataFormat eDataFormat in Enum.GetValues(typeof(EDataFormat)))
            {
                _dataSinksByFormat[eDataFormat] = Instances.Where(m => m.DataFormat == eDataFormat ||
                                                                      converterFormats.Contains((eDataFormat, m.DataFormat))).ToList();
            }
        }


        /*/// <summary>
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
        }*/
    }
}