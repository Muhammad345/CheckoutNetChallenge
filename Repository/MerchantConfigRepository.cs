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
    public class MerchantConfigRepository : BaseRepo, IRepository<MerchantConfig>
    {
        private readonly MerchantSetting _merchantSetting;

        public MerchantConfigRepository(IOptions<MerchantSetting> options, CheckoutPaymentGatewayAPIContext context)
        {
            _merchantSetting = options.Value;
            _context = context;
        }

        public void Delete(object id)
        {
            var entity = _context.CardDetails.Find(id);
            _context.CardDetails.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<MerchantConfig> GetAll()
        {
            return _context.MerchantConfigs.ToList();
        }

        public MerchantConfig GetById(object id)
        {
            var tempMerchantConfig = new MerchantConfig { 
             AccountId = 1, 
             ApiKey = "Api Key to access System",
             DeclinedRedirectPageUrl = _merchantSetting.DeclinedUrl,
             SuccessRedirectPageUrl = _merchantSetting.SuccessFullUrl
            };

            return tempMerchantConfig;
            // Replace with Real Database 
            //var entity =  _context.MerchantConfigs.Find(id);
            //return entity;
        }

        public int Insert(MerchantConfig obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

            return obj.Id;
        }

        public void Update(MerchantConfig obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
