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

public class ImageGalleryTransferGridDTO : BaseTransfer
{
    public List<ImageGalleryDTO>? Records { get; set; }

    public ImageGalleryTransferGridDTO(ActionStatusType statusType, List<ImageGalleryDTO>? records = null)
    {
        ActionStatusType = statusType;
        Records = records;
    }
}
