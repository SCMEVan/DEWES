using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Core.LibraryHelper
{
    /// <summary>
    /// Загрузчик библиотек
    /// </summary>
    /// <typeparam name="T">Искомый интерфейс в библиотеках</typeparam>
    public class LibraryLoader<T> 
    {
        /// <summary>
        /// Расширение библиотек которые загружаем
        /// </summary>
        private const string DllFileNameExtension = ".dll";
        
        /// <summary>
        /// Папка с библиотеками с одинаковыми интерфейсами
        /// </summary>
        protected virtual string  LibrariesFolder => throw new NotImplementedException();
        
        /// <summary>
        /// Библиотеки
        /// </summary>
        private List<Assembly> _assemblies;
        
        /// <summary>
        /// Типы классов реализующие нужный интерфейс
        /// </summary>
        private List<Type> _exportedTypes;

        /// <summary>
        /// Экземпляры классов реализующие нужный интерфейс
        /// </summary>
        public List<T> Instances { get; private set; }
        
        /// <summary>
        /// Загружает библиотеки с нужным интерфейсом, создаёт экземпляры классов реализующие его
        /// </summary>
        public void LoadDataSourceLibraries()
        {
            _assemblies = Directory.GetFiles(LibrariesFolder).Where(m=> Path.GetExtension(m) == DllFileNameExtension).Select(m=> Assembly.LoadFile(Path.GetFullPath(m))).ToList();
            _exportedTypes = _assemblies.SelectMany(m=> m.GetExportedTypes().Where(n=> n.GetInterfaces().Contains(typeof(T)))).ToList();
            Instances = _exportedTypes.Select(Activator.CreateInstance).Cast<T>().ToList();
        }
    }

   
}