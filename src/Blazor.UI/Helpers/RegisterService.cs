using Blazor.UI.Components;
using Blazor.UI.Services;

namespace Blazor.UI.Helpers
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddRazorComponents().AddInteractiveServerComponents();
            RegisterCoreServices(services);
            
            services.AddHttpClient();
            return services;
        }

        private static void RegisterCoreServices(IServiceCollection services)
        {
            services.AddScoped<WeatherServices>();
            services.AddScoped<TransactionService>();
        }

        public static void RegisterApplication(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            // if (!app.Environment.IsDevelopment())
            // {
            //     app.UseExceptionHandler("/Error", createScopeForErrors: true);
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            // app.UseElmah();

        }
    }
}