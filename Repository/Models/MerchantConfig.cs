using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class MerchantConfig
    {
        [Key]
        public int Id { get; set; }

        public int AccountId { get; set; }
        public string ApiKey { get; set; }

        public string SuccessRedirectPageUrl { get; set; }

        public string DeclinedRedirectPageUrl { get; set; }
    }
}
