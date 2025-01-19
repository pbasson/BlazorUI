using System.Text;
using Blazor.Core.Helpers;
using Newtonsoft.Json;
using Blazor.Core.Interfaces.InterfaceConfigs;

namespace Blazor.UI.Helpers
{
    public class HttpClientSettings : IHttpClientSettings
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
                var result = await _client.GetAsync(navigate);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetRecordByIdAsync( string navigate, int id ) {
            try {
                var navigation = string.Format(navigate, id); 
                var result = await _client.GetAsync(navigation);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
 
        public async Task<HttpResponseMessage> PostAsync(string navigate, object ob) {
            try
            {
                var result = await _client.PostAsync( navigate, GetStringContent(ob) );
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string navigate, object ob)
        {
            try
            {
                var result = await _client.PutAsync( navigate, GetStringContent(ob) );
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteByIdAsync(string navigate, int id)
        {
            try
            {
                var navigation = string.Format(navigate, id); 
                var result = await _client.DeleteAsync( navigation );
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StringContent GetStringContent(object ob)
        {
            return new StringContent(JsonConvert.SerializeObject(ob), Encoding.UTF8, API_Statics.AppJson);
        }
    }
}