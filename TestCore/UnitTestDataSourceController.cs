using System;
using System.Collections.Generic;
using System.IO;
using Core.Controllers;
using Core.LibraryHelper;
using Interfaces.Enums;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    [TestClass]
    public class UnitTestDataSourceController
    {
        private readonly DataSourceController _dataSourceController;
        
        public UnitTestDataSourceController()
        {
            _dataSourceController = new DataSourceController(new LibraryManager("..\\bin"));
        }
            
        /// <summary>
        /// Проверяет наличие тестовых библиотек
        /// </summary>
        [TestMethod]
        public void HaveDataSourceTest1Library()
        {
            var names = _dataSourceController.DataSourceNames();
            CollectionAssert.Contains(names, DataSourceTest1.DataSourceTest1.CName);
        }
        
        /// <summary>
        /// Проверяет наличие типа данных у тестовой библиотеки
        /// </summary>
        [TestMethod]
        public void HaveDataSourceTest1DataTypeLibrary()
        {
            var dataType = _dataSourceController.GetDataTypesByName(DataSourceTest1.DataSourceTest1.CName);
            CollectionAssert.Contains(dataType, EDataType.Edt1);
        }

        /// <summary>
        /// Проверяет наличие формата данных у тестовой библиотеки
        /// </summary>
        [TestMethod]
        public void HaveDataSourceTest1DataFormatLibrary()
        {
            var dataFormats = _dataSourceController.GetDataFormatByDataType(DataSourceTest1.DataSourceTest1.CName, EDataType.Edt1);
            CollectionAssert.AreEqual(new List<EDataFormat>() {EDataFormat.Edf1, EDataFormat.Edf2}, dataFormats);
        }

    }
}