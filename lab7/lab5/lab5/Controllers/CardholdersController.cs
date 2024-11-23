using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class CardholdersController : Controller
    {
        private readonly HttpClient _httpClient;

        public CardholdersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5211/api/cardholders");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic cardholders = JsonConvert.DeserializeObject<dynamic>(json);

            return View(cardholders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5211/api/cardholders/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic cardholder = JsonConvert.DeserializeObject<dynamic>(json);

            return View(cardholder);
        }
    }
}
