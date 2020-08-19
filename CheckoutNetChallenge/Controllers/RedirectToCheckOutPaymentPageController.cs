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
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectToCheckOutPaymentPageController : ControllerBase
    {
        private readonly PaymentPageSettings _paymentPageSettings;

        public RedirectToCheckOutPaymentPageController(IOptions<PaymentPageSettings> options)
        {
            _paymentPageSettings = options.Value;
        }

        // GET: api/RedirectToCheckOutPaymentPage
        [HttpGet]
        public  IActionResult Get()
        {
            return Redirect(_paymentPageSettings.Url);
        }

        
    }
}
