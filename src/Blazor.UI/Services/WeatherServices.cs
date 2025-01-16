using Blazor.Core.Constants;
using Blazor.Core.Models.Entities;

namespace Blazor.UI.Services
{
    public class WeatherServices
    {
        public async Task<List<WeatherForecast>> GetWeatherForecastAsync(List<WeatherForecast> datasource)
        {
            try
            {
                var weatherForecasts = new List<WeatherForecast>();
                weatherForecasts = SetWeatherForecast(datasource);

                return weatherForecasts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WeatherForecast> SetWeatherForecast(List<WeatherForecast>? forecasts = null )
        {
            var start = 1;
            var end = 5;

            if (forecasts != null && forecasts.Any() ) 
            {
                start += forecasts.Count;
                end += forecasts.Count;
            }

            return Enumerable.Range(start, end).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.Date.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                WeatherSummary = WeatherStatics.WeatherRange[Random.Shared.Next(WeatherStatics.WeatherRange.Count)],
            }).ToList();
        }
    }
}
