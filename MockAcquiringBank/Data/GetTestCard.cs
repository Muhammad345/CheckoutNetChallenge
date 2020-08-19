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
                 CardNumer = "123",
                  Balance = 50200,
                  Id = 1
                },
                new MockCard{
                 CardNumer = "122",
                  Balance = 74545454,
                  Id = 2
                }

            };
        }
        public MockCard GetCard(string cardNumber)
        {
            if(string.IsNullOrWhiteSpace(cardNumber))
             return  ValidCard.Find(x => x.CardNumer.Contains(cardNumber));

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
