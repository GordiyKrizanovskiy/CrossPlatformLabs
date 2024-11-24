using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsBanksController : ControllerBase
    {
        private readonly DataContext _context;

        public MerchantsBanksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/merchantsbanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchantsBanks>>> GetMerchantsBanks()
        {
            return await _context.MerchantsBanks
                .Include(mb => mb.Merchant)
                .Include(mb => mb.Bank)
                .ToListAsync();
        }

        // POST: api/merchantsbanks
        [HttpPost]
        public async Task<ActionResult<MerchantsBanks>> CreateMerchantsBanks(MerchantsBanks merchantsBanks)
        {
            _context.MerchantsBanks.Add(merchantsBanks);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMerchantsBanks), merchantsBanks);
        }
    }
}
