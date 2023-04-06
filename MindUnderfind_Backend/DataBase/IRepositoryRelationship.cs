using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAPI
{
    public interface IRepositoryRelationship<T> where T : class
    {
        /// <summary>
        /// Получение всех объектов данного репазитория
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>?> GetList();
        /// <summary>
        /// Получение одного объекта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> Get(int idFirst, int idSecond);
        /// <summary>
        /// создание объекта
        /// </summary>
        /// <param name="item"></param>
        Task CreateAsync(T item);
        /// <summary>
        /// обновление объекта
        /// </summary>
        /// <param name="item"></param>
        Task UpdateAsync(T item);
        /// <summary>
        /// удаление объекта по ID
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(T item);
        
        Task SaveAsync();  // сохранение изменений
    }
}
