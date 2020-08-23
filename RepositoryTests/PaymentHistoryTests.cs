using CheckOutRepository.Context;
using CheckOutRepository.Model;
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    public class PaymentHistoryTests
    {
        private IRepository<PaymentDetail> _paymentHistoryRepository;
        private CheckoutPaymentGatewayAPIContext _context;

        [SetUp]
        public void Setup()
        {
            _paymentHistoryRepository = new PaymentDetailRepository(_context);
        }

        [Test]
        public void Insert_Successfull()
        {
            Assert.Pass();
        }
    }
}