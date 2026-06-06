namespace Blazor.Core.Models.Settings;

public class WeatherSettings : HeaderListSettings<WeatherForecast>
{
    public override string Title { get; set; } = @PageStatics.WeatherPage;
    
    public int MinWeather()
    {
        if (DataSet.Count > 0)
        {
            return DataSet.Select(x => x.TemperatureC).Min();
        }
        return 0;
    } 

    public int MaxWeather()
    {
        if (DataSet.Count > 0)
        {
            return DataSet.Select(x => x.TemperatureC).Max();
        }
        return 0;
    } 

    public double AvgWeather()
    {
        if (DataSet.Count > 0)
        {
            return Math.Round( DataSet.Select(x => x.TemperatureC).Average(), 2 );
        }
        return 0;
    } 

    public string GetSummaryDisplay()
    {
        if(DataSet.Count > 0)   
        {
            var getSummaryType = DataSet.Select(x => x.WeatherSummary.Type).ToList();
            var getGroupSummary = getSummaryType.GroupBy(x => x)
                .Select(x => new { Element = x.Key, Counter = x.Count() } )
                .OrderByDescending( x => x.Counter).ToList();

            var getWeatherType = WeatherStatics.GetWeatherType(getGroupSummary[0].Element);
            var summary = $"{getWeatherType.Icon} {getWeatherType.Name}: {getGroupSummary[0].Counter} Days";
            
            return $"  {summary}";
        }

        return string.Empty;
    }
}
