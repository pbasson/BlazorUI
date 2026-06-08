using Blazor.Core.Models.DTOs.User;

namespace Blazor.UI.Components.Features.UserComponents;

public partial class UserDialog
{
    [Parameter] 
    public UserDTO Data {get; set;} = default!;
    [Inject]
    UserService service {get; set;} = default!;
    [Inject]
    ToastService toastService { get; set; } = default!;
    private string _originalUsername = string.Empty;
    private string _usernameValidationMessage = string.Empty;
    private bool _usernameExists;
    private bool _usernameSame {get => Data.Id > 0 && string.Equals(Data.UserName, _originalUsername, StringComparison.OrdinalIgnoreCase);}
    private bool _isCheckingUsername;
    private Radzen.Blazor.RadzenTemplateForm<UserDTO>? _userForm;
    string Title {get => (Data.Id == 0) ? "Add" : "Edit"; }
    private bool ShowUsernameAvailableMessage => !string.IsNullOrEmpty(_usernameValidationMessage) && !_usernameExists;
    private bool CanSubmit
    {
        get
        {
            bool checkSubmit = _isCheckingUsername || Data == null || string.IsNullOrWhiteSpace(Data.UserName) || _usernameSame ;
            if (checkSubmit) { return false; }
            return !string.IsNullOrEmpty(_usernameValidationMessage) && !_usernameExists;
        }
    }

    protected override void OnParametersSet()
    {
        _originalUsername = Data?.UserName ?? string.Empty;
    }

    DateTime? DateOfBirthValue
    {
        get => Data.DateOfBirth?.ToDateTime(TimeOnly.MinValue);
        set
        {
            Data.DateOfBirth = value.HasValue ? DateOnly.FromDateTime(value.Value) : null;
        }
    }

    private bool ValidateUsernameAvailability()
    {
        return !_usernameExists;
    }

    private string GetUsernameInputClass()
    {
        if (string.IsNullOrEmpty(_usernameValidationMessage))
        {
            return "input-form";
        }

        return _usernameExists
            ? "input-form username-input-error"
            : "input-form username-input-ok";
    }

    async Task SubmitForm(UserDTO value) 
    {
        if(Data != null && !string.IsNullOrEmpty(Data.UserName))
        { 
            var checkUpdate = Data.Id > 0;
            var updateMessage = checkUpdate ? "Updated" : "Created";

            var usernameExists = await CheckUsername();
            if(usernameExists)
            {
                toastService.Notify(new(ToastType.Warning, $"User: {Data.UserName} currently exists"));
                return; 
            }
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

    private async Task<bool> CheckUsername()
    {
        _usernameValidationMessage = string.Empty;
        _usernameExists = false;

        if(Data == null || string.IsNullOrWhiteSpace(Data.UserName) || _usernameSame)
        {
            return false;
        }

        _isCheckingUsername = true;
        var result = await service.GetByNameAsync(Data.UserName);
        _isCheckingUsername = false;

        _usernameExists = result != null && result.Record != null && !string.IsNullOrEmpty(result?.Record?.UserName);
        _usernameValidationMessage = _usernameExists
            ? $"Username '{Data.UserName}' already exists."
            : $"Username '{Data.UserName}' is available.";

        return _usernameExists;
    }

    public async Task HandleUsername()
    {
        await CheckUsername();
        _userForm?.EditContext?.Validate();
    }
}
