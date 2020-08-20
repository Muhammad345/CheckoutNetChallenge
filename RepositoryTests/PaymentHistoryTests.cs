using CheckOutRepository.Context;
using CheckOutRepository.Model;
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    public class PaymentHistoryTests
    {
        private IRepository<PaymentHistory> _paymentHistoryRepository;
        private CheckoutPaymentGatewayAPIContext _context;

        [SetUp]
        public void Setup()
        {
            _paymentHistoryRepository = new PaymentHistoryRepository(_context);
        }

        [Test]
        public void Insert_Successfull()
        {
            Assert.Pass();
        }
    }
}