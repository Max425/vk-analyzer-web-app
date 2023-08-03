using EmptyMVC.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Analyst;
using ModelTranslator.DTO;

namespace EmptyMVC.Controllers;

[ApiController]
[Route("/")]
public class ProcessController : Controller // ControllerBase
{
    private readonly IAnalystWorker _analystWorker;

    public ProcessController(IAnalystWorker analystWorker)
    {
        try
        {
            // TODO: Ловить данную ошикбу. Хотя ошибки в конструкторах - это грешно. Надо будет вообще пересмотреть данный констркуктор
            _analystWorker = analystWorker ?? throw new ArgumentNullException(nameof(analystWorker));
        }
        catch
        {
            Console.WriteLine("Разраб дурак. Проверь DI");
        }
        
    }

    [ActionName("Request")]
    [HttpGet("/Process/Request")]
    // public async Task<IActionResult> ProcessRequest() - ASK: зачем и как правильно реализовать async
    public IActionResult ProcessRequest()
    {
        return View("Request");
        // После запроса ложится
        // Не самая актуальная проблема, тк эта часть будем переписана
    }

    [ActionName("Request")]
    [HttpPost("/Process/Request")]
    // public async Task<IActionResult> ProcessRequest(RequestDto processDto) - ASK: зачем и как правильно реализоватть async
    public IActionResult ProcesRequest(RequestDto processDto)
    {
        try
        {
            var responseDto = _analystWorker.GetData(processDto.ToRequestDao());
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