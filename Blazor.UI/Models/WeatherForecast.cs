namespace Blazor.UI.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public string? DateDisplay => Date.ToString("dd-MM-yyyy");    
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
