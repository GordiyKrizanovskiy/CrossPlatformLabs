using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Lab6.Models;
using Lab6.Data;

namespace Lab6.Controllers;

[Route("transactions/search")]
public class FinancialTransactionsController : Controller
{
    private readonly FinancialDbContext _context;

    public FinancialTransactionsController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SearchResults(DateTime? date, List<string> cardNumbers, string startsWith, string endsWith)
    {
        var transactions = _context.FinancialTransactions
            .Include(t => t.Card)
            .Include(t => t.Card.CurrencyCode)
            .Include(t => t.Card.Cardholder)
            .AsQueryable();

        if (date.HasValue)
            transactions = transactions.Where(t => t.TransactionDate.Date == date.Value.Date);

        if (cardNumbers != null && cardNumbers.Any())
            transactions = transactions.Where(t => cardNumbers.Contains(t.Card.CardNumber));

        if (!string.IsNullOrEmpty(startsWith))
            transactions = transactions.Where(t => t.Card.CardNumber.StartsWith(startsWith));

        if (!string.IsNullOrEmpty(endsWith))
            transactions = transactions.Where(t => t.Card.CardNumber.EndsWith(endsWith));

        return View(transactions.ToList());
    }
}
