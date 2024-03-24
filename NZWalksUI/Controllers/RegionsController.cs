using Microsoft.AspNetCore.Mvc;
using NZWalksUI.Models;
using NZWalksUI.Models.DTO;
using System.Text;
using System.Text.Json;

namespace NZWalksUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionsDto> response = new List<RegionsDto>();
            var client = httpClientFactory.CreateClient();

            var httpResponseMessage = await client.GetAsync("https://localhost:7160/api/regions");

            httpResponseMessage.EnsureSuccessStatusCode();

            response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionsDto>>());

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionsViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequistMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7160/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json"),
            };

            var httpResponseMessage = await client.SendAsync(httpRequistMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionsDto>();

            if (response != null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

    }
}
 
