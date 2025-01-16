namespace Blazor.UI.Helpers
{
    public static class ConfigHandler
    {
        public static IConfiguration AppSetting { get; }

        // Including EnvVariables allows the loading and usage of Env file values. 
        static ConfigHandler( )
        {
            AppSetting = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        }
    }

}