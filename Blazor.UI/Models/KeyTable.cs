
namespace Blazor.UI.Models;

public class KeyTable
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class KeyTypeTable : KeyTable
{
    public int Type { get; set; }
}

public class KeyIconTable : KeyTable
{
    public string? Icon { get; set; }
}