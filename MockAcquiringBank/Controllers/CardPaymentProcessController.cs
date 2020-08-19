using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAcquiringBankAPI.Data;
using MockAcquiringBankAPI.Model;

namespace MockAcquiringBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardPaymentProcessController : ControllerBase
    {
        public GetTestCard GetTestCard { get; set; }
        public CardPaymentProcessController()
        {
            GetTestCard = new GetTestCard();
        }

        [HttpGet]
        public string Get()
        {
            return "Mock Bank API Running";
        }


        // POST: api/CardPaymentProcess
        [HttpPost]
        public CardPaymentResponse Post(CardDetail cardDetail)
        {
            var foundAvailable = GetTestCard.IsEnoughFoundAvailable(cardDetail.Cardnumber);

            if(foundAvailable)
            {
                return new CardPaymentResponse
                {
                    AuthCode = "AuthCode01",
                    ExternalRefId = cardDetail.ExternalRefId,
                    Status = "Accepted"
                };
            }

            return new CardPaymentResponse
            {
                AuthCode = "AuthCode02",
                ExternalRefId = cardDetail.ExternalRefId,
                Status = "Declined"
            };
        }
    }
}
