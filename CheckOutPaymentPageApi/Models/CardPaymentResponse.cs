using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutPaymentPageApi.Models
{
    public class CardPaymentResponse
    {
        [JsonProperty("authCode")]
        public string AuthCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("externalRefId")]
        public Guid ExternalRefId { get; set; }

    }
}
