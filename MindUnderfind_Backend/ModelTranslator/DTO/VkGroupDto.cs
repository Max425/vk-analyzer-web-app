using DataBaseModels;
using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;

namespace ModelTranslator.DTO;

public class VkGroupDto
{
    public long GroupId { get; set; }
    public List<VkUser>? GroupUsers { get; set; } = new();
    public VkGroupDto(long vkId) => GroupId = vkId;
    public VkGroupDto(long groupId, List<VkUser>? groupUsers)
    {
        GroupId = groupId;
        GroupUsers = groupUsers;
    }

    public VkGroupDao ToVkGroupDao()
    {
        return new VkGroupDao
        {
            GroupId = GroupId,
            GroupUsers = GroupUsers?.ConvertAll(user => new User(user.Id))
        };
    }

    public Community ToCommunity()
    {
        return new Community(GroupId)
        {
            Users = GroupUsers?.ConvertAll(vkUser => new User(vkUser.Id)),
        };

    }

}