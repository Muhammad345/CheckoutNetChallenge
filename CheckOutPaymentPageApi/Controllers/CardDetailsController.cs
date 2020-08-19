using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckOutRepository.Context;
using CheckOutRepository.Model;
using Repository;
using Repository.Models;
using Core.IServices;
using CheckOutPaymentPageApi.Models;
using Repository.Constants;
using Newtonsoft.Json;
using CheckOutCore.Domain;

namespace CheckOutPaymentPageApi.Controllers
{
    public class CardDetailsController : Controller
    {
        private readonly IRepository<MerchantConfig> _merchantConfig;

        private readonly ICardApiService _cardApiService;

        public CardDetailsController(IRepository<MerchantConfig> merchantConfig, ICardApiService cardApiService)
        {
            _merchantConfig = merchantConfig;
            _cardApiService = cardApiService;
        }

        // GET: CardDetails/Create
        public IActionResult Create()
        {
            // Success Mock 
            var cardDetail = new CardDetail {
                CardNumber = "1234 5678 9801 1789",
                CardExpiry_Month = "06",
                CardExpiry_Year = "2020",
                CVV = "123",
                MerchantId = 1,
                Id = 1,
                Name = "Irfan Akhtar",
                Amount = 10.00m

            };

            // Decliend Mock
            //var cardDetail = new CardDetail
            //{
            //    CardNumber = "8963 5678 9801 1789",
            //    CardExpiry_Month = "06",
            //    CardExpiry_Year = "2020",
            //    CVV = "123",
            //    MerchantId = 1,
            //    Id = 1,
            //    Name = "Irfan Akhtar"
            //};

            return View(cardDetail);
        }

        // POST: CardDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerchantId,Id,Name,CardNumber,CardExpiry_Month,CardExpiry_Year,CVV")] CardDetail cardDetail)
        {
            if (ModelState.IsValid)
            {
                cardDetail.ExternalRefId = Guid.NewGuid();

                var merchantConfigs =_merchantConfig.GetById(cardDetail.MerchantId);

                var cardApiResponse = await _cardApiService.ChargeCard(cardDetail);
                if(cardApiResponse.IsSuccessFull)
                {
                    var cardPaymentStatus = JsonConvert.DeserializeObject<CardPaymentResponse>(cardApiResponse.Data);
                    if (cardPaymentStatus.Status == CheckOutAppConstants.PaymentStatus.Accepted)
                    {
                        return Redirect(merchantConfigs.SuccessRedirectPageUrl);
                    }
                    else if(cardPaymentStatus.Status == CheckOutAppConstants.PaymentStatus.Declined)
                    {
                        return Redirect(merchantConfigs.DeclinedRedirectPageUrl);
                    }
                }
            }

            return View(cardDetail);
        }
    }
}
