using Newtonsoft.Json;

namespace API.Models
{
    public class CurrencyBasicInfoResponse
    {
        public string Price;
        public string Volume24hour;
        public string Changepct24hour;

        [JsonConstructor]
        public CurrencyBasicInfoResponse(string price, string volume24hour, string changepct24hour)
        {
            this.Price = price;
            this.Volume24hour = volume24hour;
            this.Changepct24hour = changepct24hour;
        }

    }
}
