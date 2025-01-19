namespace Blazor.Core.Interfaces.InterfaceConfigs
{
    public interface IHttpClientSettings
    {
        public Task<HttpResponseMessage> GetAllAsync( string navigate );
        public Task<HttpResponseMessage> GetRecordByIdAsync( string navigate, int id );
        public Task<HttpResponseMessage> PostAsync(string navigate, object ob);
        public Task<HttpResponseMessage> PutAsync(string navigate, object ob);
        public Task<HttpResponseMessage> DeleteByIdAsync( string navigate, int id );
    }
}