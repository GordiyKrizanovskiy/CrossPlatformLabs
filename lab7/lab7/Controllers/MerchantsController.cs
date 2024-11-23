using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly DataContext _context;

        public MerchantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/merchants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchant>>> GetMerchants()
        {
            return await _context.Merchants.ToListAsync();
        }

        // GET: api/merchants/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchant>> GetMerchant(int id)
        {
            var merchant = await _context.Merchants.FindAsync(id);

            if (merchant == null)
            {
                return NotFound();
            }

            return merchant;
        }

        // POST: api/merchants
        [HttpPost]
        public async Task<ActionResult<Merchant>> CreateMerchant(Merchant merchant)
        {
            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMerchant), new { id = merchant.MerchantId }, merchant);
        }

        // PUT: api/merchants/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerchant(int id, Merchant merchant)
        {
            if (id != merchant.MerchantId)
            {
                return BadRequest();
            }

            _context.Entry(merchant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/merchants/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }

            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchantExists(int id)
        {
            return _context.Merchants.Any(e => e.MerchantId == id);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Merchant>>> SearchMerchants(
            [FromQuery] string? categoryCode,
            [FromQuery] string? countryCode)
        {
            var query = _context.Merchants.AsQueryable();

            if (!string.IsNullOrEmpty(categoryCode))
            {
                query = query.Where(m => m.MerchantCategoryCode == categoryCode);
            }

            if (!string.IsNullOrEmpty(countryCode))
            {
                query = query.Where(m => m.CountryCode == countryCode);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }
        
    }
}
