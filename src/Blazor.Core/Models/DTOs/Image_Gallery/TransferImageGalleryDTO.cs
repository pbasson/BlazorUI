namespace Blazor.Core.Models.DTOs.Image_Gallery;

public class TransferImageGalleryDTO : BaseTransfer
{
    public ImageGalleryDTO? Record { get; set; }

    public TransferImageGalleryDTO(ActionStatusType statusType, ImageGalleryDTO? record = null)
    {
        ActionStatusType = statusType;
        Record = record;
    }
}

public class TransferImageGalleryGridDTO : BaseTransfer
{
    public List<ImageGalleryDTO>? Records { get; set; }

    public TransferImageGalleryGridDTO(ActionStatusType statusType, List<ImageGalleryDTO>? records = null)
    {
        ActionStatusType = statusType;
        Records = records;
    }
}
