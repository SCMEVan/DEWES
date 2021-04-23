using System;

namespace DEWESDb.Table
{
    /// <summary>
    /// Удаленный приемник
    /// </summary>
    public class DataSink
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid DataSinkId { get; set; }
        
        /// <summary>
        /// Имя библиотеки для работы с удаленным приемником
        /// </summary>
        public string NameLibrary { get; set; }
        
        /// <summary>
        /// Uri удаленного приемника
        /// </summary>
        public string Uri { get; set; }
    }
}