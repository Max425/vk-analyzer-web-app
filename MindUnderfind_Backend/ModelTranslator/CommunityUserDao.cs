using DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator
{
    public class CommunityUserDao
    {
        public long CommunityId { get; set; }
        public Community? Community { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public CommunityUserDao(long communityId, long userId)
        {
            CommunityId = communityId;
            UserId = userId;
        }
        public CommunityUserDao(Community communityId, User userId)
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
