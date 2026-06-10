namespace Blazor.Core.Helpers;

public static class ObjectExtension
{
    public static bool NullChecker(this object? ob)
    {
        if (ob != null) { return true; }
        
        return false;
    }

}
