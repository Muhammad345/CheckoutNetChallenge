using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckOutRepository.Context;
using CheckOutRepository.Model;

namespace CheckOutPaymentPageApi.Controllers
{
    public class CardDetailsController : Controller
    {
        private readonly CheckoutPaymentGatewayAPIContext _context;

        public CardDetailsController(CheckoutPaymentGatewayAPIContext context)
        {
            _context = context;
        }

        // GET: CardDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CardNumer,CardExpiry_Month,CardExpiry_Year,CVV")] CardDetail cardDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardDetail);
        }
    }
}
