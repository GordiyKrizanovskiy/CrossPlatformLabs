using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class BanksController : Controller
    {
        private readonly HttpClient _httpClient;

        public BanksController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5211/api/banks");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic banks = JsonConvert.DeserializeObject<dynamic>(json);

            return View(banks);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5211/api/banks/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic bank = JsonConvert.DeserializeObject<dynamic>(json);

            return View(bank);
        }
    }
}
