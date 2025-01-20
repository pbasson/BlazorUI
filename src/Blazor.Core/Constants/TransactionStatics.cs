namespace Blazor.Core.Constants;

public readonly struct TransactionStatics
{
}

public readonly struct TransactionNavigation
{
    public readonly static string Module = "CRUDTransaction";
    public readonly static string parameter = "{0}";

    public readonly static string GetAllRecords = $"{Module}/GetAllRecords";
    public readonly static string GetRecordById = $"{Module}/GetRecordById/{parameter}";
    public readonly static string CreateRecord = $"{Module}/CreateRecord/";
    public readonly static string UpdateRecord = $"{Module}/UpdateRecord/";
    public readonly static string DeleteRecord = $"{Module}/DeleteRecord";
}