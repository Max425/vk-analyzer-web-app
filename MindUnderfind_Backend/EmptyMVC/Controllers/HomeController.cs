using EmptyMVC.Views.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmptyMVC.Controllers
{
    public class HomeController : Controller
    {
        [ActionName("Request")]
        public IActionResult ProcessRequest()
        {
            return View("Request");
        }

        [HttpPost]
        public void ProcessRequest(ProcessDto process)
        {
            //return $"{process.VkId}: {process.ProcessType}: {process.ComVkId}";
            Response.Redirect($"/Home/Answer?VkId={process.VkId}&ProcessType={process.ProcessType}&ComVkId={process.ComVkId}");
        }

        public IActionResult Answer (ProcessDto process)
        {
            var answer = new AnswerModel(process.VkId, process.ProcessType, process.ComVkId);
            return View("Answer", answer);
        }

       /* public IActionResult IndexView()
        {
            return View("View");
        }*/

        public record class ProcessDto(int VkId = -1, Process ProcessType = Process.None, int ComVkId = -1);

        
    }
}