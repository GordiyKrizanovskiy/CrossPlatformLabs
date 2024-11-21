using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab6.Models;

namespace Lab6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}