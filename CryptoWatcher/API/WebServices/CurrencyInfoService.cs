using API.Interfaces;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.WebServices
{
    public class CurrencyInfoService : ICurrencyInfoService
    {
        private readonly HttpClient _httpClient;
        private string mainCurrnecyListUri = "top/mktcapfull?limit=30&tsym=USD";
        private string currnecyBasicInfo = "generateAvg";
        private string defaultConvertCurrency = "USD";

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

            IEnumerable<Currency> finalList = deserialziedJson.Data.Select(x => x.CoinInfo);

            return finalList;
        }

        public async Task<IEnumerable<CurrencyBasicInfo>> GetMultipleCurrnecyBasicInfoAsync(IList<string> symbolList)
        {
            var currnecyList = new List<CurrencyBasicInfo>();

            foreach(string currnecy in symbolList)
            {
                currnecyList.Add(await GetSingleCurrencyBasicInfoAsync(currnecy));
            }
            return currnecyList;
        }

        public async Task<CurrencyBasicInfo> GetSingleCurrencyBasicInfoAsync(string symbol)
        {
            var response = await _httpClient.GetAsync(currnecyBasicInfo + String.Format("?fsym={0}&tsym={1}&e=Kraken", symbol, defaultConvertCurrency));
            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            var deserializedJson = JsonConvert.DeserializeObject<CurrencyBasicInfoRequest>(responseBody);

            CurrencyBasicInfoResponse coin;

            if (deserializedJson.Display == null)
            {
                coin = new CurrencyBasicInfoResponse("no data", "no data", "no data");
            }else
            {
                coin = deserializedJson.Display;
            }

            return new CurrencyBasicInfo(symbol, coin);
        }


    }
}