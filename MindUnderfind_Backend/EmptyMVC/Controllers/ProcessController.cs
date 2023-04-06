using EmptyMVC.Views.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Analyst;
using ModelTranslator.DAO;
using ModelTranslator.DTO;
using ModelTranslator;

namespace EmptyMVC.Controllers
{
    public class ProcessController : Controller
    {
        [ActionName("Request")]
        public IActionResult ProcessRequest()
        {
            return View("Request");
        }

        [ActionName("Request")]
        [HttpPost]
        public void ProcessRequest(RequestDto process)
        {
            //return $"{process.VkId}: {process.ProcessType}: {process.ComVkId}";
            Response.Redirect($"/Process/Answer?VkId={process.VkId}&ProcessType={process.ProcessType}&ComVkId={process.ComVkId}");
        }

        public IActionResult Answer (RequestDto processDto)
        {
            AnalystWorker analyst = new AnalystWorker();
            ResponseDao responseDto = analyst.GetData(processDto.ToRequestDao());

            var answer = new AnswerModel(processDto, responseDto);
            return View("Answer", answer);
        }

        

        
    }
}