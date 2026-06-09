namespace Blazor.Core.Settings.Image_Gallery;

public class ImageGallerySettings : HeaderListSettings<ImageGalleryDTO>
{
    public override string Title { get; set; } = "ImageGallery Page";
    public override int PageSize { get; set; } = 10;
}