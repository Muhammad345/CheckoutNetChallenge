using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutNetChallenge.Merchant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CheckoutNetChallenge_WebSite.Controllers
{
    public class PaymentDeclinedController : Controller
    {
        private readonly PaymentPageSettings _paymentPageSettings;

        public PaymentDeclinedController(IOptions<PaymentPageSettings> options)
        {
            _paymentPageSettings = options.Value;
        }
        // GET: PaymentDeclined
        public ActionResult PaymentDeclined()
        {
            return View();
        }

        
    }
}