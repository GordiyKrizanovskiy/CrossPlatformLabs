using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class FinancialTransactionsController : Controller
    {
        private readonly HttpClient _httpClient;

        public FinancialTransactionsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5211/api/financialtransactions");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic transactions = JsonConvert.DeserializeObject<dynamic>(json);

            return View(transactions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5211/api/financialtransactions/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic transaction = JsonConvert.DeserializeObject<dynamic>(json);

            return View(transaction);
        }

        public async Task<IActionResult> Search([FromQuery] string? merchantId, [FromQuery] string? currencyCode)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(merchantId))
                queryParams.Add($"merchantId={merchantId}");

            if (!string.IsNullOrEmpty(currencyCode))
                queryParams.Add($"currencyCode={currencyCode}");

            var queryString = string.Join("&", queryParams);

            var response = await _httpClient.GetAsync($"http://localhost:5211/api/financialtransactions/search?{queryString}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);

            return View(results);
        }

    }
}
