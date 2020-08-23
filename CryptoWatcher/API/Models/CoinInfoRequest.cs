using Newtonsoft.Json;

namespace API.Models
{
    public class CoinInfoRequest
    {
        public Currency CoinInfo;
        [JsonConstructor]
        public CoinInfoRequest(Currency currency)
        {
            this.CoinInfo = currency;
        }
    }
}
