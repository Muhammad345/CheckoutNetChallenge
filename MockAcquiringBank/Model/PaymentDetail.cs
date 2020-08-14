using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAcquiringBankAPI.Model
{
    public class PaymentDetail
    {
        public Guid AuthId { get; set; }

        public string Status { get; set; }

        public CardDetail CardDetail { get; set; }
    }
}
