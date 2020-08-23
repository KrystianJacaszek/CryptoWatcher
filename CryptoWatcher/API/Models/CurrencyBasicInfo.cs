using Newtonsoft.Json;

namespace API.Models
{
    public class CurrencyBasicInfo
    {
        public string Name;
        public CurrencyBasicInfoResponse Info;
        [JsonConstructor]
        public CurrencyBasicInfo(string name, CurrencyBasicInfoResponse currencyBasicInfoResponse)
        {
            this.Name = name;
            this.Info = currencyBasicInfoResponse;
        }
    }
}
