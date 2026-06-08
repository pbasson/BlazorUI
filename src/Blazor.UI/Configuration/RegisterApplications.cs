namespace Blazor.UI.Configuration;

public static class RegisterApplications
{
    public static void RegisterApplication(this WebApplication app)
    {
        // if (!app.Environment.IsDevelopment())
        // {
        //     app.UseExceptionHandler("/Error", createScopeForErrors: true);
        //     app.UseHsts();
        // }

        // app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
    }
}
