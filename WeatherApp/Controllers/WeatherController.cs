using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider weatherService;

        public WeatherController(IWeatherProvider weather) => weatherService = weather;

        public IActionResult Index() => View();

        public async Task<IActionResult> Info(WeatherSearchViewModel search)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", search);
            }

            try
            {
                search.Result = await weatherService.GetWeather(search.City);
            }
            catch(HttpRequestException)
            {
                ModelState.AddModelError("City", "Incorrect City");
            }            

            return View("Index", search);
        }
    }
}
