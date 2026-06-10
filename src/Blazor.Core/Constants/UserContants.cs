namespace Blazor.Core.Constants;

public readonly struct UserContants
{
}

public readonly struct UserNavigationContants
{
    public const string Module = "user";
    public const string parameter = "{0}";

    public const string GetAllRecords = $"{Module}";
    public const string GetRecordById = $"{Module}/{parameter}";
    public const string GetByName = $"{Module}/by-username/{parameter}";
    public const string CreateRecord = $"{Module}/create";
    public const string UpdateRecord = $"{Module}/update";
    public const string DeleteRecord = $"{Module}/delete";
}