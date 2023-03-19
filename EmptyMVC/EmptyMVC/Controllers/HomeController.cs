using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmptyMVC.Controllers
{
    public class HomeController : Controller
    {
        /*public async Task Index()
        {
            string content = @"<form method='post'>
                <label>Name:</label><br />
                <input name='name' /><br />
                <label>Age:</label><br />
                <input type='number' name='age' /><br />
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }

        [HttpPost]
        public string Index(Person person) => $"{person.Name}: {person.Age}";*/

        public IActionResult Index()
        {
            return View("View  ");
        }

        public record class Person(string Name, int Age);
    }
}