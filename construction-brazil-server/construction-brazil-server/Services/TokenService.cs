using construction_brazil_server.Interfaces.Services;
using LazyCache;

namespace construction_brazil_server.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAppCache _cache;

        public TokenService(IAppCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetPermissionServerAccessToken(string scope, string clientId, string clientSecret, string address)
        {
            return await GetServerAccessToken(scope, clientId, clientSecret, address);
        }

        private async Task<string> GetServerAccessToken(string scope, string clientId, string clientSecret, string address)
        {
            return "";
            //return await _cache.GetOrAddAsync(clientId, async entry =>
            //{
            //    using (var client = new HttpClient())
            //    {
            //        var disco = await client.GetDiscoveryDocumentAsync(address);
            //        if (!disco.IsError)
            //        {
            //            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //            {
            //                Address = disco.TokenEndpoint,
            //                ClientId = clientId,
            //                ClientSecret = clientSecret,
            //                Scope = scope
            //            });

            //            if (!tokenResponse.IsError)
            //            {
            //                entry.AbsoluteExpiration = DateTime.Now.AddSeconds(Math.Max(0, tokenResponse.ExpiresIn - 10));
            //                return tokenResponse.AccessToken;
            //            }

            //            throw new InvalidOperationException(tokenResponse.Error);
            //        }
            //        else
            //        {
            //            throw new InvalidOperationException(disco.Error);
            //        }
            //    }
            //});
        }

    }
}
