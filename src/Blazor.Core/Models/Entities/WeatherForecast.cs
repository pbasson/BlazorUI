namespace Blazor.Core.Models.Entities;

public class WeatherForecast : IEntity
{
    public DateTime Date { get; set; }
    public string? DateDisplay => Date.ToString("dd-MM-yyyy");    
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public KeyTypeTable WeatherSummary { get; set; } = new();


    public string GetSummaryTableDisplay()
    {
        if(WeatherSummary != null)   
        {
            return $"{WeatherStatics.GetWeatherType(WeatherSummary.Type).Icon} {WeatherSummary.Name}"; 
        }

        return string.Empty;
    }
}
