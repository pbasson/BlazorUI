namespace Blazor.Core.Models.DTOs;

public class BaseDTO
{
    public DateTime CreatedDateTime { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime UpdatedDateTime { get; set; }
    public string? UpdatedBy { get; set; }
}
