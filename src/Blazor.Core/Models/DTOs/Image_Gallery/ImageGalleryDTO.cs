namespace Blazor.Core.Models.DTOs.Image_Gallery;

public class ImageGalleryDTO : BaseDTO 
{
    public int ImageGalleryId { get; set; }
    public string? GalleryName { get; set; }
    public string? GalleryPath { get; set; }
    public List<ImageFileDTO>? ImageFile { get; set; } 
}

public class ImageFileDTO 
{
    public int ImageFileId { get; set; }
    public int ImageGalleryId { get; set; }
    public string? ImageName { get; set; }
    public int ImagePosition { get; set; }
}

public class CreateImageGalleryDTO 
{
    public string? GalleryName { get; set; }
    public string? GalleryPath { get; set; }
    public List<CreateImageFileDTO>? ImageFile { get; set; } 
}

public class CreateImageFileDTO 
{
    public string? ImageName { get; set; }
    public int ImagePosition { get; set; }
}

public class UpdateImageGalleryDTO  
{
    public int ImageGalleryId { get; set; }
    public string? GalleryName { get; set; }
    public string? GalleryPath { get; set; }
    public List<ImageFileDTO>? ImageFile { get; set; } 
}
