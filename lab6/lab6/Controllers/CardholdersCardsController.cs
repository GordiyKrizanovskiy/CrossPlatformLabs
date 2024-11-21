using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

namespace Lab6.Controllers;

[Route("cardholders-cards")]
public class CardholdersCardsController : Controller
{
    private readonly FinancialDbContext _context;

    public CardholdersCardsController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var cards = _context.CardholdersCards
            .Include(c => c.Cardholder)
            .Include(c => c.Currency) 
            .ToList();
        return View(cards);
    }

    [HttpGet("{cardNumber}")]
    public IActionResult Details(string cardNumber)
    {
        var card = _context.CardholdersCards
            .Include(c => c.Cardholder)
            .Include(c => c.Currency)
            .FirstOrDefault(c => c.CardNumber == cardNumber);

        if (card == null)
            return NotFound();

        return View(card);
    }
}
