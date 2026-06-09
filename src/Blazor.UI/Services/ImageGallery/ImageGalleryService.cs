namespace Blazor.UI.Services.ImageGallery;

public class ImageGalleryService : BaseService, IImageGalleryService
{
    private readonly ILogger<ImageGalleryService> _logger = new LoggerFactory().CreateLogger<ImageGalleryService>();

    public async Task<TransferImageGalleryGridDTO> GetAllRecordsAsync()
    {
        try
        {
            _logger.LogInformation("Image: Fetch All User Records.");
            var response = await new HttpClientSettings().GetAllAsync(ImageGalleryNavigation.GetAllRecords);
            if (response.IsSuccessStatusCode )
            {
                var context = await response.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<TransferImageGalleryGridDTO>(context);
                
                if (getRecord != null && getRecord.Records != null)
                {
                    _logger.LogInformation("Successfully fetched all user records.");
                    return getRecord;
                }
            }

            _logger.LogWarning(
                "User: Failed to fetch all user records. API returned status code {StatusCode}.",
                response.StatusCode);
            return new(ActionStatusType.Failed);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "User: Invalid JSON returned while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "User: An unexpected error occurred while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
    }

    public async Task<TransferImageGalleryGridDTO> GetRecordsByPaginationAsync(int page)
    {
        try
        {
            _logger.LogInformation("Image: Fetch All User Records.");
            var response = await new HttpClientSettings().GetByIdAsync(ImageGalleryNavigation.GetRecordsByPaginationAsync, page);
            if (response.IsSuccessStatusCode )
            {
                var context = await response.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<TransferImageGalleryGridDTO>(context);
                
                if (getRecord != null && getRecord.Records != null)
                {
                    _logger.LogInformation("Successfully fetched all user records.");
                    return getRecord;
                }
            }

            _logger.LogWarning(
                "User: Failed to fetch all user records. API returned status code {StatusCode}.",
                response.StatusCode);
            return new(ActionStatusType.Failed);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "User: Invalid JSON returned while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "User: An unexpected error occurred while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
    }

    public async Task<TransferImageGalleryDTO> GetRecordByIdAsync(int id)
    {
        var response = await new HttpClientSettings().GetByIdAsync(ImageGalleryNavigation.GetRecordById, id);
        if (response.IsSuccessStatusCode ) {
            var context = await response.Content.ReadAsStringAsync();
            var getRecord = JsonConvert.DeserializeObject<TransferImageGalleryDTO>(context);
            
            return getRecord ?? new(ActionStatusType.Failed); 
        }
        return new(ActionStatusType.Failed);
    }
    public async Task<TransferDTO> CreateRecordAsync(CreateImageGalleryDTO dto)
    {
        _logger.LogInformation("Creating user with payload: {Payload}", SerializePayload(dto));
        var response = await new HttpClientSettings().PostAsync(ImageGalleryNavigation.CreateRecord, dto);
        var result = await DeserializeResponseTransfer(response);
        _logger.LogInformation("Create user result: {@Result}", result);

        return result;
    }

    public async Task<TransferDTO> UpdateRecordAsync(UpdateImageGalleryDTO dto)
    {
        _logger.LogInformation("Updating user {UserId} with payload: {Payload}", dto.ImageGalleryId, SerializePayload(dto));
        var response = await new HttpClientSettings().PutAsync(UserNavigationContants.UpdateRecord, dto);
        var result = await DeserializeResponseTransfer(response);
        _logger.LogInformation("Update user {UserId} result: {@Result}", dto.ImageGalleryId, result);

        return result;
    }
}
