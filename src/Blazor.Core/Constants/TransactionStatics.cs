namespace Blazor.Core.Constants;

public readonly struct TransactionStatics
{
}

public readonly struct TransactionNavigation
{
    public readonly static string Module = "User";
    public readonly static string parameter = "{0}";

    public readonly static string GetAllRecords = $"{Module}";
    public readonly static string GetRecordById = $"{Module}/{parameter}";
    public readonly static string CreateRecord = $"{Module}/create";
    public readonly static string UpdateRecord = $"{Module}/update";
    public readonly static string DeleteRecord = $"{Module}/delete";
}