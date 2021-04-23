using System;

namespace DEWESDb.Table
{
    /// <summary>
    /// Сущность удаленный источник
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid DataSourceId { get; set; }
        
        /// <summary>
        /// Имя библиотеки для работы с удаленным источником
        /// </summary>
        public string NameLibrary { get; set; }
        
        /// <summary>
        /// Uri удаленного источнкиа
        /// </summary>
        public string Uri { get; set; }
        
    }
}