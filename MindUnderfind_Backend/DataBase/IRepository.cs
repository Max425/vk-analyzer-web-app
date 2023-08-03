namespace DataBaseAPI;

public interface IRepository<T>
{
    /// <summary>
    /// Получение всех объектов данного репазитория
    /// </summary>
    /// <returns>Task<IEnumerable<T>></returns>
    public Task<IEnumerable<T>?> GetList();
    /// <summary>
    /// Получение одного объекта по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task<T?></returns>
    public Task<T?> Get(int id);
    /// <summary>
    /// создание объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task CreateAsync(T item);
    /// <summary>
    /// обновление объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task UpdateAsync(T item);
    /// <summary>
    /// удаление объекта по ID
    /// </summary>
    /// <returns>Task</returns>
    public Task DeleteAsync(int id);
}