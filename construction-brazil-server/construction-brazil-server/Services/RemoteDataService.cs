﻿using construction_brazil_server.Interfaces.Services;
using LazyCache;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace construction_brazil_server.Services
{
    public class RemoteDataService : IRemoteDataService
    {
        private readonly IAppCache _cache;

        public RemoteDataService(IAppCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetRemoteData<T>(string token, string requestUrl)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
            {
                var errMessage = response.Content.ReadAsStringAsync()?.Result ?? "Unknwon Error";
                throw new InvalidOperationException(errMessage);
            }

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task Post<T>(string token, string requestUrl, T data)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestUrl, stringContent);
            if (!response.IsSuccessStatusCode)
            {
                var errMessage = response.Content.ReadAsStringAsync()?.Result ?? "Unknwon Error";
                throw new InvalidOperationException(errMessage);
            }
        }

        public async Task<R?> PostWithReturn<T, R>(string token, string requestUrl, T data)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestUrl, stringContent);
            if (!response.IsSuccessStatusCode)
            {
                var errMessage = response.Content.ReadAsStringAsync()?.Result ?? "Unknwon Error";
                throw new InvalidOperationException(errMessage);
            }

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<R>(json);
        }
    }
}
