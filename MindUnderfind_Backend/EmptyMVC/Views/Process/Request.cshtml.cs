using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Tracing;
using ModelTranslator;

namespace EmptyMVC.Views.Home
{
    public class RequestModel : PageModel
    {
        public int VkId { get; set; } = -1;
        public Process ProcessType { get; set; } = Process.None;
        public int ComVkId { get; set; } = -1;

        public RequestModel() { }
        public RequestModel(int vkId, Process processType, int comVkId)
        {
            VkId = vkId;
            ProcessType = processType;
            ComVkId = comVkId;
        }

        public void OnGet()
        {

        }
    }
}
