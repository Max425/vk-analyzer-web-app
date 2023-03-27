using ModelTranslator.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator.DTO
{
    public class ProcessDto
    {
        public int VkId { get; set; } = -1;
        public Process ProcessType { get; set; } = Process.None;
        public int ComVkId { get; set; } = -1;

        public RequestDao ToRequestDao()
        {
            RequestDao dao = new(VkId, ComVkId, ProcessType);
            return dao;
        }
    }
}
