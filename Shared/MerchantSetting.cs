using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class MerchantSetting
    {
        public string Url { get; set; }
        public string SuccessFullUrl { get; set; }
        public string DeclinedUrl { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
    }
}
