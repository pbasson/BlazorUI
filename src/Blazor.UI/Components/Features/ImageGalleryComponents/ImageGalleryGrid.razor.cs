namespace Blazor.UI.Components.Features.ImageGalleryComponents;

public partial class ImageGalleryGrid
{
    [Parameter] 
    public List<ImageGalleryDTO>? DataSet {get; set;}
    [Inject]
    UserService Service {get; set;} = default!;
    readonly string NoDataset = "No DataSet is Available";

}