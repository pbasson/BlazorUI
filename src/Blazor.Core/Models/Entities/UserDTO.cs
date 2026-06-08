namespace Blazor.Core.Models.Entities;

public class UserDTO : IEntity
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public bool IsActive { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string ActiveStatus => IsActive ? "Active" : "Inactive";
}

public class UserTransferGridDTO : BaseTransfer
{
    public List<UserDTO>? Records { get; set; }

    public UserTransferGridDTO( ActionStatusType ActionStatusType, List<UserDTO>? Records = null) 
    {
        this.ActionStatusType = ActionStatusType;
        this.Records = Records;
    }
}

public class UserTransferDTO : BaseTransfer
{
    public UserDTO? Record { get; set; }

    public UserTransferDTO( ActionStatusType ActionStatusType, UserDTO? Record = null) 
    {
        this.ActionStatusType = ActionStatusType;
        this.Record = Record;
    }
}