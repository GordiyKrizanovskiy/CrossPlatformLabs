using Microsoft.AspNetCore.Mvc;
using FinancialAPI.Data;
using FinancialAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly FinancialDbContext _context;

    public CardsController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetCards()
    {
        return await _context.Cards.Include(c => c.Transactions).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Card>> CreateCard(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCards), new { id = card.CardNumber }, card);
    }
}
