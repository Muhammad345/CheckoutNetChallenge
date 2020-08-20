using CheckOutCore.AcquiringSettings;
using CheckOutRepository.Context;
using CheckOutRepository.Model;
using Microsoft.Extensions.Options;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PaymentHistoryRepository : BaseRepo, IRepository<PaymentHistory>
    {         
        public PaymentHistoryRepository(CheckoutPaymentGatewayAPIContext context)
        {
            _context = context;
        }

        public void Delete(object id)
        {
            var entity = _context.PaymentHistory.Find(id);
            _context.PaymentHistory.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<PaymentHistory> GetAll()
        {
            return _context.PaymentHistory.ToList();
        }

        public PaymentHistory GetById(object id)
        {
            var entity = _context.PaymentHistory.Find(id);
            return entity;
        }

        public int Insert(PaymentHistory obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

            return obj.Id;
        }

        public void Update(PaymentHistory obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
