namespace Blazor.UI.Configuration;

public static class RegisterDataServices
{
    public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<DialogService>();

        services.AddScoped<ImageGalleryService>();
        services.AddScoped<UserService>();
        services.AddScoped<WeatherService>();
        return services;
    }
}
