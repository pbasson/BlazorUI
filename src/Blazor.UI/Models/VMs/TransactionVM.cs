using Blazor.UI.Models.Entities;

namespace Blazor.UI.Models.VMs;

public class TransactionVM : HeaderVM
{
    public List<CRUDTransaction> DataSet { get; set; } = new();

    public void ResetList()
    {
        DataSet = new();
    }

    public void ResetData()
    {
        SetLoading();
        ResetList();
        UnsetLoading();
    }


}
