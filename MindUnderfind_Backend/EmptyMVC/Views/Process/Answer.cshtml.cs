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
        public List<long> UsersArr { get; set; } = new List<long>();

        public AnswerModel() { }
        public AnswerModel(int vkId, Process processType, int comVkId, List<long> usersArr)
        {
            VkId = vkId;
            ProcessType = processType;
            ComVkId = comVkId;
            UsersArr = usersArr;
        }

        public void OnGet()
        {

        }
    }
}
