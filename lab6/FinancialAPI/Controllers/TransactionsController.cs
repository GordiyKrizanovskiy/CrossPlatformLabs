using Microsoft.AspNetCore.Mvc;
using FinancialAPI.Data;
using FinancialAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly FinancialDbContext _context;

    public TransactionsController(FinancialDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        return await _context.Transactions.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        transaction.TransactionDate = transaction.TransactionDate.ToUniversalTime(); // Переводимо дату до UTC
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTransactions), new { id = transaction.Id }, transaction);
    }
}
