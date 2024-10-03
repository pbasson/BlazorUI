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
}
