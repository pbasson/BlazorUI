namespace Blazor.UI.Components.Features.ImageGalleryComponents;

public partial class ImageGalleryGrid
{
    [Parameter] 
    public List<ImageGalleryDTO>? DataSet {get; set;}
    [Inject]
    UserService Service {get; set;} = default!;
    private const int ItemsPerRow = 5;
    private const int RowsPerPage = 4;

    private IEnumerable<ImageGalleryRow> GalleryRows => 
        DataSet?.Chunk(ItemsPerRow).Select(items => new ImageGalleryRow(items)) ?? [];

    private sealed record ImageGalleryRow(ImageGalleryDTO[] Items);
}
