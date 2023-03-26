﻿using EmptyMVC.Views.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Analyst;
using ModelTranslator.DAO;

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
        public void ProcessRequest(ProcessDto process)
        {
            //return $"{process.VkId}: {process.ProcessType}: {process.ComVkId}";
            Response.Redirect($"/Process/Answer?VkId={process.VkId}&ProcessType={process.ProcessType}&ComVkId={process.ComVkId}");
        }

        public IActionResult Answer (ProcessDto process)
        {
            AnalystWorker analyst = new AnalystWorker();
            ResponseDao result = analyst.GetData(new RequestDao(process.VkId));

            var answer = new AnswerModel(process.VkId, process.ProcessType, process.ComVkId, result.UserArr, result.GroupArr);
            return View("Answer", answer);
        }

        public record class ProcessDto(int VkId = -1, Process ProcessType = Process.None, int ComVkId = -1);

        
    }
}