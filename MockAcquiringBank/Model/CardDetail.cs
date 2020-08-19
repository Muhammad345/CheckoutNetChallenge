using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAcquiringBankAPI.Model
{
    public class CardDetail
    {
        [JsonProperty("externalRefId")]
        public Guid ExternalRefId { get; set; }

        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }
       
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("cardExpiry_Month")]
        public string CardExpiry_Month { get; set; }

        [JsonProperty("cardExpiry_Year")]
        public string CardExpiry_Year { get; set; }

        [JsonProperty("cvv")]
        public string CVV { get; set; }
    }
}
