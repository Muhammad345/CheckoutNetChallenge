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

        public CheckoutPaymentGatewayAPIContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=checkOut_Dev;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
            }
        }

        public CheckoutPaymentGatewayAPIContext (DbContextOptions<CheckoutPaymentGatewayAPIContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<CardDetail> CardDetail { get; set; }
    }
}
