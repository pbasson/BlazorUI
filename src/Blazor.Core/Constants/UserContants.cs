namespace Blazor.Core.Constants;

public readonly struct UserContants
{
}

public readonly struct UserNavigationContants
{
    public readonly static string Module = "user";
    public readonly static string parameter = "{0}";

    public readonly static string GetAllRecords = $"{Module}";
    public readonly static string GetRecordById = $"{Module}/{parameter}";
    public readonly static string GetByName = $"{Module}/by-username/{parameter}";
    public readonly static string CreateRecord = $"{Module}/create";
    public readonly static string UpdateRecord = $"{Module}/update";
    public readonly static string DeleteRecord = $"{Module}/delete";
}