using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Enums;

namespace Core.LibraryHelper
{
    /// <summary>
    /// Загрузчик библиотек конвертеров
    /// </summary>
    public class DataConverterLibrariesLoader : LibraryLoader<IDataConverter>
    {
        protected override string LibrariesFolder => "DataConverterLibraries";

        /// <summary>
        /// Возвращает все пары форматов конвертации
        /// </summary>
        public List<(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat)> AllFormats =>
            Instances.Select(m => (m.SourceDataFormat, m.SinkDataFormat)).ToList();

        /// <summary>
        /// Возвращает есть ли конвертеры с одинаковыми форматами   
        /// </summary>
        public bool CheckDuplicates => AllFormats.Count == AllFormats.Distinct().Count();

    }
}