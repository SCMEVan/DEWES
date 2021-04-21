using System;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Enums;

namespace DataSinkTest2
{
    public class DataSinkTest2: IDataSink
    {
        public string Name => CName;
        public const string CName = "DataSinkTest2";
        public ETypeDataSource TypeDataSource => ETypeDataSource.RestApi;
        public EDataFormat DataFormat => EDataFormat.Edf4;
        public Task SetData(object data)
        {
            throw new NotImplementedException();
        }
    }
}