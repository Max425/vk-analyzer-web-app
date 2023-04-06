using DataBaseModels;

namespace ModelTranslator.DAO;

public class ResponseDao
{
    //вот тут возвращаются данные для визуализации
    //надо понять, че вообще и  в каком формате возвращать будем =)
    private int VkId { get; set; }
    private int ComVkId { get; set; }
    public List<User> UserArr { get; set; } = new();
    public List<Community> GroupArr { get; set; } = new();
    public List<CommunityUsers> CommunityUser { get; set; } = new();
    public ResponseDao(int vkId, int comVkId = -1)
    {
        VkId = vkId;
        ComVkId = comVkId;
    }
}