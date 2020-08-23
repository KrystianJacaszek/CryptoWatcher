using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using API.WebServices;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IEnumerable<Currency>> GetCurrenciesList()
        {
            return await _currencyInfoService.GetCurrenciesAsync();
        }
    }
}