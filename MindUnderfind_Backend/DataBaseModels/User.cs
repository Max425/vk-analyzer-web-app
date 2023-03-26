using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DataBaseModels
{
    [PrimaryKey("VkId")]
    public class User
    {
        public int VkId { get; set; }
        public bool Rights { get; set; }

        public List<CommunityUser> CommunityUsers { get; set; }
        public List<Community> Communities { get; set; }
        public List<User> Users { get; set; }
        public List<UserFriend> UserFriends { get; set; }
        //public User() { }
        public User(long vkId, bool rights = false)
        {
            VkId = (int)vkId;
            Rights = rights;
        }
        public override bool Equals(object? obj)
        {
            if (obj is User user) return VkId == user.VkId;
            return false;
        }
        public override int GetHashCode() => VkId.GetHashCode();
        public override string ToString() => $"UserAccount {VkId} with VkId {VkId}.";
    }
}