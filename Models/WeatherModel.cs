using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{

    //  Represents the weather data for a given city.
    // This model contains details such as temperature, humidity, weather condition, and wind speed.
    public class WeatherModel
    {
        public float Temperature { get; set; }

        public int Humidity { get; set; }

        public string Condition { get; set; }

        public float WindSpeed { get; set; }

        public float pressure { get; set; }

        public DateTime ReportTime { get; set; }
    }
}
