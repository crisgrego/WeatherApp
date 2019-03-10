using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherViewModel
    {
        public string Location { get; set; }
        public string IconCode { get; set; }
        public string Description { get; set; }
        public double TempCurrent { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }

    }
}
