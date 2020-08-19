using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAcquiringBankAPI.Data
{
    public class MockCard
    {
        public int Id { get; set; }
        public string CardNumer { get; set; }
        public decimal Balance { get; set; }
    }
}
