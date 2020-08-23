using CryptoWatcher.Interfaces;
using CryptoWatcher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWatcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyInfo : ControllerBase
    {
        private readonly ILogger<CurrencyInfo> _logger;
        private readonly ICurrencyInfoService _currencyInfoService;


        public CurrencyInfo(ICurrencyInfoService currencyInfoService, ILogger<CurrencyInfo> logger)
        {
            _currencyInfoService = currencyInfoService;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IEnumerable<Currency>> GetAsync()
        {
            return await _currencyInfoService.GetCurrencies();
        }
    }
}
