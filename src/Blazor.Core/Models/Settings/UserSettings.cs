namespace Blazor.Core.Models.Settings;

public class UserSettings : HeaderListSettings<UserDTO>
{
    public override string Title { get; set; } = "Users Page";
    public override int PageSize { get; set; } = 20;
}
