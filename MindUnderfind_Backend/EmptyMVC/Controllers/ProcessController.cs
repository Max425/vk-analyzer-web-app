using EmptyMVC.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Analyst;
using ModelTranslator.DTO;

namespace EmptyMVC.Controllers;

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
        var analyst = new AnalystWorker();
        try
        {
            var responseDto = analyst.GetData(processDto.ToRequestDao());
            var answer = new AnswerModel(processDto, responseDto);
            return View("Answer", answer);
        }
        catch (Exception ex)
        {
            var answer = new AnswerModel();
            answer.ErCode = 500;
            return View("Answer", answer);
        }
        

        
    }
}