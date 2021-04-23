using System.Threading.Tasks;
using Core.LibraryHelper;
using Quartz;

namespace Core.Schedule
{
    /// <summary>
    /// Класс для планировщика, запускает передачу данных
    /// </summary>
    public class DataTransferJob : IJob
    {
        /// <summary>
        ///  Осуществляет передачу данных от источника к приемнику с использованием конвертера по требованию
        /// </summary>
        /// <param name="context">Контекст задачи</param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            var dataTransferJobParameter = (DataTransferJobParameter)dataMap.Get(nameof(DataTransferJobParameter));
            var libraryManager = (LibraryManager)dataMap.Get(nameof(LibraryManager));

            return Task.Factory.StartNew(() =>
            {
                var dataSourceLibrariesLoader = libraryManager.DataSourceLibrariesLoader;
                var dataConverterLibrariesLoader = libraryManager.DataConverterLibrariesLoader;
                var dataSinkLibrariesLoader = libraryManager.DataSinkLibrariesLoader;
        
                var classSource = dataSourceLibrariesLoader.GetClassByName(dataTransferJobParameter.DataSourceName);
                var classSink = dataSinkLibrariesLoader.GetClassByName(dataTransferJobParameter.DataSinkName);
            
                if (dataTransferJobParameter.DataSourceFormat == classSink.DataFormat)
                    classSink.SetData(classSource.GetData(dataTransferJobParameter.DataSourceType, dataTransferJobParameter.DataSourceFormat));
                else
                {
                    classSink.SetData(dataConverterLibrariesLoader.GetConverterByDataFormats(dataTransferJobParameter.DataSourceFormat, classSink.DataFormat).Convert(
                        classSource.GetData(dataTransferJobParameter.DataSourceType, dataTransferJobParameter.DataSourceFormat)));
                }
            });
        }
    }
}