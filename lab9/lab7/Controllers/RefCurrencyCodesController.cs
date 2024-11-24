using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefCurrencyCodesController : ControllerBase
    {
        private readonly DataContext _context;

        public RefCurrencyCodesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/refcurrencycodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefCurrencyCodes>>> GetRefCurrencyCodes()
        {
            return await _context.RefCurrencyCodes.ToListAsync();
        }

        // GET: api/refcurrencycodes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RefCurrencyCodes>> GetRefCurrencyCode(string id)
        {
            var currency = await _context.RefCurrencyCodes.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        // POST: api/refcurrencycodes
        [HttpPost]
        public async Task<ActionResult<RefCurrencyCodes>> CreateRefCurrencyCode(RefCurrencyCodes currency)
        {
            _context.RefCurrencyCodes.Add(currency);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRefCurrencyCode), new { id = currency.CurrencyCode }, currency);
        }

        // DELETE: api/refcurrencycodes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefCurrencyCode(string id)
        {
            var currency = await _context.RefCurrencyCodes.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _context.RefCurrencyCodes.Remove(currency);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
