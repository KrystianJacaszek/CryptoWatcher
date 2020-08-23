using CryptoWatcher.Interfaces;
using CryptoWatcher.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWatcher.WebServices
{
    public class CurrencyInfoService: ICurrencyInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly string currencyApitEndpoint = "CryptoWatcherAPI";
        private readonly string getCurnnciesList = "/currencyList";
        private readonly string getCurrencyInfo = "/singleCurrencyInfo";
        private readonly string getMultipleCurrencyInfo = "/multipleCurrencyInfo";

        public CurrencyInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var response = await _httpClient.GetAsync(currencyApitEndpoint + getCurnnciesList);
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;
            string tempDeserialize = (string)JsonConvert.DeserializeObject(responseBody);

            return JsonConvert.DeserializeObject<IEnumerable<Currency>>(tempDeserialize);
        }

        public async Task<CurrencyBasicInfo> GetSingleCurrencyInfo(string symbol)
        {
            var response = await _httpClient.GetAsync(currencyApitEndpoint + getCurrencyInfo + String.Format("?symbol={0}", symbol));
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;
            var tempDeserialize = JsonConvert.DeserializeObject(responseBody);

            return JsonConvert.DeserializeObject<CurrencyBasicInfo>((string)tempDeserialize);
        }

        public async Task<IEnumerable<CurrencyBasicInfo>> GetMultipleCurrencyInfo(string[] symbolList)
        {
            var json = JsonConvert.SerializeObject(symbolList);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(currencyApitEndpoint + getMultipleCurrencyInfo, content);
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;
            string tempDeserialize = (string)JsonConvert.DeserializeObject(responseBody);

            return JsonConvert.DeserializeObject<IEnumerable<CurrencyBasicInfo>>(tempDeserialize);
        }
    }
}