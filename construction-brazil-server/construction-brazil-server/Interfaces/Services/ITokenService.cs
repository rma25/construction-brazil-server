using System.Threading.Tasks;

namespace construction_brazil_server.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> GetPermissionServerAccessToken(string scope, string clientId, string clientSecret, string address);
    }
}
