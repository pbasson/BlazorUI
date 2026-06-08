namespace Blazor.Core.Models.DTOs.Transfer;

public class TransferDTO : BaseTransfer
{
    public int Id {get; set;}
    public Guid? MessageId {get; set;} 
    public string Message { get; set; }
    public bool Success => Id > 0;

    public ServiceResultType ServiceResultType = ServiceResultType.NoAction;

    public TransferDTO(
        int id,
        string message = "",
        ServiceResultType serviceResultType = ServiceResultType.NoAction,
        Guid? messageId = null,
        ActionStatusType actionStatusType = ActionStatusType.NoAction)
    {
        var basicError = "Entity Not Created";
        var failure = !string.IsNullOrEmpty(message) ?  message : basicError ;

        Id = id;
        MessageId = messageId;
        Message = id > 0  ? "Success: Entity Created" :   $"Failure: {failure}" ;
        ServiceResultType = serviceResultType;
        ActionStatusType = actionStatusType == ActionStatusType.NoAction && id > 0
            ? ActionStatusType.Ok
            : actionStatusType;
    }
}

public static class TransferFactory
{
    public static TransferDTO GetTransferFailure(TransferEnum transfer)
    {
        var message = "Data Error";
        var actionStatusType = ActionStatusType.BadRequest;

        switch (transfer)
        {
            case TransferEnum.DTONull:
                message = "DTO Is Null";
                actionStatusType = ActionStatusType.BadRequest;
                break;
            case TransferEnum.EntityNotCreated:
                message = "Entity Not Created";
                actionStatusType = ActionStatusType.InternalServerError;
                break;
            case TransferEnum.EntityNotExist:
                message = "Entity Does Not Exist";
                actionStatusType = ActionStatusType.NotFound;
                break;
            case TransferEnum.SaveChangesNotExecuted:
                message = "Save Changes Not Executed";
                actionStatusType = ActionStatusType.InternalServerError;
                break;

        }
        return new TransferDTO(0, message, ServiceResultType.Failed, actionStatusType: actionStatusType);
    }
}

