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
            Console.WriteLine("GetSummaryDisplay");
            var test1 = WeatherList.Select(x => x.WeatherSummary.Type).ToList();
            var test2 = test1.Max();

            Console.WriteLine($"{test1.Count} {test2}");
            var test = WeatherList.GroupBy(x => x).Where(y => y.Count() > 1).Select(x =>x.Key).ToList();    
            test.ForEach(x =>
            {
                Console.WriteLine($"{x.Date}: {x.TemperatureC}:  " );
                // Console.WriteLine($"{x.Key.DateDisplay}: {x.Key.TemperatureC}" );
            } );
            
        }

        return string.Empty;
    }

 
}
