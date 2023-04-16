using DataBaseModels;

namespace DataBaseAPI;

public interface IComUserRepository : IRelationshipRepository<CommunityUsers>
{
    /// <summary>
    /// Получение всех объектов данного репазитория
    /// </summary>
    /// <returns>Task<IEnumerable<CommunityUsers>></returns>
    public Task<IEnumerable<CommunityUsers>?> GetList();

    /// <summary>
    /// Получение одного объекта по ID
    /// </summary>
    /// <param name="idFirst"></param>
    /// <param name="idSecond"></param>
    /// <returns>Task<CommunityUsers?></returns>
    public Task<CommunityUsers?> Get(int idFirst, int idSecond);
    /// <summary>
    /// создание объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task CreateAsync(CommunityUsers item);
    /// <summary>
    /// обновление объекта
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task UpdateAsync(CommunityUsers item);

    /// <summary>
    /// удаление объекта по ID
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Task</returns>
    public Task DeleteAsync(CommunityUsers item);
}