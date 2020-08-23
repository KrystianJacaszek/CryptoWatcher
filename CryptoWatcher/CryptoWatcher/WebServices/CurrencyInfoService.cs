using CryptoWatcher.Interfaces;
using CryptoWatcher.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoWatcher.WebServices
{
    public class CurrencyInfoService: ICurrencyInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly string currencyApitEndpoint = "CryptoWatcherAPI";

        public CurrencyInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var response = await _httpClient.GetAsync(currencyApitEndpoint);
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IEnumerable<Currency>>(responseBody);
        }
    }
}