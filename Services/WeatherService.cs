using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "07c786290b3a3387c0577978a54ca98c";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherModel> GetWeatherAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";
            var result = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(url);

            if (result != null)
            {
                return new WeatherModel
                {
                    City = result.Name,
                    Description = result.Weather[0].Description,
                    Temperature = result.Main.Temp,
                    Humidity = result.Main.Humidity,
                    WindSpeed = result.Wind.Speed,
                    FetchedAt = DateTime.Now
                };
            }

            return null;
        }

        private class OpenWeatherResponse
        {
            public string Name { get; set; }
            public MainInfo Main { get; set; }

            public WindInfo Wind { get; set; }
            public List<WeatherDescription> Weather { get; set; }

            public class MainInfo { public double Temp { get; set; } public int Humidity { get; set; } }

            public class WindInfo { public float Speed { get; set; } }

            public class WeatherDescription { public string Description { get; set; } }
        }
    }
}
