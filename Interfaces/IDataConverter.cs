using Interfaces.Enums;

namespace Interfaces
{
    /// <summary>
    /// Интерфейс конвертера данных
    /// </summary>
    public interface IDataConverter
    {
        /// <summary>
        /// Формат источника данных
        /// </summary>
        EDataFormat SourceDataFormat { get; }
        /// <summary>
        /// Формат приемника данных
        /// </summary>
        EDataFormat SinkDataFormat { get; }
        /// <summary>
        /// Конвертирует данные из формата источника в формат приемника
        /// </summary>
        /// <param name="convertibleObject">Конвертируемые данные</param>
        /// <returns>Конвертированные данные</returns>
        object Convert(object convertibleObject);
    }
}