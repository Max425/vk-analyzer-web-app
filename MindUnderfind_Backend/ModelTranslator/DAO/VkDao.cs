using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModelTranslator.DAO
{
    public class VkDao
    {
        public long UserVkId { get; set; }
        public readonly string ProcessType;
        public VkDao(string str) => ProcessType = str;
    }
    public class VkCommunityDao : VkDao
    {
        public IEnumerable<VkGroupDao> VkGroupDaos { get; set; }
        public IEnumerable<VkUserDao> VkGroupUsersDaos { get; set; }
        public IEnumerable<VkGroupDao> VkGroupUsersGroups { get; set; }

        public VkCommunityDao() : base("Community") { }
    }
    public class VkFriendDao : VkDao
    {
        public IEnumerable<VkUserDao> VkFriendsDaos { get; set; }
        public IEnumerable<VkGroupDao> VkFriendGroups { get; set; }

        public VkFriendDao() : base("Friends") { }
    }
    public class VkFriendsFriendDao : VkDao
    {
        public IEnumerable<VkUserDao> VkFriendsDaos { get; set; }
        public IEnumerable<VkUserDao> VkFriendFriendsDaos { get; set; }
        public IEnumerable<VkGroupDao> VkFriendFriendGroups { get; set; }

        public VkFriendsFriendDao() : base("FriendsOfFriends") { }
    }

}