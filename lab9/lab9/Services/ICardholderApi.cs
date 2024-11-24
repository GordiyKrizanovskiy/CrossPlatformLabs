using Refit;
using Lab9.Models;

namespace Lab9.Services;

public interface ICardholderApi
{
    [Get("/api/cardholders")]
    Task<List<Cardholder>> GetCardholdersAsync();

    [Get("/api/cardholders/{id}")]
    Task<Cardholder> GetCardholderByIdAsync(int id);

    [Post("/api/cardholders")]
    Task CreateCardholderAsync([Body] Cardholder cardholder);
}
