namespace Blazor.Core.Constants;

public readonly struct ImageGalleryNavigation
{
    public readonly static string Module = "user";
    public readonly static string parameter = "{0}";

    public readonly static string GetAllRecords = $"{Module}";
    public readonly static string GetRecordsByPaginationAsync = $"{Module}/by-page/{parameter}";
    public readonly static string GetRecordById = $"{Module}/{parameter}";
    public readonly static string CreateRecord = $"{Module}/create";
    public readonly static string UpdateRecord = $"{Module}/update";
}