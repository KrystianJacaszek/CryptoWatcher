using CryptoWatcher.Interfaces;
using CryptoWatcher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        [HttpGet("currnecyList")]
        public async Task<IEnumerable<Currency>> GetAsync()
        {
            return await _currencyInfoService.GetCurrencies();
        }

        [HttpGet("singleInfo")]
        public async Task<ActionResult<CurrencyBasicInfo>> GetCurrencyInfoAsync(string symbol)
        {
            var x = await _currencyInfoService.GetSingleCurrencyInfo(symbol);
            return Ok(JsonConvert.SerializeObject(x));
        }

        [HttpPost("multipleInfo")]
        public async Task<ActionResult<IEnumerable<CurrencyBasicInfo>>> GetMultipleCurrencyInfoAsync(string[] symbolList)
        {
            var x = await _currencyInfoService.GetMultipleCurrencyInfo(symbolList);
            return Ok(JsonConvert.SerializeObject(x));
        }
    }
}
