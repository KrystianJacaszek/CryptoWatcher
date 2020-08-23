using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CoinListRequest
    {
        public string Response;
        public string Message;
        public Dictionary<string, Currency> Data;
        public bool HasWarning;
        public int Type;
    }
}
