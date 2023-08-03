using DataBaseModels;

namespace DataBaseAPI;

public interface ICommunityRepository : IRepository<Community>
{
    /// <summary>
    /// Получение всех объектов данного репазитория
    /// </summary>
    /// <returns>Task<IEnumerable<Community>></returns>
    public Task<IEnumerable<Community>?> GetList();
    /// <summary>
    /// Получение одного объекта по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task<Community?></returns>
    public Task<Community?> Get(int id);
    /// <summary>
    /// создание объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task CreateAsync(Community item);
    /// <summary>
    /// обновление объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task UpdateAsync(Community item);
    /// <summary>
    /// удаление объекта по ID
    /// </summary>
    /// <returns>Task</returns>
    public Task DeleteAsync(int id);
}