using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public WeatherDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WeatherModel>().Wait();
        }

        public Task<int> SaveWeatherAsync(WeatherModel weather) => _database.InsertAsync(weather);

        public Task<List<WeatherModel>> GetWeatherHistoryAsync() => _database.Table<WeatherModel>().ToListAsync();
    }
}
