namespace Blazor.Core.Models.Settings;

public class HeaderSettings
{
    public bool Loading = true;

    public virtual string PageTitle { get; set; } = string.Empty;
    public virtual string Title { get; set; } = string.Empty;

    public void Load()
    {
        Loading = true;
    } 

    public void Unload()
    {
        Loading = false;
    } 
}

public class HeaderListSettings<T> : HeaderSettings where T : IEntity
{
    public List<T> DataSet { get; set; } = default!;

    public void ResetData()
    {
        DataSet = [];
    }

    public void ReloadData()
    {
        Load();
        ResetData();
        Unload();
    }
}

