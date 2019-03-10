using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<string> GetWeatherJson(string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={key}&units=metric");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
        }
    }
}

