﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICurrencyInfoService
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
    }
}
