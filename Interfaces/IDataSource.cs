using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Enums;

namespace Interfaces
{
    /// <summary>
    /// Интерфейс источника данных
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Тип данных
        /// </summary>
        ETypeDataSource TypeDataSource { get; }
        
        /// <summary>
        /// Типы данных с возможными форматами 
        /// </summary>
        Dictionary<EDataType, List<EDataFormat>> DataTypesFormats { get; }
        
        /// <summary>
        /// Получает данные
        /// </summary>
        /// <param name="dataType">Тип данных</param>
        /// <param name="dataFormat">Формат данных</param>
        /// <returns>Возвращает задачу результат которой данные</returns>
        Task<object> GetData(EDataType dataType, EDataFormat dataFormat);


    }
}