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
                 CardNumer = "1234 5678 9801 1789",
                  Balance = 50200,
                  Id = 1
                }
            };
        }
        public MockCard GetCard(string cardNumber)
        {
            if(!string.IsNullOrWhiteSpace(cardNumber))
            {
                var cardInfo = ValidCard.Find(x => x.CardNumer.Contains(cardNumber, StringComparison.InvariantCultureIgnoreCase));
                return cardInfo;
            }
             

            return null;
        }

        public bool IsEnoughFoundAvailable(string cardNumber)
        {
            var mockCard = GetCard(cardNumber);

            if(mockCard?.Balance > 0)
            {
                return true;
            }

            return false;
        }


    }
}
