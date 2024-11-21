using Microsoft.AspNetCore.Mvc;
using Library;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Lab5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        // Головна сторінка лабораторних
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

            ViewBag.ResultMessage = $"Роботу Lab1 виконано. Результати записано у файл {outputFilePath}";

            // Зчитуємо результати з файлу
            if (System.IO.File.Exists(outputFilePath))
            {
                ViewBag.OutputContent = System.IO.File.ReadAllText(outputFilePath);
            }
            else
            {
                ViewBag.OutputContent = "Файл результату не знайдено.";
            }

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

            ViewBag.ResultMessage = $"Роботу Lab2 виконано. Результати записано у файл {outputFilePath}";

            // Зчитуємо результати з файлу
            if (System.IO.File.Exists(outputFilePath))
            {
                ViewBag.OutputContent = System.IO.File.ReadAllText(outputFilePath);
            }
            else
            {
                ViewBag.OutputContent = "Файл результату не знайдено.";
            }

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

            ViewBag.ResultMessage = $"Роботу Lab3 виконано. Результати записано у файл {outputFilePath}";

            // Зчитуємо результати з файлу
            if (System.IO.File.Exists(outputFilePath))
            {
                ViewBag.OutputContent = System.IO.File.ReadAllText(outputFilePath);
            }
            else
            {
                ViewBag.OutputContent = "Файл результату не знайдено.";
            }

            return View();
        }
    }
}