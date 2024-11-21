using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Lab6.Models;
using Lab6.Data;

namespace Lab6.Controllers;

[Route("ref-card-types")]
public class RefCardTypesController : Controller
{
    private readonly FinancialDbContext _context;

    public RefCardTypesController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var cardTypes = _context.RefCardTypes.ToList();
        return View(cardTypes);
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var cardType = _context.RefCardTypes.FirstOrDefault(c => c.CardTypeCode == id);
        if (cardType == null) return NotFound();
        return View(cardType);
    }
}
