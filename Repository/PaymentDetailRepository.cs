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
    public class PaymentDetailRepository : BaseRepo, IRepository<PaymentDetail>
    {         
        public PaymentDetailRepository(CheckoutPaymentGatewayAPIContext context)
        {
            _context = context;
        }

        public void Delete(object id)
        {
            var entity = _context.PaymentHistory.Find(id);
            _context.PaymentHistory.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<PaymentDetail> GetAll()
        {
            return _context.PaymentHistory.ToList();
        }

        //public IEnumerable<PaymentDetail> GetBy(int merchantId,int accountId)
        //{
        //    return _context.PaymentHistory.Where(x=>x.MerchantId == merchantId && x.AccountId == accountId).ToList();
        //}

        public PaymentDetail GetById(object id)
        {
            var entity = _context.PaymentHistory.Find(id);
            return entity;
        }

        public int Insert(PaymentDetail obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

            return obj.Id;
        }

        public void Update(PaymentDetail obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
