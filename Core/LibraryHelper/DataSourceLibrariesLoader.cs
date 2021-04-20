using System;
using Interfaces;

namespace Core.LibraryHelper
{
    /// <summary>
    /// Загрузчик библиотек для интерфейса источник данных
    /// </summary>
    public class DataSourceLibrariesLoader : LibraryLoader<IDataSource>
    {
        /// <summary>
        /// Папка с библиотеками 
        /// </summary>
        protected override string LibrariesFolder => "DataSourceLibraries";
    }
}