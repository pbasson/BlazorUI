using Blazor.UI.Services.Module;
using Blazor.UI.Services.User;

namespace Blazor.UI.Configuration;

public static class RegisterDataServices
{
    public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<DialogService>();

        services.AddScoped<WeatherService>();
        services.AddScoped<UserService>();
        return services;
    }
}
