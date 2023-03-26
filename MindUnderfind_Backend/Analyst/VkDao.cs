using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;

namespace Analyst
{
    public class VkDao
    {
        public List<User>? UserFriFri { get; set; } = null;
        public List<User>? UserFri { get; set; } = null;
        public List<Group>? UserGroups { get; set; } = null;
        public List<User>? GroupUsers { get; set; } = null;
        public VkDao() { }
        public VkDao(List<User>? userFriFri,
                        List<User>? userFri,
                        List<Group>? userGroups,
                        List<User>? groupUsers)
        {
            UserFriFri = userFriFri;
            UserFri = userFri;
            UserGroups = userGroups;
            GroupUsers = groupUsers;
        }
    }
}
