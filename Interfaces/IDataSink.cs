using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Enums;

namespace Interfaces
{
    public interface IDataSink
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
        EDataFormat DataFormat { get; }

        /// <summary>
        /// Передаёт данные
        /// </summary>
        /// <param name="data">данные в определенном формате </param>
        /// <returns>Возвращает задачу результат которой данные</returns>
        Task SetData(object data);
    }
}