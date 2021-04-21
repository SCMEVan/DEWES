using System.Collections.Generic;
using System.Linq;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataSourceController : Controller
    {
        private readonly LibraryManager _libraryManager;
        private DataSourceLibrariesLoader DataSourceLibrariesLoader => _libraryManager.DataSourceLibrariesLoader;
        public DataSourceController(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        
        /// <summary>
        /// Получает все источники данных
        /// </summary>
        /// <returns>Имена источников данных</returns>
        [HttpGet]
        public List<string> DataSourceNames()
        {
            return DataSourceLibrariesLoader.DataSourceNames;
        }
        
        /// <summary>
        /// Получает все типы данных 
        /// </summary>
        /// <param name="sourceName">Имя источника данных</param>
        /// <returns></returns>
        [HttpGet]
        public List<EDataType> GetDataTypesByName(string sourceName)
        {
            return DataSourceLibrariesLoader.GetDataTypesByName(sourceName == null ? DataSourceLibrariesLoader.DataSourceNames.First() 
                : DataSourceLibrariesLoader.DataSourceNames.Single(m=> m == sourceName));
        }
        
        /// <summary>
        /// Получает все форматы данных
        /// </summary>
        /// <param name="sourceName">Имя источника данных</param>
        /// <param name="dataType">Имя приемника данных</param>
        /// <returns></returns>
        [HttpGet]
        public List<EDataFormat> GetDataFormatByDataType(string sourceName, EDataType? dataType)
        {
            return sourceName == null || dataType == null ? 
                DataSourceLibrariesLoader.GetDataFormatByDataType(DataSourceLibrariesLoader.DataSourceNames.First(), DataSourceLibrariesLoader.GetDataTypesByName(DataSourceLibrariesLoader.DataSourceNames.First()).First()) 
                : DataSourceLibrariesLoader.GetDataFormatByDataType(sourceName, dataType.Value);
        }
        
        
    }
}