using System.Collections.Generic;
using System.Linq;
using Core.LibraryHelper;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataSourceController : Controller
    {
        private readonly LibraryManager _libraryManager;
        public DataSourceController(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        
        /// <summary>
        /// Получает все источники данных
        /// </summary>
        /// <returns>Имена источников данных</returns>
        [HttpGet]
        public List<string> Test1()
        {
            return _libraryManager.DataSourceNames;
        }
        
        /// <summary>
        /// Получает все типы данных 
        /// </summary>
        /// <param name="sourceName">Имя источника данных</param>
        /// <returns></returns>
        [HttpGet]
        public List<string> Test2(string sourceName)
        {
            return _libraryManager.GetDataTypesByName(sourceName == null ? _libraryManager.DataSourceNames.First() 
                : _libraryManager.DataSourceNames.Single(m=> m == sourceName));
        }
        
        /// <summary>
        /// Получает все форматы данных
        /// </summary>
        /// <param name="sourceName">Имя источника данных</param>
        /// <param name="dataType">Имя приемника данных</param>
        /// <returns></returns>
        [HttpGet]
        public List<string> Test3(string sourceName, string dataType)
        {
            return sourceName == null || dataType == null ? 
                _libraryManager.GetDataFormatByDataType(_libraryManager.DataSourceNames.First(), _libraryManager.GetDataTypesByName(_libraryManager.DataSourceNames.First()).First()) 
                : _libraryManager.GetDataFormatByDataType(sourceName, dataType);
        }
        
        
    }
}