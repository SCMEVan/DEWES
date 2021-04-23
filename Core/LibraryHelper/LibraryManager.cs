using Core.Schedule;

namespace Core.LibraryHelper
{
    public class LibraryManager
    {
        
        public readonly DataSourceLibrariesLoader DataSourceLibrariesLoader = new DataSourceLibrariesLoader();
        public readonly DataConverterLibrariesLoader DataConverterLibrariesLoader = new DataConverterLibrariesLoader();
        public readonly DataSinkLibrariesLoader DataSinkLibrariesLoader = new DataSinkLibrariesLoader();

        public LibraryManager(string routFolder = null)
        {
            //Загружаем библиотеки, инициализируем в них локальные переменные
            DataSourceLibrariesLoader.LoadLibraries(routFolder);
            DataConverterLibrariesLoader.LoadLibraries(routFolder);
            
            DataSinkLibrariesLoader.LoadLibraries(DataConverterLibrariesLoader.AllFormats, routFolder);
        }

        


        /*public List<string> DataSourceNames => _dataSourceLibrariesLoader.DataSourceNames;
        public List<string> GetDataTypesByName(string sourceName) => _dataSourceLibrariesLoader.GetDataTypesByName(sourceName);
        public List<string> GetDataFormatByDataType(string sourceName, string dataType) => _dataSourceLibrariesLoader.GetDataFormatByDataType(sourceName, dataType);
        
        
        public List<string> DataSinkNames => _dataSourceLibrariesLoader.DataSourceNames;
        public List<string> GetDataFormatBySink(string sourceName, string dataType) => _dataSourceLibrariesLoader.GetDataFormatByDataType(sourceName, dataType);*/

    }
}