using CryptoWatcher.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWatcher.Interfaces
{
    public interface ICurrencyInfoService
    {
        Task<IEnumerable<Currency>> GetCurrencies();
        Task<CurrencyBasicInfo> GetSingleCurrencyInfo(string symbol);
        Task<IEnumerable<CurrencyBasicInfo>> GetMultipleCurrencyInfo(string[] symbolList);
    }
}
