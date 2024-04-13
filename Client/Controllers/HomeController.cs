using Client.Models;
using Client.Services.Interface;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, ITokenService itokenService)
        {
            _logger = logger;
            _tokenService = itokenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Weather()
        {
            var data = new List<WeatherModel>();
            var token = await _tokenService.GetToken("myApi.read");
            using (var client = new HttpClient())
            {
                client.SetBearerToken(token.AccessToken);
                var result = await client.GetAsync("http://localhost:5230/WeatherForecast");
                if (result.IsSuccessStatusCode)
                {
                    var model = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<WeatherModel>>(model);
                    return View(data);
                }
                else
                {
                    throw new Exception("Failed to get Data from API");
                }
            }
        }
    }
}