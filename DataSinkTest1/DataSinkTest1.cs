using System;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Enums;

namespace DataSinkTest1
{
    /// <summary>
    /// Тестовый класс приемник
    /// </summary>
    public class DataSinkTest1 : IDataSink
    {
        public string Name => CName;
        public const string CName = "DataSinkTest1";
        public ETypeDataSource TypeDataSource => ETypeDataSource.Dll;
        public EDataFormat DataFormat => EDataFormat.Edf3;
        
        public Task SetData(object data)
        {
            throw new NotImplementedException();
        }
    }
}