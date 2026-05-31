namespace Blazor.Core.Interfaces.Configs;

public interface IHttpClientSettings
{
    public Task<HttpResponseMessage> GetAllAsync( string navigate );
    public Task<HttpResponseMessage> GetByIdAsync( string navigate, int id );
    public Task<HttpResponseMessage> PostAsync(string navigate, object ob);
    public Task<HttpResponseMessage> PutAsync(string navigate, object ob);
    public Task<HttpResponseMessage> DeleteAsync( string navigate, int id );
}