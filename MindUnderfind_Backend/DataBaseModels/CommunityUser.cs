using Microsoft.EntityFrameworkCore;

namespace DataBaseModels
{
    public class CommunityUsers
    {
        public int CommunityId { get; set; }
        public Community? Community { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        
        public CommunityUsers() { }
        public CommunityUsers(Community communityId, User userId)
        {
            CommunityId = communityId.VkId;
            UserId = userId.VkId;
        }

        public override string ToString() => $"Chain : {CommunityId} - {UserId}";
        public override bool Equals(object? obj)
        {
            if (obj is CommunityUsers cu) return CommunityId == cu.CommunityId && UserId == cu.UserId;
            return false;
        }
        public override int GetHashCode() => $"{CommunityId}{UserId}".GetHashCode();

    }
}