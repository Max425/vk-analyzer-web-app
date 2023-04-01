using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using ModelTranslator.DAO;

namespace ModelTranslator.DTO
{
    public class VkDto
    {
        public List<User>? UserFriFri { get; set; } = new();
        public List<User>? UserFri { get; set; } = new();
        public List<Group>? UserGroups { get; set; } = new();
        public List<User>? GroupUsers { get; set; } = new();
        public VkDto() { }
        public VkDto(List<User>? userFriFri,
                        List<User>? userFri,
                        List<Group>? userGroups,
                        List<User>? groupUsers)
        {
            UserFriFri = userFriFri;
            UserFri = userFri;
            UserGroups = userGroups;
            GroupUsers = groupUsers;
        }

        public VkDao ToVkDao()
        {
            var dao = new VkDao();
            if (UserGroups?.Count != 0)
                foreach(var el in UserGroups)
                {
                    dao.UserGroups?.Add(new DataBaseModels.Community((int)el.Id));
                }
            if (UserFriFri?.Count != 0)
                foreach (var el in UserFriFri)
                {
                    dao.UserFriFri?.Add(new DataBaseModels.User((int)el.Id));
                }
            if (UserFri?.Count != 0)
                foreach (var el in UserFri)
                {
                    dao.UserFri?.Add(new DataBaseModels.User((int)el.Id));
                }
            if (GroupUsers?.Count != 0)
                foreach (var el in GroupUsers)
                {
                    dao.GroupUsers?.Add(new DataBaseModels.User((int)el.Id));
                }


            return dao;
        }
    }
}
