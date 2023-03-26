using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Tracing;

namespace EmptyMVC.Views.Home
{
    public class AnswerModel : PageModel
    {
        public int VkId { get; set; } = -1;
        public Process ProcessType { get; set; } = Process.None;
        public int ComVkId { get; set; } = -1;

        public AnswerModel() { }
        public AnswerModel(int vkId, Process processType, int comVkId)
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
