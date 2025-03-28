using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace WeatherApp.Models
{
    // Represents a city with details such as its name and country code.
    // This class is useful for storing city-specific information when searching for weather data.
    public class CityModel
    {
        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public string Region { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int Population { get; set; }
    }
}
