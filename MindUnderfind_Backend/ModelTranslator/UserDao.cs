using DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator
{
    public class UserDao
    {
        public long VkId { get; set; }
        public bool Rights { get; set; }
        public List<Community> Communities { get; set; } = new();
        public List<User>? Friends { get; set; }
        public UserDao(long vkId, bool rights = false)
        {
            VkId = vkId;
            Rights = rights;
        }
        public override bool Equals(object? obj)
        {
            if (obj is User user) return VkId == user.VkId;
            return false;
        }
        public override int GetHashCode() => VkId.GetHashCode();
        public override string ToString() => $"UserAccount https://vk.com/id{VkId}";
        public string GetUrl() => $"https://vk.com/id{VkId}";
    }
}
