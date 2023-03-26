using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels;

namespace ModelTranslator.DAO
{
    public class VkDao
    {
        public List<User>? UserFriFri { get; set; } = new();
        public List<User>? UserFri { get; set; } = new();
        public List<Community>? UserGroups { get; set; } = new();
        public List<User>? GroupUsers { get; set; } = new();
        public VkDao() { }
        public VkDao(List<User>? userFriFri,
                        List<User>? userFri,
                        List<Community>? userGroups,
                        List<User>? groupUsers)
        {
            UserFriFri = userFriFri;
            UserFri = userFri;
            UserGroups = userGroups;
            GroupUsers = groupUsers;
        }
    }
}
