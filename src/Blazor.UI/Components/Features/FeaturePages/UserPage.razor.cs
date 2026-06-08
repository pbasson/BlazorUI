namespace Blazor.UI.Components.Features.FeaturePages;

public partial class UserPage
{
    [Inject] 
    UserService _services { get; set; } = default!;

    [Inject]
    ToastService ToastService { get; set; } = default!;

    private UserSettings DataSource { get; set; } = new();
    private int randomInt = 0;
    private bool _hasUserData;
    private bool CheckIdInList(int id) 
    {
        return DataSource!.DataSet.Select(x => x.Id).Contains(id) ;
    }

    private int GetRandomId() 
    {
        return Random.Shared.Next(1, DataSource.DataSet.Count()); 
    }

    private int GetRandomValue(int num) 
    {
        return Random.Shared.Next(num); 
    }

    private void SetRandomId() 
    {
        do 
        {
            randomInt = GetRandomId();
        } while (CheckIdInList(randomInt) );  
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        ToastService.Notify(new(ToastType.Info, "Loading users..."));
        DataSource.Load();
        await Task.Delay(4000);
        // StateHasChanged();
        var result = await _services.GetAllAsync();
        DataSource.DataSet = result.Records ?? [];
        _hasUserData = DataSource.DataSet.Any();

        DataSource.Unload();

        ToastService.Notify(new(_hasUserData ? ToastType.Success : ToastType.Warning, 
            _hasUserData ? "Users loaded." : "No users found."));

        StateHasChanged();

    }

}
