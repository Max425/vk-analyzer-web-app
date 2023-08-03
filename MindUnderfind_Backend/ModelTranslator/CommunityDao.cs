using DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator
{
    public class CommunityDao
    {
        public long VkId { get; set; }
        public DateTime LastUpdate { get; set; }

        public List<User> Users { get; set; } = new();

        public CommunityDao(long vkId)
        {
            VkId = vkId;
            LastUpdate = DateTime.UtcNow;
        }
        public CommunityDao(long vkId, List<User> users) : this(vkId)
        {
            Users = users;
        }
        public override string ToString() => $"Community VkId: https://vk.com/public{VkId}";
        public string GetUrl() => $"https://vk.com/public{VkId}";
        public override bool Equals(object? obj)
        {
            return obj is Community com && VkId == com.VkId;
        }
        public override int GetHashCode() => VkId.GetHashCode();
    }
}
