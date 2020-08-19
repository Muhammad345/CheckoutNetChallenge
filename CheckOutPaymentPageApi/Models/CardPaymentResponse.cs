﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutPaymentPageApi.Models
{
    public class CardPaymentResponse
    {
        public string AuthCode { get; set; }

        public string Status { get; set; }

        public Guid ExternalRefId { get; set; }

    }
}
