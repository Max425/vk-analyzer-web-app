using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels;

namespace ModelTranslator.DAO
{
    public class ResponseDao
    {
        //вот тут возвращаются данные для визуализации
        //надо понять, че вообще и  в каком формате возвращать будем =)
        public int VkId { get; set; }
        public int ComVkId { get; set; } = -1;
        public List<User> UserArr { get; set; } = new();
        public List<Community> GroupArr { get; set; } = new();
        public List<CommunityUsers> CommunityUser { get; set; } = new();
        public ResponseDao(int vkId, int comVkId = -1)
        {
            VkId = vkId;
            ComVkId = comVkId;
        }
    }
}
