using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Enums;

namespace Interfaces
{
    /// <summary>
    /// Абстрактный класс реализации источника данных, нужен чтобы компилятор не ругался на не полностью реализованные тестовые классы 
    /// </summary>
    public abstract class DataSource : IDataSource
    {
        /// <summary>
        /// Имя источника
        /// </summary>
        public virtual string Name => throw new NotImplementedException($"{nameof(Name)}");
        
        /// <summary>
        /// Тип источника - библиотека или rest api
        /// </summary>
        public virtual ETypeDataSource TypeDataSource => throw new NotImplementedException($"{nameof(TypeDataSource)}");
        
        /// <summary>
        /// Типы данных с возможными форматами 
        /// </summary>
        public virtual Dictionary<EDataType, List<EDataFormat>> DataTypesFormats => throw new NotImplementedException($"{nameof(DataTypesFormats)}");
        
        /// <summary>
        /// Получает данные
        /// </summary>
        /// <param name="dataType">Тип данных</param>
        /// <param name="dataFormat">Формат данных</param>
        /// <returns>Возвращает задачу результат которой данные</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<object> GetData(EDataType dataType, EDataFormat dataFormat)
        {
            throw new NotImplementedException();
        }
    }
}