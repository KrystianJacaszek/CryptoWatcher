using API.Interfaces;
using API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.WebServices
{
    public class CurrencyInfoService : ICurrencyInfoService
    {
        private readonly HttpClient _httpClient;
        private string mainCurrnecyListUri = "all/coinlist?summary=true";

        public CurrencyInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            var response = await _httpClient.GetAsync(mainCurrnecyListUri);
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            var deserialziedJson = JsonConvert.DeserializeObject<CoinListRequest>(responseBody);

            return deserialziedJson.Data.Values;
        }
    }
}