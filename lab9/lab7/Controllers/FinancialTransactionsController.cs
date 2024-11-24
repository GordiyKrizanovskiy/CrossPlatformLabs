using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionsController : ControllerBase
    {
        private readonly DataContext _context;

        public FinancialTransactionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/financialtransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialTransaction>>> GetFinancialTransactions()
        {
            return await _context.FinancialTransactions
                .Include(ft => ft.ATM)
                .Include(ft => ft.Card)
                .Include(ft => ft.Merchant)
                .Include(ft => ft.Currency)
                .ToListAsync();
        }

        // GET: api/financialtransactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialTransaction>> GetFinancialTransaction(int id)
        {
            var transaction = await _context.FinancialTransactions
                .Include(ft => ft.ATM)
                .Include(ft => ft.Card)
                .Include(ft => ft.Merchant)
                .Include(ft => ft.Currency)
                .FirstOrDefaultAsync(ft => ft.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/financialtransactions
        [HttpPost]
        public async Task<ActionResult<FinancialTransaction>> CreateFinancialTransaction(FinancialTransaction transaction)
        {
            // Перевірка валідності входу
            if (string.IsNullOrEmpty(transaction.ATMId) || 
                string.IsNullOrEmpty(transaction.CardNumber) ||
                string.IsNullOrEmpty(transaction.MerchantId) ||
                string.IsNullOrEmpty(transaction.CurrencyCode))
            {
                return BadRequest(new { message = "All required fields (ATMId, CardNumber, MerchantId, CurrencyCode) must be provided." });
            }

            _context.FinancialTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFinancialTransaction), new { id = transaction.TransactionId }, transaction);
        }


        // PUT: api/financialtransactions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFinancialTransaction(int id, FinancialTransaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialTransactionExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/financialtransactions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialTransaction(int id)
        {
            var transaction = await _context.FinancialTransactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.FinancialTransactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialTransactionExists(int id)
        {
            return _context.FinancialTransactions.Any(e => e.TransactionId == id);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<FinancialTransaction>>> SearchTransactions(
            [FromQuery] string? merchantId,
            [FromQuery] string? currencyCode)
        {
            var query = _context.FinancialTransactions
                .Include(ft => ft.ATM)
                .Include(ft => ft.Card)
                .Include(ft => ft.Merchant)
                .Include(ft => ft.Currency)
                .AsQueryable();

            // Фільтр за MerchantId
            if (!string.IsNullOrEmpty(merchantId))
            {
                query = query.Where(ft => ft.MerchantId == merchantId);
            }

            // Фільтр за CurrencyCode
            if (!string.IsNullOrEmpty(currencyCode))
            {
                query = query.Where(ft => ft.CurrencyCode == currencyCode);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }

    }
}
