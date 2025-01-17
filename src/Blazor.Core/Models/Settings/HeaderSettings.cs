namespace Blazor.Core.Models.Settings;

public class HeaderSettings
{
    public bool Loading = true;
    // public List<object> DataSource { get; set; } = default!;

    public void SetLoading()
    {
        Loading = true;
    } 

    public void UnsetLoading()
    {
        Loading = false;
    } 

    // public void ResetList()
    // {
    //     DataSource = new();
    // }

    // public void ResetData()
    // {
    //     SetLoading();
    //     ResetList();
    //     UnsetLoading();
    // }

}
