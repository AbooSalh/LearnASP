using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> cityWeathers =
            [
                new CityWeather
                {
                    CityUniqueCode = "NYC",
                    CityName = "New York City",
                    DateAndTime = DateTime.Now,
                    TemperatureFahrenheit = 75
                },
                new CityWeather
                {
                    CityUniqueCode = "LA",
                    CityName = "Los Angeles",
                    DateAndTime = DateTime.Now,
                    TemperatureFahrenheit = 85
                },
                new CityWeather
                {
                    CityUniqueCode = "CHI",
                    CityName = "Chicago",
                    DateAndTime = DateTime.Now,
                    TemperatureFahrenheit = 70
                }
            ];


        [Route("/")]
        public IActionResult Index()
        {
            return View("Index", cityWeathers);
        }

        [Route("weather/{cityCode}")]
        public IActionResult Weather(string cityCode)
        {
            var cityWeather = cityWeathers.FirstOrDefault(c => c.CityUniqueCode == cityCode);
            if (cityWeather == null)
            {
                return NotFound();
            }

            return View(cityWeather);
        }
    }
}
