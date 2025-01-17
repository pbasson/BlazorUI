using Newtonsoft.Json;
using Blazor.UI.Helpers;
using Blazor.Core.Models.Entities;
using Blazor.Core.Constants;
using Blazor.Core.Interfaces.InterfaceServices;

namespace Blazor.UI.Services;

public class TransactionService : ITransactionService
{
    public async Task<List<CRUDTransactionDTO>> GetAllRecordsAsync() {
        try
        {
            var getrecord = await new HttpClientSettings().GetAllAsync(TransactionNavigation.GetAllRecords);
            if (getrecord.IsSuccessStatusCode )
            {
                var context = await getrecord.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<List<CRUDTransactionDTO>>(context);
                
                if (getRecord != null && getRecord.Any())
                {
                    return getRecord;
                }
            }

            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CRUDTransactionDTO> GetRecordByIdAsync(int id)
    {
        var getrecord = await new HttpClientSettings().GetRecordByIdAsync(TransactionNavigation.GetRecordById, id);
        if (getrecord.IsSuccessStatusCode )
        {
            var context = await getrecord.Content.ReadAsStringAsync();
            var getRecord = JsonConvert.DeserializeObject<CRUDTransactionDTO>(context);
            
            if (getRecord != null )
            {
                return getRecord;
            }
        }
        return new();
    }

    public async Task<bool> CreateRecordAsync(CRUDTransactionDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateRecordAsync(CRUDTransactionDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteRecordAsync(int id)
    {
        throw new NotImplementedException();
    }

}
