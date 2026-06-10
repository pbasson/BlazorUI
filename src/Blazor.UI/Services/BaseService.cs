namespace Blazor.UI.Services;

public abstract class BaseService
{
    
    public string SerializePayload(object payload)
    {
        return JsonConvert.SerializeObject(payload);
    }

    public async Task<TransferDTO> DeserializeResponseTransfer(HttpResponseMessage response)
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
}