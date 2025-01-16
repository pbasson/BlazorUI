namespace Blazor.UI.Helpers
{
    public static class ConfigHandler
    {
        public static IConfiguration AppSetting { get; }

        static ConfigHandler()
        {
            AppSetting = new ConfigurationBuilder().AddJsonFile(API_Statics.AppSettingsFile).Build();
        }
    }
}