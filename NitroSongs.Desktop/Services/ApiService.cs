using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NitroSongs.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly IOptions<Configuration> _config;
        public ApiService(HttpClient http, IOptions<Configuration> config)
        {
            _http = http;
            _config = config;

            _http.BaseAddress = new Uri(_config.Value.BaseUrl);
        }
        public void SetAccessToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var res = await _http.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                throw new Exception($"{content}");
            }

            return await res.Content.ReadFromJsonAsync<T>();
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var res = await _http.PostAsJsonAsync(url, data);
            
            if (!res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                throw new Exception($"{content}");
            }
            
            return await res.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<bool> PutAsync<TRequest>(string url, int id, TRequest data)
        {
            var res = await _http.PutAsJsonAsync($"{url}/{id}", data);
            
            if (!res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                throw new Exception($"{content}");
            }
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, string url)
        {
            var res = await _http.DeleteAsync($"{url}/{id}");
            
            if (!res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                throw new Exception($"{content}");
            }

            return res.IsSuccessStatusCode;
        }
    }
}
