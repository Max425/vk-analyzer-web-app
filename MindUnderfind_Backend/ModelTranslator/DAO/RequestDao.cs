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
        public Process ProcessType { get; set; } = Process.None;
        public RequestDao(int vkId, int comVkId = -1, Process process = Process.None)
        {
            VkId = vkId;
            ComVkId = comVkId;
            ProcessType = process;
        }
    }
}
