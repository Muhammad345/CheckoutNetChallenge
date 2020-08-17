using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace CheckoutPaymentGatewayAPI.Controllers
{
    public class CardDetailsController : Controller
    {
       
        public CardDetailsController(CheckoutPaymentGatewayAPIContext context)
        {
            _context = context;
        }

        // GET: CardDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardDetail.ToListAsync());
        }

        // GET: CardDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardDetail = await _context.CardDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardDetail == null)
            {
                return NotFound();
            }

            return View(cardDetail);
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

        //// GET: CardDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cardDetail = await _context.CardDetail.FindAsync(id);
        //    if (cardDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cardDetail);
        //}

        //// POST: CardDetails/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CardNumer,CardExpiry_Month,CardExpiry_Year,CVV")] CardDetail cardDetail)
        //{
        //    if (id != cardDetail.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cardDetail);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CardDetailExists(cardDetail.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cardDetail);
        //}

        //// GET: CardDetails/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cardDetail = await _context.CardDetail
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cardDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cardDetail);
        //}

        //// POST: CardDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cardDetail = await _context.CardDetail.FindAsync(id);
        //    _context.CardDetail.Remove(cardDetail);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CardDetailExists(int id)
        //{
        //    return _context.CardDetail.Any(e => e.Id == id);
        //}
    }
}
