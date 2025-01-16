using Blazor.UI.Models.Entities;

namespace Blazor.UI.Helpers;

public static class WeatherStatics 
{
    public static List<KeyIconTable> WeatherType { get; set; } = new List<KeyIconTable>{  
        new KeyIconTable{ Id = 1, Name = "Cold", Icon = "<i class=\"bi bi-snow\"></i>" },
        new KeyIconTable{ Id = 2, Name = "Neutral", Icon = "<i class=\"bi bi-moisture\"></i>"},
        new KeyIconTable{ Id = 3, Name = "Hot", Icon = "<i class=\"bi bi-sun\"></i>"},
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

    public static KeyIconTable GetWeatherType(int typeId)
    {
        var getData = WeatherType.FirstOrDefault(x => x.Id == typeId);
        if(getData != null)
        {
            return getData;
        }

        return new();
    }
}
