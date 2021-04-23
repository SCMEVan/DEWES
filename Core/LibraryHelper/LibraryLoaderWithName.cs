using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Core.LibraryHelper
{
    public class LibraryLoaderWithName<T> : LibraryLoader<T>
    {
        private Dictionary<string, T> _classByName;
        
        public T GetClassByName(string name) => _classByName[name];

        
        /// <summary>
        /// Загружает классы из библиотек
        /// </summary>
        /// <param name="routFolder">Корневая директория</param>
        public new void LoadLibraries(string routFolder = null)
        {
            base.LoadLibraries(routFolder);
            _classByName = Instances.Where(m => m is IHasName).ToDictionary(m => ((IHasName)m).Name, m=> m);
        }
    }
}