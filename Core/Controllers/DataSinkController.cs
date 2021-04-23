using System.Collections.Generic;
using System.Linq;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataSinkController: Controller
    {
        private readonly LibraryManager _libraryManager;
        private DataSinkLibrariesLoader DataSinkLibrariesLoader => _libraryManager.DataSinkLibrariesLoader;
        private DataConverterLibrariesLoader DataConverterLibrariesLoader => _libraryManager.DataConverterLibrariesLoader;
        public DataSinkController(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        /// <summary>
        /// Возвращает все возможные приемники с учетом конвертеров
        /// </summary>
        /// <param name="dataFormat">Формат источника</param>
        /// <returns>Имена всех возможных приемников с учетом конвертеров</returns>
        [HttpGet]
        public List<string> GetValidSinkNames(EDataFormat dataFormat) =>
            DataSinkLibrariesLoader.GetValidSink(dataFormat).Select(m=> m.Name).ToList();
        
        /// <summary>
        /// Возвращает имена приемников
        /// </summary>
        /// <returns>Имена возвращаемых приемников</returns>
        [HttpGet]
        public List<string> DataSinkNames() =>
            DataSinkLibrariesLoader.DataSinkNames;


    }
}