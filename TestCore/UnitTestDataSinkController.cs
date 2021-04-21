using System.Collections.Generic;
using Core.Controllers;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    [TestClass]
    public class UnitTestDataSinkController
    {
        private readonly DataSinkController _dataSinkController;
        
        public UnitTestDataSinkController()
        {
            _dataSinkController = new DataSinkController(new LibraryManager("..\\bin"));
        }
        
        /// <summary>
        /// Проверяет наличие тестовых библиотек
        /// </summary>
        [TestMethod]
        public void HaveDataSinkTest1Test2()
        {
            var dataSinkNames = _dataSinkController.DataSinkNames();
            CollectionAssert.IsSubsetOf(new List<string>(){DataSinkTest1.DataSinkTest1.CName, DataSinkTest2.DataSinkTest2.CName}, dataSinkNames);
        }
        
        /// <summary>
        /// Проверка возможности выбора тестовых приемников для тестовых форматов с учетом конвертеров 
        /// </summary>
        [TestMethod]
        public void HaveValidSinkNames()
        {
            //Должен подходить приемник Test1 без конвертации
            var validSinkNames = _dataSinkController.GetValidSinkNames(EDataFormat.Edf3);
            CollectionAssert.IsSubsetOf(new List<string>(){DataSinkTest1.DataSinkTest1.CName}, validSinkNames);
            
            //Должен подходить приемник Test2 через конвертер Test1
            validSinkNames = _dataSinkController.GetValidSinkNames(EDataFormat.Edf1);
            CollectionAssert.IsSubsetOf(new List<string>(){DataSinkTest2.DataSinkTest2.CName}, validSinkNames);
        }
    }
}