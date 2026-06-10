namespace Blazor.UI.Components.Features.UserComponents;

public partial class UserPage
{
    [Inject] 
    UserService _services { get; set; } = default!;

    [Inject]
    ToastService ToastService { get; set; } = default!;

    private UserSettings DataSource { get; set; } = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) { return; }

        ToastService.Notify(new(ToastType.Info, "Loading users..."));
        DataSource.Load();
        var result = await _services.GetAllAsync();
        DataSource.DataSet = result.Records ?? [];
        DataSource.Unload();

        ToastService.Notify(new(DataSource.HasRecords ? ToastType.Success : ToastType.Warning, 
            DataSource.HasRecords ? "Users loaded." : "No users found."));

        StateHasChanged();

    }

}
