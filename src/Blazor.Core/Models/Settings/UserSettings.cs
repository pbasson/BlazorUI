namespace Blazor.Core.Models.Settings;

public class UserSettings : HeaderSettings
{
    public List<UserDTO> DataSet { get; set; } = [];
    public UserDTO DataRecord { get; set; } = new();

    public void ResetList()
    {
        DataSet = [];
    }

    public void ResetData()
    {
        SetLoading();
        ResetList();
        UnsetLoading();
    }


}
