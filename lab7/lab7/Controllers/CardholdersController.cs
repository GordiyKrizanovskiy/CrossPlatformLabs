using Microsoft.AspNetCore.Http;
using lab7.Data;
using lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardholdersController : ControllerBase
    {
        private readonly DataContext _context;

        public CardholdersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/cardholders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cardholder>>> GetCardholders()
        {
            return await _context.Cardholders.ToListAsync();
        }

        // GET: api/cardholders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cardholder>> GetCardholder(int id)
        {
            var cardholder = await _context.Cardholders.FindAsync(id);

            if (cardholder == null)
            {
                return NotFound();
            }

            return cardholder;
        }

        // POST: api/cardholders
        [HttpPost]
        public async Task<ActionResult<Cardholder>> CreateCardholder(Cardholder cardholder)
        {
            _context.Cardholders.Add(cardholder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCardholder), new { id = cardholder.CardholderId }, cardholder);
        }

        // PUT: api/cardholders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCardholder(int id, Cardholder cardholder)
        {
            if (id != cardholder.CardholderId)
            {
                return BadRequest();
            }

            _context.Entry(cardholder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardholderExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/cardholders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardholder(int id)
        {
            var cardholder = await _context.Cardholders.FindAsync(id);
            if (cardholder == null)
            {
                return NotFound();
            }

            _context.Cardholders.Remove(cardholder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardholderExists(int id)
        {
            return _context.Cardholders.Any(e => e.CardholderId == id);
        }
    }
}