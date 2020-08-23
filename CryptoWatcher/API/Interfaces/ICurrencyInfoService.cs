using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICurrencyInfoService
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<CurrencyBasicInfo> GetSingleCurrencyBasicInfoAsync(string symbol);
        Task<IEnumerable<CurrencyBasicInfo>> GetMultipleCurrnecyBasicInfoAsync(IList<string> symbolList);
    }
}
