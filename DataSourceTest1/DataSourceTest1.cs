using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.DataTypes;
using Interfaces.Enums;

namespace DataSourceTest1
{
    /// <summary>
    /// Тестовый источник данных
    /// </summary>
    public class DataSourceTest1 : DataSource
    {
        public override string Name => CName;
        public const string CName = "I_Test1";
        
        /// <summary>
        /// Тестовый набор данных и их форматов
        /// </summary>
        public override Dictionary<EDataType, List<EDataFormat>> DataTypesFormats =>
        new Dictionary<EDataType, List<EDataFormat>>()
            {
                {EDataType.Edt1, new List<EDataFormat>() {EDataFormat.Edf1, EDataFormat.Edf2}},
                {EDataType.Edt2, new List<EDataFormat>() {EDataFormat.Edf3}},
            };

        
        public override Task<object> GetData(EDataType dataType, EDataFormat dataFormat)
        {
            return Task.FromResult<object>(Task.Factory.StartNew(()=> new Dt1DateTimeString(DateTime.Now, $"Test1 Data, type: {dataType}, format: {dataFormat}")));
        }
    }
}