using Blazor.Core.Models.Entities;

namespace Blazor.Core.Models.Settings;

public class TransactionSettings : HeaderSettings
{
    public List<CRUDTransactionDTO> DataSet { get; set; } = new();
    public CRUDTransactionDTO DataRecord { get; set; } = new();

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
