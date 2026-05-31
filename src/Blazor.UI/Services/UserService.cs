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

            return new(ActionStatusType.Failed);
        }
        catch (Exception)
        {
            _logger.LogError("An error occurred while fetching all user records.");
            throw;
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

    public async Task<bool> CreateAsync(UserDTO dto)
    {
        var response = await new HttpClientSettings().PostAsync(TransactionNavigation.CreateRecord, dto);
        return await DeserializeResponse(response);
    }

    public async Task<bool> UpdateAsync(UserDTO dto)
    {
        var response = await new HttpClientSettings().PutAsync(TransactionNavigation.UpdateRecord, dto);
        return await DeserializeResponse(response);
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

}
