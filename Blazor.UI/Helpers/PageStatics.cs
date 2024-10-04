using Blazor.UI.Models;

namespace Blazor.UI.Helpers;

public static class PageStatics
{
    public static string WeatherPage { get; set; } = "Weather";

    public static string WeatherPageDetails { get; set; } = "Page Demonstrates Data Loading and Reseting of the Weather."; 


}

public static class WeatherStatics 
{
    public static List<KeyTable> WeatherType { get; set; } = new List<KeyTable>{  
        new KeyTable{ Id = 1, Name = "Cold"},
        new KeyTable{ Id = 2, Name = "Neutral"},
        new KeyTable{ Id = 3, Name = "Hot"},
    };

    public static List<KeyTypeTable> WeatherRange = new List<KeyTypeTable>
    {
        new KeyTypeTable{ Id = 1, Name = "Freezing" , Type = 1 },    
        new KeyTypeTable{ Id = 2, Name = "Bracing", Type = 1 },    
        new KeyTypeTable{ Id = 3, Name = "Chilly", Type = 1  },    
        new KeyTypeTable{ Id = 4, Name = "Cool", Type = 1  },    
        new KeyTypeTable{ Id = 5, Name = "Mild", Type = 2  },    
        new KeyTypeTable{ Id = 6, Name = "Warm", Type = 3  },    
        new KeyTypeTable{ Id = 7, Name = "Hot", Type = 3  },    
        new KeyTypeTable{ Id = 8, Name = "Sweltering", Type = 3  },    
        new KeyTypeTable{ Id = 9, Name = "Scorching", Type = 3  },    
    };

    public static KeyTable GetWeatherType(int typeId)
    {
        var getData = WeatherType.FirstOrDefault(x => x.Id == typeId);
        if(getData != null)
        {
            return getData;
        }

        return new();
    }
}
