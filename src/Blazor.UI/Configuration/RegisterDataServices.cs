namespace Blazor.UI.Configuration;

public static class RegisterDataServices
{
    public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<DialogService>();

        services.AddScoped<WeatherServices>();
        services.AddScoped<UserService>();
        return services;
    }
}
