using Refit;
using Lab9.Models;

namespace Lab9.Services;

public interface IBankApi
{
    [Get("/api/banks")]
    Task<List<Bank>> GetBanksAsync();

    [Get("/api/banks/{id}")]
    Task<Bank> GetBankByIdAsync(int id);

    [Post("/api/banks")]
    Task CreateBankAsync([Body] Bank bank);
}
