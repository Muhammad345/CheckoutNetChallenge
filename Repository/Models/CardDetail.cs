using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutRepository.Model
{
    public class CardDetail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardNumer { get; set; }
        public string CardExpiry_Month { get; set; }
        public string CardExpiry_Year { get; set; }
        public string CVV { get; set; }
    }
}
