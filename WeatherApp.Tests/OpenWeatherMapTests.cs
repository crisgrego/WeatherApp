using System;
using WeatherApp.Controllers;
using WeatherApp.Services;
using WeatherApp.Tests.Mock;
using Xunit;
using WeatherApp.Tests.Data;

namespace WeatherApp.Tests
{
    public class OpenWeatherMapTests
    {
        [Theory]
        [ClassData(typeof(CitiesDataGenerator))]
        public void CanObtainWeatherInfo(string city)
        {
            var openWeather = new OpenWeatherMap(Configuration.Default());

            var result = openWeather.GetWeather(city);

            Assert.NotNull(result);
        }
    }
}
