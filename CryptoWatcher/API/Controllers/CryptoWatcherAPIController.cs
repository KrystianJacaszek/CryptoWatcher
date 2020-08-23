using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoWatcherAPIController : Controller
    {
        private readonly ICurrencyInfoService _currencyInfoService;

        public CryptoWatcherAPIController(ICurrencyInfoService currencyInfoService)
        {
            _currencyInfoService = currencyInfoService;
        }

        [HttpGet("currencyList")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrenciesList()
        {
            var x = await _currencyInfoService.GetCurrenciesAsync();
            return Ok(JsonConvert.SerializeObject(x));
        }

        [HttpGet("singleCurrencyInfo")]
        public async Task<ActionResult<CurrencyBasicInfo>> GetCurrnecyBasicInfo(string symbol)
        {
            var x = await _currencyInfoService.GetSingleCurrencyBasicInfoAsync(symbol);

            return Ok(JsonConvert.SerializeObject(x));
        }

        [HttpPost("multipleCurrencyInfo")]
        public async Task<ActionResult<IEnumerable<CurrencyBasicInfo>>> GetMultipleCurrnecyBasicInfo(string[] symbolList)
        {
            var x = await _currencyInfoService.GetMultipleCurrnecyBasicInfoAsync(symbolList);

            return Ok(JsonConvert.SerializeObject(x));
        }
    }
}