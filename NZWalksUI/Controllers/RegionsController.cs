using Microsoft.AspNetCore.Mvc;
using NZWalksUI.Models;
using NZWalksUI.Models.DTO;
using System.Net.Http;
using System.Reflection;
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<RegionsDto>($"https://localhost:7160/api/regions/{id.ToString()}");

            if(response != null)
            {
                return View(response);
            }

            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionsDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7160/api/regions/{request.Id}");
                httpRequest.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                var httpResponse = await client.SendAsync(httpRequest);
                httpResponse.EnsureSuccessStatusCode();

                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                var response = await JsonSerializer.DeserializeAsync<RegionsDto>(responseStream);

                if (response != null)
                {
                    return RedirectToAction("Index", "Regions");
                }
                else
                {
                    return View();
                }
            }
            catch (HttpRequestException ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete (RegionsDto request)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"https://localhost:7160/api/regions/{request.Id}");

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Regions");

        }

    }


}
 
