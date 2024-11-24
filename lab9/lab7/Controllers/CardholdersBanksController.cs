using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardholdersBanksController : ControllerBase
    {
        private readonly DataContext _context;

        public CardholdersBanksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/cardholdersbanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardholdersBanks>>> GetCardholdersBanks()
        {
            return await _context.CardholdersBanks
                .Include(cb => cb.Cardholder)
                .Include(cb => cb.Bank)
                .ToListAsync();
        }

        // GET: api/cardholdersbanks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CardholdersBanks>> GetCardholdersBank(int id)
        {
            var cardholderBank = await _context.CardholdersBanks
                .Include(cb => cb.Cardholder)
                .Include(cb => cb.Bank)
                .FirstOrDefaultAsync(cb => cb.CardholderBankId == id);

            if (cardholderBank == null)
            {
                return NotFound();
            }

            return cardholderBank;
        }

        // POST: api/cardholdersbanks
        [HttpPost]
        public async Task<ActionResult<CardholdersBanks>> CreateCardholdersBank(CardholdersBanks cardholderBank)
        {
            _context.CardholdersBanks.Add(cardholderBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCardholdersBank), new { id = cardholderBank.CardholderBankId }, cardholderBank);
        }

        // DELETE: api/cardholdersbanks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardholdersBank(int id)
        {
            var cardholderBank = await _context.CardholdersBanks.FindAsync(id);
            if (cardholderBank == null)
            {
                return NotFound();
            }

            _context.CardholdersBanks.Remove(cardholderBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
