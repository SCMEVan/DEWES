/*using System.Collections.Generic;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataConverterController : Controller
    {
        private readonly LibraryManager _libraryManager;
        private DataConverterLibrariesLoader DataConverterLibrariesLoader => _libraryManager.DataConverterLibrariesLoader;
        public DataConverterController(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        public List<(EDataFormat sourceFormat, EDataFormat sinkFormat)> GetFormats() => DataConverterLibrariesLoader.AllFormats;
        
    }
}*/