using System.Threading.Tasks;

namespace construction_brazil_server.Interfaces.Services
{
    public interface IRemoteDataService
    {
        Task<T?> GetRemoteData<T>(string token, string requestUrl);        
        Task Post<T>(string token, string requestUrl, T data);
        Task<R?> PostWithReturn<T, R>(string token, string requestUrl, T data);
    }
}
