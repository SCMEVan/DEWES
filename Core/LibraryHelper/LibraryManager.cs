using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Enums;

namespace Core.LibraryHelper
{
    public class LibraryManager
    {
        private readonly DataSourceLibrariesLoader _dataSourceLibrariesLoader = new DataSourceLibrariesLoader();

        public LibraryManager()
        {
            _dataSourceLibrariesLoader.LoadDataSourceLibraries();
        }
        
        
        public List<string> DataSourceNames => _dataSourceLibrariesLoader.Instances.Select(m => m.Name).ToList();
        public List<string> GetDataTypesByName(string sourceName) => 
            _dataSourceLibrariesLoader.Instances.Single(m => m.Name == sourceName).DataTypesFormats.Keys.Select(m=> m.ToString()).ToList();

        public List<string> GetDataFormatByDataType(string sourceName, string dataType) =>
            _dataSourceLibrariesLoader.Instances.Single(m => m.Name == sourceName).DataTypesFormats[(EDataType)Enum.Parse(typeof(EDataType),dataType)].Select(m=> m.ToString()).ToList();

    }
}