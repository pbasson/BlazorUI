using Newtonsoft.Json;
using Blazor.UI.Helpers;
using Blazor.UI.Models.Entities;

namespace Blazor.UI.Services;

public class TransactionService
{
        public HttpClient _client; 
        private readonly IConfiguration _configuration;
        private string? ApiURL {get; set;} 
        private string? ApiKEY {get; set;} 


        public TransactionService(HttpClient client, IConfiguration configuration)
        {
            ApiURL = ConfigHandler.AppSetting["CoreApi:URL"];
            ApiKEY = ConfigHandler.AppSetting["CoreApi:KEY"];
            _configuration = configuration;
            _client = client;
            _client.BaseAddress = new Uri( ApiURL ?? "" );
            // _client.DefaultRequestHeaders.Add( HeaderNames.Accept, "application/json" );
            _client.DefaultRequestHeaders.Add( API_Statics.ApiKey, ApiKEY );
        }    


        public async Task<List<CRUDTransaction>> GetRecords() {
            try
            {
                var getrecord = await _client.GetAsync(TransactionNavigation.GetAllRecords);

                if (getrecord.IsSuccessStatusCode )
                {
                    var context = await getrecord.Content.ReadAsStringAsync();
                    var getRecord = JsonConvert.DeserializeObject<List<CRUDTransaction>>(context);
                    
                    if (getRecord != null && getRecord.Any())
                    {
                        getRecord.ForEach( x => {
                            Console.WriteLine($"TEST: {x.Id} {x.Name}");
                        });
                        return getRecord;
                    }
                }

                return new();
            }
            catch (Exception)
            {
                throw;
            }
        }
}
