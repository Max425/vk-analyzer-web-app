using DataBaseModels;

namespace ModelTranslator.DAO;

public class VkUserDao
{
    public long VkId { get; set; }
    public List<User>? UserFriFri { get; set; } = new();
    public List<User>? UserFri { get; set; } = new();
    public List<Community>? UserGroups { get; set; } = new();
    public VkUserDao() { }
    public VkUserDao(List<User>? userFriFri,
        List<User>? userFri,
        List<Community>? userGroups)
    {
        UserFriFri = userFriFri;
        UserFri = userFri;
        UserGroups = userGroups;
    }
}