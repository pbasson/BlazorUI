using Newtonsoft.Json;
using Blazor.UI.Helpers;
using Blazor.Core.Models.Entities;
using Blazor.Core.Constants;
using Blazor.Core.Interfaces.InterfaceServices;
using Blazor.Core.Helpers;

namespace Blazor.UI.Services;

public class TransactionService : ITransactionService
{
    public async Task<List<CRUDTransactionDTO>> GetAllRecordsAsync() {
        try
        {
            var response = await new HttpClientSettings().GetAllAsync(TransactionNavigation.GetAllRecords);
            if (response.IsSuccessStatusCode )
            {
                var context = await response.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<List<CRUDTransactionDTO>>(context);
                
                if (getRecord != null && getRecord.Any())
                {
                    return getRecord;
                }
            }

            return [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CRUDTransactionDTO> GetRecordByIdAsync(int id)
    {
        var response = await new HttpClientSettings().GetRecordByIdAsync(TransactionNavigation.GetRecordById, id);
        if (response.IsSuccessStatusCode ) {
            var context = await response.Content.ReadAsStringAsync();
            var getRecord = JsonConvert.DeserializeObject<CRUDTransactionDTO>(context);
            
            return getRecord != null ? getRecord : new(); 
        }
        return new();
    }

    public async Task<bool> CreateRecordAsync(CRUDTransactionDTO dto)
    {
        var response = await new HttpClientSettings().PostAsync(TransactionNavigation.CreateRecord, dto);
        return await DeserializeResponse(response);
    }

    public async Task<bool> UpdateRecordAsync(CRUDTransactionDTO dto)
    {
        var response = await new HttpClientSettings().PutAsync(TransactionNavigation.UpdateRecord, dto);
        return await DeserializeResponse(response);
    }


    public async Task<bool> DeleteRecordAsync(int id)
    {
        var response = await new HttpClientSettings().DeleteByIdAsync(TransactionNavigation.DeleteRecord, id);
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
