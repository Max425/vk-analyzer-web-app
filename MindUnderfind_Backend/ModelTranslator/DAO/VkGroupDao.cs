using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataBaseModels;

namespace ModelTranslator.DAO
{
    public class VkGroupDao
    {
        public long GroupId { get; set; }
        public List<User>? GroupUsers { get; set; } = new();
        public VkGroupDao() { }
        public VkGroupDao(long groupId, List<User>? groupUsers)
        {
            GroupId = groupId;
            GroupUsers = groupUsers;
        }
    }
}