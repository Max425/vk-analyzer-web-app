namespace DataBaseAPI;

public interface IRelationshipRepository<T> where T : class
{
    /// <summary>
    /// Получение всех объектов данного репазитория
    /// </summary>
    /// <returns>Task<IEnumerable<T>></returns>
    public Task<IEnumerable<T>?> GetList();

    /// <summary>
    /// Получение одного объекта по ID
    /// </summary>
    /// <param name="idFirst"></param>
    /// <param name="idSecond"></param>
    /// <returns>Task<T?></returns>
    public Task<T?> Get(int idFirst, int idSecond);
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
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task DeleteAsync(T item);
}