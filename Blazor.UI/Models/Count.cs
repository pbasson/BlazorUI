using System;

namespace Blazor.UI.Models;

public class Count
{
    public int CurrentCount { get; set; } = 0;
    public int HighestCount { get; set; } = 0;
    public int TotalCount { get; set; } = 0;

    public void ResetCount()
    {
        CurrentCount = 0;
    } 

    public void IncrementCount()
    {
        CurrentCount++;
        TotalCount++;
        
        if( CurrentCount > HighestCount )
        {
            HighestCount = CurrentCount;
        }
    }
}
