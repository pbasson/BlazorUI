namespace Blazor.Core.Settings.Module;

public class WeatherSettings : HeaderListSettings<WeatherForecast>
{
    public override string Title { get; set; } = WeatherConstants.WeatherPage;

    public int MinWeather() => DataSet.Count > 0 ? DataSet.Min(x => x.TemperatureC) : 0;

    public int MaxWeather() => DataSet.Count > 0 ? DataSet.Max(x => x.TemperatureC) : 0;

    public double AvgWeather() =>
        DataSet.Count > 0 ? Math.Round(DataSet.Average(x => x.TemperatureC), 2) : 0;

    public string GetSummaryDisplay()
    {
        if(DataSet.Count > 0)   
        {
            var getSummaryType = DataSet.Select(x => x.WeatherSummary.Type).ToList();
            var getGroupSummary = getSummaryType.GroupBy(x => x)
                .Select(x => new { Element = x.Key, Counter = x.Count() } )
                .OrderByDescending( x => x.Counter).ToList();

            var getWeatherType = WeatherConstants.GetWeatherType(getGroupSummary[0].Element);
            var summary = $"{getWeatherType.Icon} {getWeatherType.Name}: {getGroupSummary[0].Counter} Days";
            
            return $"  {summary}";
        }

        return string.Empty;
    }
}
