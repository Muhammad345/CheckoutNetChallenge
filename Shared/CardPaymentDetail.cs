using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class CardPaymentDetail
    {
        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("externalRefId")]
        public Guid ExternalRefId { get; set; }

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

        [JsonProperty("amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
    }
}
