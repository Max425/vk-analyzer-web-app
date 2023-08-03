namespace DataBaseModels;

public class CommunityUsers
{
    public long CommunityId { get; set; }
    public Community? Community { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public CommunityUsers(long communityId, long userId)
    {
        CommunityId = communityId;
        UserId = userId;
    }
    public CommunityUsers(Community communityId, User userId)
    {
        CommunityId = communityId.VkId;
        UserId = userId.VkId;
    }
}