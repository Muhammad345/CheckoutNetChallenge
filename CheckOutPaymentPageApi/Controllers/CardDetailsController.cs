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
using Newtonsoft.Json;
using CheckOutCore.Domain;
using AutoMapper;
using Shared;

namespace CheckOutPaymentPageApi.Controllers
{
    public class CardDetailsController : Controller
    {
        private readonly IRepository<MerchantConfig> _merchantConfigRepository;
        private readonly ICardApiService _cardApiService;
        private readonly IPaymentDetailDataService _paymentDetailDataService;
        

        public CardDetailsController(IRepository<MerchantConfig> merchantConfig, ICardApiService cardApiService, IPaymentDetailDataService paymentDetailDataService)
        {
            _merchantConfigRepository = merchantConfig;
            _cardApiService = cardApiService;
            _paymentDetailDataService = paymentDetailDataService;
        }

        // GET: CardDetails/Create
        public IActionResult Create()
        {
            // Success Mock 
            var cardDetail = new CardPaymentDetail
            {
                CardNumber = "1234567898011789",
                CardExpiry_Month = "06",
                CardExpiry_Year = "2020",
                CVV = "123",
                MerchantId = 1,
                AccountId = 1,
                Name = "Irfan Akhtar",
                Amount = 10.00m
            };

            // Decliend Mock
            //var cardDetail = new CardPaymentDetail
            //{
            //    CardNumber = "3322 5678 9801 1789",
            //    CardExpiry_Month = "06",
            //    CardExpiry_Year = "2020",
            //    CVV = "123",
            //    MerchantId = 1,
            //    AccountId = 1,
            //    Name = "Irfan Akhtar",
            //    Amount = 10.00m
            //};

            return View(cardDetail);
        }

        // POST: CardDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerchantId,AccountId,Id,Name,CardNumber,CardExpiry_Month,CardExpiry_Year,CVV,Amount")] CardPaymentDetail cardPaymentDetail)
        {
            if (ModelState.IsValid)
            {
                cardPaymentDetail.ExternalRefId = Guid.NewGuid();

                var merchantConfigs =_merchantConfigRepository.GetById(cardPaymentDetail.MerchantId);

                var cardApiResponse = await _cardApiService.ChargeCard(cardPaymentDetail);

                if (cardApiResponse.IsSuccessFull)
                {
                    var cardPaymentStatus = JsonConvert.DeserializeObject<CardPaymentResponse>(cardApiResponse.Data);

                    // Ideal for this type of situation to use Service bus or some sort of message queue 
                    var serviceResponse =_paymentDetailDataService.Save(cardPaymentDetail, cardPaymentStatus.Status);

                    if (cardPaymentStatus.Status == CheckOutAppConstants.PaymentStatus.Accepted)
                    {
                        return Redirect(merchantConfigs.SuccessRedirectPageUrl);
                    }
                    else if (cardPaymentStatus.Status == CheckOutAppConstants.PaymentStatus.Declined)
                    {
                        return Redirect(merchantConfigs.DeclinedRedirectPageUrl);
                    }
                }
            }

            return View(cardPaymentDetail);
        }
    }
}
