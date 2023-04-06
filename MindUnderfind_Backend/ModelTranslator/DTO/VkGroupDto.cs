using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataBaseModels;
using ModelTranslator.DAO;

using VkUser = VkNet.Model.User;

namespace ModelTranslator.DTO
{
    public class VkGroupDto
    {
        public long GroupId { get; set; }
        public List<VkUser>? GroupUsers { get; set; } = new();

        public VkGroupDto(long groupId, List<VkUser>? groupUsers)
        {
            GroupId = groupId;
            GroupUsers = groupUsers;
        }

        public VkGroupDao ToVkGroupDao()
        {
            var dao = new VkGroupDao();

            dao.GroupId = GroupId;

            if (GroupUsers?.Count != 0)
                foreach (var el in GroupUsers)
                {
                    dao.GroupUsers?.Add(new DataBaseModels.User(el.VkId));
                }

            return dao;
        }

    }
}