using DataBaseModels;
using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;

namespace ModelTranslator.DTO;

public class VkGroupDto
{
    private long GroupId { get; set; }
    private List<VkUser>? GroupUsers { get; set; }

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

}