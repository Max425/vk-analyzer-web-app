using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyst
{
    public class ResponseDao
    {
        //вот тут возвращаются данные для визуализации
        //надо понять, че вообще и  в каком формате возвращать будем =)
        public int VkId { get; set; }
        public int ComVkId { get; set; } = -1;
        public List<long> UserArr { get; set; }
        public ResponseDao(int vkId)
        {
            VkId = vkId;
        }
        public ResponseDao(int vkId, int comVkId) : this(vkId)
        {
            ComVkId = comVkId;
        }
    }
}
