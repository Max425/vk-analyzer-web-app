using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;
using VkGroup = VkNet.Model.Group;

namespace ModelTranslator.DTO
{
    public class VkUserDto
    {
        public long VkId { get; set; }
        public List<VkUser>? UserFriFri { get; set; } = new();
        public List<VkUser>? UserFri { get; set; } = new();
        public List<VkGroup>? UserGroups { get; set; } = new();
        public VkUserDto() { }
        public VkUserDto(long vkId,
                        List<VkUser>? userFriFri,
                        List<VkUser>? userFri,
                        List<VkGroup>? userGroups)
        {
            VkId = vkId;
            UserFriFri = userFriFri;
            UserFri = userFri;
            UserGroups = userGroups;
        }

        public VkUserDao ToVkUserDao()
        {
            var dao = new VkUserDao();

            dao.VkId = VkId;

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

            return dao;
        }
    }
}
