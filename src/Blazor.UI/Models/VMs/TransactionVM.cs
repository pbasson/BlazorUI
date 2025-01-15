using Blazor.UI.Models.Entities;

namespace Blazor.UI.Models.VMs;

public class TransactionVM
{
    public List<CRUDTransaction> DataSource { get; set; } = new();
}
