using DataBaseModels;

namespace DataBaseAPI;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Получение всех объектов данного репазитория
    /// </summary>
    /// <returns>Task<IEnumerable<User>></returns>
    public Task<IEnumerable<User>?> GetList();
    /// <summary>
    /// Получение одного объекта по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task<User?></returns>
    public Task<User?> Get(int id);
    /// <summary>
    /// создание объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task CreateAsync(User item);
    /// <summary>
    /// обновление объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task UpdateAsync(User item);
    /// <summary>
    /// удаление объекта по ID
    /// </summary>
    /// <returns>Task</returns>
    public Task DeleteAsync(int id);
}
