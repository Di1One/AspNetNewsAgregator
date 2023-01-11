using AspNetNewsAgregatorMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetNewsAgregatorMvcApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var cat = new
            {
                Name = "Vasya",
                Age = 6
            };

            return Ok(cat);
        }

        [HttpGet]
        public string Test(int number)
        {
            return $"{number}*{number}={number*number}";
        }

        [HttpGet]
        public string Test2(TestModel model)
        {
            return $"{model.Id},{model.Name},{model.Age}";
        }

        [HttpGet]
        public IActionResult FillTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FillTest(TestModel model)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
