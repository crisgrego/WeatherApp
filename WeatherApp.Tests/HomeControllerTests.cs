using System;
using WeatherApp.Controllers;
using Xunit;

namespace WeatherApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void CanExecuteIndex()
        {
            var controller = new HomeController();
            var result = controller.Index();

            Assert.NotNull(result);
        }
    }
}
