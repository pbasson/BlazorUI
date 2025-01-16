using Blazor.Core.Models.Entities;

namespace Blazor.Core.Models.VMs;

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
