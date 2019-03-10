using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherMap : IWeatherProvider
    {
        readonly string url;
        readonly string key;

        public OpenWeatherMap(IConfiguration conf)
        {
            url = conf["WeatherApis:OpenWeatherMap:Url"];
            key = conf["WeatherApis:OpenWeatherMap:Key"];
        }

        public async Task<WeatherViewModel> GetWeather(string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={key}&units=metric");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return ParseJson(json);
            }
        }

        public WeatherViewModel ParseJson(string cityWeather)
        {
            dynamic city = JObject.Parse(cityWeather);

            return new WeatherViewModel()
            {
                Location = $"{city.name}, {city.sys.country}",
                IconCode = city.weather[0].icon,
                Description = city.weather[0].description,
                TempCurrent = city.main.temp,
                TempMax = city.main.temp_max,
                TempMin = city.main.temp_min,
                Pressure = city.main.pressure,
                Humidity = city.main.humidity,
                Sunrise = city.sys.sunrise,
                Sunset = city.sys.sunset
            };
        }
    }
}

