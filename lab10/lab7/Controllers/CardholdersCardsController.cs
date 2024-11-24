using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardholdersCardsController : ControllerBase
    {
        private readonly DataContext _context;

        public CardholdersCardsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/cardholderscards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardholdersCards>>> GetCardholdersCards()
        {
            return await _context.CardholdersCards
                .Include(cc => cc.Cardholder)
                .Include(cc => cc.CardType)
                .Include(cc => cc.Currency)
                .ToListAsync();
        }

        // POST: api/cardholderscards
        [HttpPost]
        public async Task<ActionResult<CardholdersCards>> CreateCardholdersCards(CardholdersCards card)
        {
            _context.CardholdersCards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCardholdersCards), card);
        }
    }
}
