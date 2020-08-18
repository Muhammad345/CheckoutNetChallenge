using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutPaymentGatewayAPI.Controllers
{
    [Route("[controller]")]
    public class PaymentPageController : Controller
    {
     
        // GET: PaymentPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentPage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}