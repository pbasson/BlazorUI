namespace Blazor.UI.Components.Pages;

public partial class UserPage
{
    [Inject] 
    UserService _services { get; set; } = default!;

    private UserSettings DataSource { get; set; } = new();
    private int randomInt = 0;
    private bool CheckIdInList(int id) 
    {
        return !DataSource.DataSet.Select(x => x.Id).Contains(id) ;
    }

    private int GetRandomId() {
        return Random.Shared.Next(1, DataSource.DataSet.Count()); 
    }
    private int GetRandomValue(int num) {
        return Random.Shared.Next(num); 
    }

    private void SetRandomId() {
        do {
            randomInt = GetRandomId();
        } while (CheckIdInList(randomInt) );  
    }

    protected override async Task OnInitializedAsync() {

        var result = await _services.GetAllAsync();
        DataSource.DataSet = result.Records ?? [];

        if(DataSource != null && DataSource.DataSet != null && DataSource.DataSet.Any() )
        {
            DataSource.UnsetLoading();
        }

    }

}