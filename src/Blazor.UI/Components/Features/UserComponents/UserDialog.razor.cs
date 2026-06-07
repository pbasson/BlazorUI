namespace Blazor.UI.Components.Features.UserComponents;

public partial class UserDialog
{
     [Parameter] 
    public UserDTO Data {get; set;} = default!;
    [Inject] 
    UserService service {get; set;} = default!;
    [Inject]
    ToastService toastService { get; set; } = default!;

    string Title {get => (Data.Id == 0) ? "Add" : "Edit"; }

    DateTime? DateOfBirthValue
    {
        get => Data.DateOfBirth?.ToDateTime(TimeOnly.MinValue);
        set
        {
            Data.DateOfBirth = value.HasValue ? DateOnly.FromDateTime(value.Value) : null;
        }
    }

    async Task SubmitForm() 
    {
        if(Data != null && !string.IsNullOrEmpty(Data.UserName))
        { 
            var checkUpdate = Data.Id > 0;
            var updateMessage = checkUpdate ? "Updated" : "Created";
            var result = (checkUpdate) ? await service.UpdateAsync(Data): await service.CreateAsync(Data);
            if(result != null && result.Success)
            {
                toastService.Notify(new(ToastType.Success, $"User: Has Been {updateMessage}"));
            }
            else {
                toastService.Notify(new(ToastType.Warning, $"User: Could Not Be {updateMessage}"));
            }
        }  

        dialogService.Close(true);
    }
}