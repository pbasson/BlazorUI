namespace Blazor.UI.Components.Features.UserComponents;

public partial class UserGrid
{
    [Parameter] 
    public List<UserDTO>? DataSet {get; set;}
    [Inject]
    UserService Service {get; set;} = default!;
    string NoDataset = "No DataSet is Available";

    private async Task AddRecord(MouseEventArgs args) 
    {
        await DialogService.OpenAsync<UserDialog>( "Add", new Dictionary<string, object> { { "Data", new UserDTO() } }, SetOption() );   
        await UpdateGetAll();
    }

    private async Task EditRecord(MouseEventArgs args, UserDTO dTO) 
    {
        await DialogService.OpenAsync<UserDialog>( "Edit", new Dictionary<string, object> { { "Data", dTO } }, SetOption() );        
        await UpdateGetAll();
    }

    private async Task ConfirmButton(MouseEventArgs args, int id) {
        var getConfirm = await DialogService.Confirm($"{ConfirmConstants.Delete}", "MyTitle", 
            new ConfirmOptions() { OkButtonText = $"{ConfirmConstants.Yes}", CancelButtonText = $"{ConfirmConstants.Cancel}" });

        if(getConfirm != null && (bool)getConfirm) 
        {
            var deleted = await Service.DeleteAsync(id); 
            if (deleted)
            {
                toastService.Notify(new(ToastType.Success, "User deleted successfully."));
                await UpdateGetAll();
                return;
            }

            toastService.Notify(new(ToastType.Warning, "User could not be deleted."));
        }
    }

    private async Task UpdateGetAll()
    {
        var result = await Service.GetAllAsync();
        DataSet = result.Records;
    }


    DialogOptions SetOption() => new DialogOptions
    {
        Width = "min(700px, calc(100vw - 2rem))",
        Height = "auto",
    };
}    