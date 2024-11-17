using Microsoft.AspNetCore.Mvc;
using Library; 
using Microsoft.AspNetCore.Authorization;

namespace WebAppProject.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        // Метод для відображення вибору лабораторної роботи
        public IActionResult Index()
        {
            return View();
        }

        // Lab1
        [HttpGet]
        public IActionResult Lab1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab1(string inputFilePath, string outputFilePath)
        {
            string[] args = { "-I", inputFilePath, "-o", outputFilePath };
            Lab1Runner.Run(args);

            ViewBag.ResultMessage = $"Результат Lab1 збережено в {outputFilePath}";
            return View();
        }

        // Lab2
        [HttpGet]
        public IActionResult Lab2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab2(string inputFilePath, string outputFilePath)
        {
            string[] args = { "-I", inputFilePath, "-o", outputFilePath };
            Lab2Runner.Run(args);

            ViewBag.ResultMessage = $"Результат Lab2 збережено в {outputFilePath}";
            return View();
        }

        // Lab3
        [HttpGet]
        public IActionResult Lab3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab3(string inputFilePath, string outputFilePath)
        {
            string[] args = { "-I", inputFilePath, "-o", outputFilePath };
            Lab3Runner.Run(args);

            ViewBag.ResultMessage = $"Результат Lab3 збережено в {outputFilePath}";
            return View();
        }
    }
}
