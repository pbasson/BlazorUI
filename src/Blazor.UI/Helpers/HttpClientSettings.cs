namespace Blazor.UI.Helpers
{
    public class HttpClientSettings
    {
        public HttpClient _client = default!; 

        public HttpClientSettings( )
        {
            var ApiURL =  ConfigHandler.AppSetting["CoreApi:URL"] ?? string.Empty;
            var ApiKEY = ConfigHandler.AppSetting["CoreApi:KEY"] ?? string.Empty;
            _client = new HttpClient();
            _client.BaseAddress = new Uri( ApiURL );
            _client.DefaultRequestHeaders.Add( API_Statics.ApiKey, ApiKEY );
        }

        public async Task<HttpResponseMessage> GetAllAsync( string navigate ) {
            try {
                var getRecord = await _client.GetAsync(navigate);
                return getRecord;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}