namespace Blazor.Core.Models.Settings;

public class HeaderSettings
{
    public bool Loading = true;

    public void SetLoading()
    {
        Loading = true;
    } 

    public void UnsetLoading()
    {
        Loading = false;
    } 
}

public class HeaderListSettings<T> : HeaderSettings where T : IEntity
{
    public List<T> DataSet { get; set; } = default!;

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

