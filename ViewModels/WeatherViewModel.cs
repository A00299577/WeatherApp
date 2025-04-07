using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public partial class WeatherViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;
    private readonly WeatherDatabase _weatherDatabase;

    [ObservableProperty] private string city;
    [ObservableProperty] private WeatherModel weather;

    public ICommand FetchWeatherCommand { get; }

    public WeatherViewModel()
    {
        _weatherService = new WeatherService();
        _weatherDatabase = new WeatherDatabase(Path.Combine(FileSystem.AppDataDirectory, "weather.db3"));

        FetchWeatherCommand = new AsyncRelayCommand(FetchWeatherAsync);
    }

    private async Task FetchWeatherAsync()
    {
        if (!string.IsNullOrWhiteSpace(City))
        {
            Weather = await _weatherService.GetWeatherAsync(City);
            if (Weather != null)
                await _weatherDatabase.SaveWeatherAsync(Weather);
        }
    }
}
