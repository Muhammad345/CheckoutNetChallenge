using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutNetChallenge_WebSite.Controllers
{
    public class PaymentSuccessFullController : Controller
    {
        // GET: PaymentSuccessFull
        public ActionResult PaymentSuccessFull()
        {
            return View();
        }

    }
}