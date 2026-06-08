namespace Blazor.UI.Utility;

public class HttpClientSettings : IHttpClientSettings
{
    private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(60);
    public HttpClient _client = default!; 
    private readonly ILogger<HttpClientSettings> _logger;
    public HttpClientSettings( )
    {
        _logger = new LoggerFactory().CreateLogger<HttpClientSettings>();
        InitializeHttpClient();
    }

    private void InitializeHttpClient()
    {
        var ApiURL = $"http://{ConfigHandler.AppSetting["CoreApi:URL"] ?? "localhost"}/api/";
        var ApiKEY = ConfigHandler.AppSetting["CoreApi:KEY"] ?? string.Empty;
        _client = new HttpClient
        {
            BaseAddress = new Uri(ApiURL),
            Timeout = RequestTimeout
        };
        _client.DefaultRequestHeaders.Add(API_Statics.ApiKey, ApiKEY);
    }

    public async Task<HttpResponseMessage> GetAllAsync( string navigate ) {
        try 
        {
            var result = await _client.GetAsync(navigate);
            return result;
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "Timed out while calling GetAllRecords.");
            return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
            {
                ReasonPhrase = "The API request timed out."
            };
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error while calling GetAllRecords.");
            return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
            {
                ReasonPhrase = "The API request could not be completed."
            };
        }
    }

    public async Task<HttpResponseMessage> GetByIdAsync( string navigate, int id ) {
        try 
        {
            var navigation = string.Format(navigate, id); 
            var result = await _client.GetAsync(navigation);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError( ex,"Error GetByIdAsync");
            throw;
        }
    }

    public async Task<HttpResponseMessage> GetByNameAsync( string navigate, string username ) {
        try 
        {
            var navigation = string.Format(navigate, username); 
            var result = await _client.GetAsync(navigation);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError( ex,"Error GetByIdAsync");
            throw;
        }
    }

    public async Task<HttpResponseMessage> PostAsync(string navigate, object ob) {
        try
        {
            var result = await _client.PostAsync( navigate, GetStringContent(ob) );
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError( ex,"Error GetByIdAsync");
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
        catch (Exception ex)
        {
            _logger.LogError( ex,"Error PutAsync");
            throw;
        }
    }

    public async Task<HttpResponseMessage> DeleteAsync(string navigate, int id)
    {
        try
        {
            var navigation = $"{navigate}?id={id}";
            var result = await _client.DeleteAsync( navigation );
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError( ex,"Error DeleteAsync");
            throw;
        }
    }

    private StringContent GetStringContent(object ob) => new(JsonConvert.SerializeObject(ob), Encoding.UTF8, API_Statics.AppJson);
}
