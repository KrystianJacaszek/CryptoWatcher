using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoWatcher.Models
{
    public class Currency
    {
        public Currency(int id, string imageUrl, string symbol, string fullName)
        {
            this.Id = id;
            this.ImageUrl = imageUrl;
            this.Symbol = symbol;
            this.FullName = fullName;
        }
        public int Id { get; }
        public string ImageUrl { get; }
        public string Symbol { get; }
        public string FullName { get; }
    }
}
