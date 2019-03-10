using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    interface IWeatherProvider
    {
        Task<string> GetWeatherJson(string city);
    }
}
