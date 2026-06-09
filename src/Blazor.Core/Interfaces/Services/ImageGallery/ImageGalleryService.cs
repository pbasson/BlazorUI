namespace Blazor.Core.Interfaces.Services.ImageGallery;

public interface IImageGalleryService
{
    Task<ImageGalleryTransferGridDTO> GetAllRecordsAsync();
    Task<ImageGalleryTransferGridDTO> GetRecordsByPaginationAsync(int page);
    Task<TransferImageGalleryDTO> GetRecordByIdAsync(int id);
    Task<TransferDTO> CreateRecordAsync(CreateImageGalleryDTO dto);
    Task<TransferDTO> UpdateRecordAsync(UpdateImageGalleryDTO dto);
}