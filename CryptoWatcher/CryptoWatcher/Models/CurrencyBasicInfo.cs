using Newtonsoft.Json;

namespace CryptoWatcher.Models
{
    public class CurrencyBasicInfo
    {
        public string Name;
        public CurrencyBasicInfoResponse Info;

        [JsonConstructor]
        public CurrencyBasicInfo(string symbol, CurrencyBasicInfoResponse currencyBasicInfoResponse)
        {
            this.Name = symbol;
            this.Info = currencyBasicInfoResponse;
        }
    }
}
