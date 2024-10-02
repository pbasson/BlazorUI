
using Blazor.UI.Models;

namespace Blazor.UI.Services
{
    public class WeatherServices
    {
        public async Task<List<WeatherForecast>> GetWeatherForecastAsync()
        {
            try
            {
                var weatherForecasts = new List<WeatherForecast>();
                weatherForecasts = GetWeatherForecasts();

                return weatherForecasts;

            }
            catch (Exception)
            {
                throw;
            }

        }

        private List<WeatherForecast> GetWeatherForecasts()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);

            var weatherList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherSummary[Random.Shared.Next(WeatherSummary.Length)]
            }).ToList();

            return weatherList;
        }
        private readonly string[] WeatherSummary = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
    }
}
