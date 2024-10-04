using Blazor.UI.Helpers;

namespace Blazor.UI.Models;

public class WeatherPageVM
{
    public bool Loading = true;
    public List<WeatherForecast> WeatherList { get; set; } = new();

    public void SetLoading()
    {
        Loading = true;
    } 

    public void UnsetLoading()
    {
        Loading = false;
    } 

    public void ResetList()
    {
        WeatherList = new();
    }

    public void ResetData()
    {
        SetLoading();
        ResetList();
        UnsetLoading();
    }

    public int MinWeather()
    {
        if (WeatherList.Count > 0)
        {
            return WeatherList.Select(x => x.TemperatureC).Min();
        }
        return 0;
    } 

    public int MaxWeather()
    {
        if (WeatherList.Count > 0)
        {
            return WeatherList.Select(x => x.TemperatureC).Max();
        }
        return 0;
    } 

    public double AvgWeather()
    {
        if (WeatherList.Count > 0)
        {
            return Math.Round( WeatherList.Select(x => x.TemperatureC).Average(), 2 );
        }
        return 0;
    } 

    public string GetSummaryDisplay()
    {
        if(WeatherList.Count > 0)   
        {
            var getSummaryType = WeatherList.Select(x => x.WeatherSummary.Type).ToList();
            var getGroupSummary = getSummaryType.GroupBy(x => x)
                .Select(x => new { Element = x.Key, Counter = x.Count() } )
                .OrderByDescending( x => x.Counter).ToList();

            // getGroupSummary.ForEach( x => {
            //     Console.WriteLine($"{x.Element} {x.Counter}");
            // } );

            var getWeatherType = WeatherStatics.GetWeatherType(getGroupSummary[0].Element);
            var test = $"{getWeatherType.Icon} {getWeatherType.Name}: {getGroupSummary[0].Counter} Days";
            
            var test1 = $"  {test}";
            return test1; 
            
        }

        return string.Empty;
    }
 
}
