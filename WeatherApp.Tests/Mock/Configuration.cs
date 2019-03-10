using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Tests.Mock
{
    class Configuration
    {
        public static IConfiguration Default()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Startup).Assembly)
                .AddEnvironmentVariables();
            return config.Build();
        }
    }
}
