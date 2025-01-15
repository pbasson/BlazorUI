using System.Text.Json;
using Blazor.UI.Models;
using Blazor.UI.Models.Entities;

namespace Blazor.UI.Services;

public class TransactionService
{
        public HttpClient _client; 
        // private readonly IConfiguration _configuration;

        public async Task<List<CRUDTransaction>> GetRecords() {
            try
            {
                var getrecord = await _client.GetAsync("api/CRUDTransaction/GetAllRecords");

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
