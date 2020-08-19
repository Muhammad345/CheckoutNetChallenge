using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckOutPaymentPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutApiRunningController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Checkout Payment Page Running API Running";
        }
    }
}