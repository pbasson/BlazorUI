namespace Blazor.Core.Constants;

public readonly struct ImageGalleryNavigation
{
    public const string Module = "image-gallery";
    public const string parameter = "{0}";

    public const string GetAllRecords = $"{Module}";
    public const string GetRecordsByPaginationAsync = $"{Module}/by-page/{parameter}";
    public const string GetRecordById = $"{Module}/{parameter}";
    public const string CreateRecord = $"{Module}/create";
    public const string UpdateRecord = $"{Module}/update";
}