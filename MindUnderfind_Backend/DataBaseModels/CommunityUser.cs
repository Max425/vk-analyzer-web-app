using Microsoft.EntityFrameworkCore;

namespace DataBaseModels
{
    public class CommunityUser
    {
        public Community CommunityId { get; set; }
        public Community? Community { get; set; }
        public User UserId { get; set; }
        public User? User { get; set; }

        //public CommunityUser() { }
        public CommunityUser(Community communityId, User userId)
        {
            CommunityId = communityId;
            UserId = userId;
        }

        /*public override string ToString() => $"Chain : {CommunityId.VkId} - {UserId.VkId}";
        public override bool Equals(object? obj)
        {
            if (obj is CommunityUser cu) return CommunityId == cu.CommunityId && UserId == cu.UserId;
            return false;
        }*/
        public override int GetHashCode() => $"{CommunityId}{UserId}".GetHashCode();

    }
}