using System.Linq;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    public abstract class UnitTestCrudController<T> where T : class
    {
        private readonly CrudController<T> _crudController;

        protected UnitTestCrudController(CrudController<T> crudController)
        {
            _crudController = crudController;
        }

        protected abstract T CreateObject();

        /// <summary>
        /// Проверка метода удаление всех сущностей
        /// </summary>
        [TestMethod]
        public void RemoveAll()
        {
            var data = _crudController.ReadAll();
            if(data.Count == 0)
                return;
            _crudController.DeleteAll();
            Assert.IsTrue(_crudController.ReadAll().Count == 0);
        }
        
        /// <summary>
        /// Проверка метода добавления сущности
        /// </summary>
        [TestMethod]
        public void Create()
        {
            RemoveAll();
            var createdObject = CreateObject();
            _crudController.Create(createdObject);
            var data = _crudController.ReadAll();
            Assert.IsTrue(_crudController.ReadAll().Count == 1);
            Assert.IsTrue(data.First() == createdObject);
        }

     
    }
}