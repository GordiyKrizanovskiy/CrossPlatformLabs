using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Models;
using Lab6.Data;

namespace Lab6.Controllers;

[Route("ref-currency-codes")]
public class RefCurrencyCodesController : Controller
{
    private readonly FinancialDbContext _context;

    public RefCurrencyCodesController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var currencyCodes = _context.RefCurrencyCodes.ToList();
        return View(currencyCodes);
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var currencyCode = _context.RefCurrencyCodes.FirstOrDefault(c => c.CurrencyCode == id);
        if (currencyCode == null) return NotFound();
        return View(currencyCode);
    }
}
