namespace Blazor.UI.Models.Entities;

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