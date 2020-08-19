using CheckOutRepository.Context;
using CheckOutRepository.Model;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class MerchantConfigRepository : BaseRepo, IRepository<MerchantConfig>
    {
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
             DeclinedRedirectPageUrl = "https://www.chargebee.com/blog/making-sense-credit-card-declines/",
             SuccessRedirectPageUrl = "https://dribbble.com/shots/5902176-Payment-Success-page"
            };

            return tempMerchantConfig;
            // Replace with Real Database 
            //var entity =  _context.MerchantConfigs.Find(id);
            //return entity;
        }

        public void Insert(MerchantConfig obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(MerchantConfig obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
