using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Models
{
    public class CoinListRequest
    {
        public string Message;
        public List<CoinInfoRequest> Data;
        public bool HasWarning;
        public int Type;

        [JsonConstructor]
        public CoinListRequest(string message, List<CoinInfoRequest> data, bool hasWarning, int type)
        {
            this.Message = message;
            this.Data = data;
            this.HasWarning = hasWarning;
            this.Type = type;
        }
    }
}
