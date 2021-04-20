using System;

namespace Interfaces.DataTypes
{
    /// <summary>
    /// Тестовый тип данных
    /// </summary>
    public class Dt1DateTimeString
    {
        public Dt1DateTimeString(DateTime dateTime, string data)
        {
            DateTime = dateTime;
            Data = data;
        }

        public DateTime DateTime { get; set; }
        public string Data { get; set; }
    }
}