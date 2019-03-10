using System;
using WeatherApp.Controllers;
using WeatherApp.Services;
using WeatherApp.Tests.Mock;
using Xunit;

namespace WeatherApp.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void CanExecuteIndex()
        {
            var weatherProvider = new OpenWeatherMap(Configuration.Default());
            var controller = new WeatherController(weatherProvider);
            var result = controller.Index();

            Assert.NotNull(result);
        }
    }
}
