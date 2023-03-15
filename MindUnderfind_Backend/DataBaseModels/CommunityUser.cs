using Microsoft.EntityFrameworkCore;

namespace DataBaseModels
{
    [PrimaryKey("ChainId")]
    public class CommunityUser
    {
        public string ChainId { get; set; }
        public Community CommunityId { get; set; }
        public User UserAccountId { get; set; }

        public CommunityUser() { }
        public CommunityUser(Community communityId, User userAccountId)
        {
            ChainId = communityId.ToString() + userAccountId.ToString();
            CommunityId = communityId;
            UserAccountId = userAccountId;
        }

        public override string ToString() => $"Chain {ChainId} : {CommunityId.VkId} - {UserAccountId.VkId}";
    }
}