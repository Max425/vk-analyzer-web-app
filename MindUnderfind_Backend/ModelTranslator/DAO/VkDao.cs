using DataBaseModels;

namespace ModelTranslator.DAO;

public class VkDao
{
    public User User { get; set; }
    public Community Community { get; set; }
    public readonly Process ProcessType;
    public VkDao(Process process = Process.None) => ProcessType = process;
}
/*public class VkCommunityDao : VkDao
{
    public long GroupVkId { get; set; }
    public IEnumerable<VkUserDao> VkGroupUsersDao { get; set; } = null!;
    public IEnumerable<VkGroupDao> VkGroupUsersGroups { get; set; } = null!;

    public VkCommunityDao() : base("Community") { }
}
public class VkFriendDao : VkDao
{
    public IEnumerable<VkUserDao> VkFriendsDaos { get; set; } = null!;
    public IEnumerable<VkGroupDao> VkFriendGroups { get; set; } = null!;

    public VkFriendDao() : base("Friends") { }
}
public class VkFriendsFriendDao : VkDao
{
    public IEnumerable<VkUserDao> VkFriendsDaos { get; set; } = null!;
    public IEnumerable<VkUserDao> VkFriendFriendsDaos { get; set; } = null!;
    public IEnumerable<VkGroupDao> VkFriendFriendGroups { get; set; } = null!;

    public VkFriendsFriendDao() : base("FriendsOfFriends") { }
} */