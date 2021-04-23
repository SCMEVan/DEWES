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
        /// таблица формат конвертации - конвертер
        /// </summary>
        private Dictionary<(EDataFormat, EDataFormat), IDataConverter> _converterByDataFormats;
        
        /// <summary>
        /// Возвращает все пары форматов конвертации
        /// </summary>
        public List<(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat)> AllFormats { get; private set; }

        /// <summary>
        /// Получает конвертер по формату данных источника и приёмника
        /// </summary>
        /// <param name="sourceDataFormat">Формат данных источника</param>
        /// <param name="sinkDataFormat">Формат данных приемника</param>
        /// <returns></returns>
        public IDataConverter GetConverterByDataFormats(EDataFormat sourceDataFormat, EDataFormat sinkDataFormat) => _converterByDataFormats[(sourceDataFormat, sinkDataFormat)];
            

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
            _converterByDataFormats = Instances.ToDictionary(m => (m.SourceDataFormat, m.SinkDataFormat), m => m);
        }

    }
}