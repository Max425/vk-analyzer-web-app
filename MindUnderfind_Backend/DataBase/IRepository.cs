using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAPI
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение всех объектов данного репазитория
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        IEnumerable<T> GetList();
        /// <summary>
        /// Получение одного объекта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// создание объекта
        /// </summary>
        /// <param name="item"></param>
        void CreateAsync(T item);
        /// <summary>
        /// обновление объекта
        /// </summary>
        /// <param name="item"></param>
        void UpdateAsync(T item);
        /// <summary>
        /// удаление объекта по ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteAsync(int id);
        //void Save();  // сохранение изменений
    }
}
