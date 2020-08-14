﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAcquiringBankAPI.Model
{
    public class CardDetail
    {
        public string Cardnumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Cvv { get; set; }
    }
}
