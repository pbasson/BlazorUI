using Newtonsoft.Json;
using Blazor.UI.Helpers;
using Blazor.UI.Models.Entities;

namespace Blazor.UI.Services;

public class TransactionService
{

    public TransactionService()
    {
    }    

    public async Task<List<CRUDTransaction>> GetRecords() {
        try
        {
            var getrecord = await new HttpClientSettings().GetAllAsync(TransactionNavigation.GetAllRecords);
            if (getrecord.IsSuccessStatusCode )
            {
                var context = await getrecord.Content.ReadAsStringAsync();
                var getRecord = JsonConvert.DeserializeObject<List<CRUDTransaction>>(context);
                
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

}
