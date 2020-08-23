using MockAcquiringBankAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAcquiringBankAPI.Data
{
  public class GetTestCard
    {

        public List<MockCard> ValidCard { get; set; }

        public GetTestCard()
        {
            ValidCard  = new List<MockCard>
            {
                new MockCard{
                 CardNumer = "1234567898011789",
                  Balance = 50200,
                  Id = 1
                }
            };
        }
        public MockCard GetCard(string cardNumber)
        {
            if(!string.IsNullOrWhiteSpace(cardNumber))
            {
                var cardInfo = ValidCard.SingleOrDefault(x => x.CardNumer == cardNumber);

                return cardInfo;
            }
             

            return null;
        }

        public bool IsEnoughFoundAvailable(CardPaymentDetail cardDetail)
        {
            var mockCard = GetCard(cardDetail.CardNumber);

            if(mockCard?.Balance > cardDetail.Amount)
            {
                return true;
            }

            return false;
        }


    }
}
