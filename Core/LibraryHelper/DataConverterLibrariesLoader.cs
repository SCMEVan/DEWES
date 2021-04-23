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
        public List<(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat)> AllFormats { get; private set; } 
            

        /// <summary>
        /// Возвращает есть ли конвертеры с одинаковыми форматами   
        /// </summary>
        public bool CheckDuplicates => AllFormats.Count == AllFormats.Distinct().Count();

        /// <summary>
        /// Загружает библиотеки, инициализирует AllFormats
        /// </summary>
        /// <param name="routFolder">Корневой каталог</param>
        public new void LoadLibraries(string routFolder = null)
        {
            base.LoadLibraries(routFolder);
            AllFormats = Instances.Select(m => (m.SourceDataFormat, m.SinkDataFormat)).ToList();
        }

    }
}