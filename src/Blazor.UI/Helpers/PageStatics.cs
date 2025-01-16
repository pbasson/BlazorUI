namespace Blazor.UI.Helpers;

public static class PageStatics
{
    public static string WeatherPage { get; set; } = "Weather";

    public static string WeatherPageDetails { get; set; } = "Page Demonstrates Data Loading and Reseting of the Weather."; 

}

public readonly struct PathVariables
{
    public readonly static string Home = "/";
    public readonly static string Weather = "Weather";
    public readonly static string Counter = "Counter";
    public readonly static string Transaction = "Transaction";
}

public readonly struct API_Statics
{
    public readonly static string ApiKey = "X-API-KEY";
    public readonly static string AppSettingsFile = "appsettings.json";
}