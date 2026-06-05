namespace Blazor.UI.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public async Task<UserTransferGridDTO> GetAllAsync() {
        try
        {
            _logger.LogInformation("Fetching all user records.");
            var response = await new HttpClientSettings().GetAllAsync(TransactionNavigation.GetAllRecords);
            if (response.IsSuccessStatusCode )
            {
                var context = await response.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<UserTransferGridDTO>(context);
                
                if (getRecord != null && getRecord.Records != null)
                {
                    _logger.LogInformation("Successfully fetched all user records.");
                    return getRecord;
                }
            }

            _logger.LogWarning(
                "Failed to fetch all user records. API returned status code {StatusCode}.",
                response.StatusCode);
            return new(ActionStatusType.Failed);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Invalid JSON returned while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while fetching all user records.");
            return new(ActionStatusType.Failed);
        }
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        var response = await new HttpClientSettings().GetByIdAsync(TransactionNavigation.GetRecordById, id);
        if (response.IsSuccessStatusCode ) {
            var context = await response.Content.ReadAsStringAsync();
            var getRecord = JsonConvert.DeserializeObject<UserDTO>(context);
            
            return getRecord != null ? getRecord : new(); 
        }
        return new();
    }

    public async Task<TransferDTO> CreateAsync(UserDTO dto)
    {
        _logger.LogInformation("Creating user with payload: {Payload}", SerializePayload(dto));
        var response = await new HttpClientSettings().PostAsync(TransactionNavigation.CreateRecord, dto);
        var result = await DeserializeResponseTransfer(response);
        _logger.LogInformation("Create user result: {@Result}", result);

        return result;
    }

    public async Task<TransferDTO> UpdateAsync(UserDTO dto)
    {
        _logger.LogInformation("Updating user {UserId} with payload: {Payload}", dto.Id, SerializePayload(dto));
        var response = await new HttpClientSettings().PutAsync(TransactionNavigation.UpdateRecord, dto);
        var result = await DeserializeResponseTransfer(response);
        _logger.LogInformation("Update user {UserId} result: {@Result}", dto.Id, result);

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await new HttpClientSettings().DeleteAsync(TransactionNavigation.DeleteRecord, id);
        return await DeserializeResponse(response);
    }

    private static async Task<bool> DeserializeResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode )
        {
            var context = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(context);
        }
        return false;
    }

    private static async Task<TransferDTO> DeserializeResponseTransfer(HttpResponseMessage response)
    {
        var errorTransfer = new TransferDTO(0, "Request Failed", ServiceResultType.Failed, actionStatusType: ActionStatusType.InternalServerError);
        if (response.IsSuccessStatusCode )
        {
            var context = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TransferDTO>(context);
            return result != null ? result : errorTransfer;
        }
        return errorTransfer;
    }

    private static string SerializePayload(object payload)
    {
        return JsonConvert.SerializeObject(payload);
    }
}
