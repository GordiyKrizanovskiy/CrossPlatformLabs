using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefCardTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public RefCardTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/refcardtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefCardTypes>>> GetRefCardTypes()
        {
            return await _context.RefCardTypes.ToListAsync();
        }

        // GET: api/refcardtypes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RefCardTypes>> GetRefCardType(string id)
        {
            var cardType = await _context.RefCardTypes.FindAsync(id);

            if (cardType == null)
            {
                return NotFound();
            }

            return cardType;
        }

        // POST: api/refcardtypes
        [HttpPost]
        public async Task<ActionResult<RefCardTypes>> CreateRefCardType(RefCardTypes cardType)
        {
            _context.RefCardTypes.Add(cardType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRefCardType), new { id = cardType.CardTypeCode }, cardType);
        }

        // DELETE: api/refcardtypes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefCardType(string id)
        {
            var cardType = await _context.RefCardTypes.FindAsync(id);
            if (cardType == null)
            {
                return NotFound();
            }

            _context.RefCardTypes.Remove(cardType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
