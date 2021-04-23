using System;
using System.Collections.Generic;
using System.Linq;
using DEWESDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    /// <summary>
    /// Шаблон CRUD контролера
    /// </summary>
    /// <typeparam name="T">Тип таблица - класс</typeparam>
    public class CrudController<T> : Controller where T : class
    {
        /// <summary>
        /// контекст базы данных
        /// </summary>
        private readonly DbScheduleContext _db;

        public CrudController(DbScheduleContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Получает сущность по guid 
        /// </summary>
        /// <param name="id">Guid сущности</param>
        /// <returns>Сущность типа T</returns>
        protected virtual T GetById(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        /// <summary>
        /// Добавляет сущность типа T в таблицу 
        /// </summary>
        /// <param name="addedObject">Добавляемая сущность</param>
        [HttpPost]
        public void Create(T addedObject)
        {
            _db.Add(addedObject).State = EntityState.Added;
            _db.SaveChanges();
        }
        
        /// <summary>
        /// Возвращает все сущности типа T
        /// </summary>
        /// <returns>Лист сущностей типа T</returns>
        [HttpGet]
        public List<T> ReadAll()
        {
            return _db.Set<T>().ToList();
        }
        
        /// <summary>
        /// Возвращает сущность типа T по Guid
        /// </summary>
        /// <param name="id">Guid сущности</param>
        /// <returns>Сущность типа T</returns>
        [Route("{id}")]
        [HttpGet]
        public T ReadById(Guid id)
        {
            return GetById(id);
        }

        /// <summary>
        /// Обновляет сущность типа T
        /// </summary>
        /// <param name="updatedObject">Обновляемая сущность</param>
        [HttpPut]
        public void Update(T updatedObject)
        {
            _db.Add(updatedObject).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
        /// <summary>
        /// Удаляем все сущности типа T
        /// </summary>
        [HttpDelete]
        public void DeleteAll()
        {
            _db.Set<T>().RemoveRange(_db.Set<T>().ToList());
            _db.SaveChanges();
        }
        
        /// <summary>
        /// Удаляем сущность типа T по Guid
        /// </summary>
        /// <param name="id"></param>
        [Route("{id}")]
        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _db.Add(GetById(id)).State = EntityState.Deleted;
            _db.SaveChanges();
        }

   
    }
}