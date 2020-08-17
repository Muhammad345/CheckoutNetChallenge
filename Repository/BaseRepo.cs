using CheckOutRepository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class BaseRepo
    {
        public CheckoutPaymentGatewayAPIContext _context { get; set; }
    }
}
