using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Enums;

namespace Core.LibraryHelper
{
    /// <summary>
    /// Загрузчик библиотек для интерфейса источник данных
    /// </summary>
    public class DataSourceLibrariesLoader : LibraryLoaderWithName<IDataSource>
    {
        /// <summary>
        /// Папка с библиотеками 
        /// </summary>
        protected override string LibrariesFolder => "DataSourceLibraries";
        
        /// <summary>
        /// Имена источников
        /// </summary>
        public List<string> DataSourceNames => Instances.Select(m => m.ClassName).ToList();
        
        /// <summary>
        /// Возвращает типы данных источника по его имени
        /// </summary>
        /// <param name="sourceName">Имя источника</param>
        /// <returns>Типы источника</returns>
        public List<EDataType> GetDataTypesByName(string sourceName) => 
            Instances.Single(m => m.ClassName == sourceName).DataTypesFormats.Keys.ToList();
        
        /// <summary>
        /// Возвращает форматы данных источника по его имени и типу данных
        /// </summary>
        /// <param name="sourceName">Имя источника</param>
        /// <param name="dataType">Тип данных</param>
        /// <returns>форматы данных источника</returns>
        public List<EDataFormat> GetDataFormatByDataType(string sourceName, EDataType dataType) =>
            Instances.Single(m => m.ClassName == sourceName).DataTypesFormats[dataType].Select(m=> m).ToList();
    }
}