using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace CheckOutRepository.Context
{
    public class CheckoutPaymentGatewayAPIContext : DbContext
    {
        public CheckoutPaymentGatewayAPIContext (DbContextOptions<CheckoutPaymentGatewayAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CardDetail> CardDetail { get; set; }
    }
}
