using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;
using VkGroup = VkNet.Model.Group;
using DataBaseModels;

namespace ModelTranslator.DTO;

public class VkUserDto
{
    public long VkId { get; set; }
    public List<VkUser>? UserFriFri { get; set; } = new();
    public List<VkUser>? UserFri { get; set; } = new();
    public List<VkGroup>? UserGroups { get; set; } = new();
    public VkUserDto(long vkId) => VkId = vkId;
    public VkUserDto(long vkId,
        List<VkUser>? userFriFri = null,
        List<VkUser>? userFri = null,
        List<VkGroup>? userGroups = null)
    {
        VkId = vkId;
        if (userFriFri != null) UserFriFri = userFriFri;
        if (userFri != null) UserFri = userFri;
        if (userGroups != null) UserGroups = userGroups;
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

    public User ToUser()
    {
        return new User(VkId)
        {
            Communities = UserGroups?.ConvertAll(group => new DataBaseModels.Community(group.Id)),
            Friends = UserFri?.ConvertAll(user => new DataBaseModels.User(user.Id)),
        };

    }
}