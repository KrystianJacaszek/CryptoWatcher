using Newtonsoft.Json;

namespace API.Models
{
    public class CurrencyBasicInfoRequest
    {
        public CurrencyBasicInfoResponse Display;

        [JsonConstructor]
        public CurrencyBasicInfoRequest(CurrencyBasicInfoResponse request)
        {
            this.Display = request;
        }
    }
}
