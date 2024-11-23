using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}