namespace ModelTranslator.DAO;

public class VkDao
{
    public long UserVkId { get; set; }
    public readonly string ProcessType;
    public VkDao(string str) => ProcessType = str;
}
public class VkCommunityDao : VkDao
{
    public IEnumerable<VkGroupDao> VkGroupDaos { get; set; } = null!;
    public IEnumerable<VkUserDao> VkGroupUsersDaos { get; set; } = null!;
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
}