using Microsoft.AspNetCore.Mvc;
using Library; 
using Microsoft.AspNetCore.Authorization;

namespace WebAppProject.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        // ����� ��� ����������� ������ ����������� ������
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

            ViewBag.ResultMessage = $"��������� Lab1 ��������� � {outputFilePath}";
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

            ViewBag.ResultMessage = $"��������� Lab2 ��������� � {outputFilePath}";
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

            ViewBag.ResultMessage = $"��������� Lab3 ��������� � {outputFilePath}";
            return View();
        }
    }
}
