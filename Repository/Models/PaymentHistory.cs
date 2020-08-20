using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutRepository.Model
{
    public class PaymentHistory
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("cardDetailId")]
        public int CardDetailId { get; set; }

        [JsonProperty("externalRefId")]
        public Guid ExternalRefId { get; set; }

        [JsonProperty("amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
