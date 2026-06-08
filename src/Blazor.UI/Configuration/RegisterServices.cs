namespace Blazor.UI.Configuration;

public static class RegisterServices
{
    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddRazorComponents().AddInteractiveServerComponents();
        services.RegisterCoreServices();
        services.AddHttpClient();
        services.AddRadzenComponents();
        services.AddBlazorBootstrap();

        return services;
    }
}
