using System;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace yogaAshram.Models
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        IEnumerable<T> GetAllList(); // получение всех объектов
        T Get(long id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(long id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}