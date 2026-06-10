namespace Blazor.Core.Enums;

public enum ServiceResultType
{
    NoAction,
    Success,
    NotFound,
    Conflict,
    Failed
}

public record ServiceResult( ServiceResultType Type, string Message );