using System.Text.Json;
using Blazor.UI.Helpers;
using Blazor.UI.Models.Entities;
using Microsoft.Net.Http.Headers;

namespace Blazor.UI.Services;

public class TransactionService
{
        public HttpClient _client; 
        private readonly IConfiguration _configuration;
        private string? ApiURL {get; set;} 
        private string? ApiKey {get; set;} 


        public async Task<List<CRUDTransaction>> GetRecords() {
            try
            {
                var getrecord = await _client.GetAsync(TransactionNavigation.GetAllRecords);

                if (getrecord.IsSuccessStatusCode )
                {
                    var context = await getrecord.Content.ReadAsStreamAsync();
                    var test = await JsonSerializer.DeserializeAsync<List<CRUDTransaction>>(context);    
                    if (test != null && test.Any())
                    {
                        test.ForEach( x => {
                            Console.WriteLine($"TEST: {x.Id} {x.Name}");
                        });
                    }
                    return test;
                }

                return new();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
}
