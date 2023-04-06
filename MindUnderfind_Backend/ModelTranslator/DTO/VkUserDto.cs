using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;
using VkGroup = VkNet.Model.Group;

namespace ModelTranslator.DTO;

public class VkUserDto
{
    private long VkId { get; set; }
    private List<VkUser>? UserFriFri { get; set; } = new();
    private List<VkUser>? UserFri { get; set; } = new();
    private List<VkGroup>? UserGroups { get; set; } = new();
    public VkUserDto() { }
    public VkUserDto(long vkId,
        List<VkUser>? userFriFri,
        List<VkUser>? userFri,
        List<VkGroup>? userGroups)
    {
        VkId = vkId;
        UserFriFri = userFriFri;
        UserFri = userFri;
        UserGroups = userGroups;
    }

    public VkUserDao ToVkUserDao()
    {
        return new VkUserDao
        {
            VkId = VkId,
            UserGroups = UserGroups?.ConvertAll(group => new DataBaseModels.Community(group.Id)),
            UserFri = UserFri?.ConvertAll(user => new DataBaseModels.User(user.Id)),
            UserFriFri = UserFriFri?.ConvertAll(user => new DataBaseModels.User(user.Id))
                
        };
    }
}