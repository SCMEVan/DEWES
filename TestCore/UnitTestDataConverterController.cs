/*using Core.Controllers;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    [TestClass]
    public class UnitTestDataConverterController
    {
        private readonly DataConverterController _dataConverterController;
        
        public UnitTestDataConverterController()
        {
            _dataConverterController = new DataConverterController(new LibraryManager("..\\bin"));
        }
        
        [TestMethod]
        public void HaveDataConverterTest1()
        {
            var formats = _dataConverterController.GetFormats();
            CollectionAssert.Contains(formats, (EDataFormat.Edf1, EDataFormat.Edf4));
        }
    }
}*/