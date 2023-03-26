using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator.DAO
{
    public class RequestDao
    {
        public int VkId { get; set; }
        public int ComVkId { get; set; } = -1;
        public RequestDao(int vkId)
        {
            VkId = vkId;
        }
        public RequestDao(int vkId, int comVkId) : this(vkId)
        {
            ComVkId = comVkId;
        }
    }
}
