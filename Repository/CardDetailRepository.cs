using CheckOutRepository.Context;
using CheckOutRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CardDetailRepository : BaseRepo, IRepository<CardDetail>
    {
        public void Delete(object id)
        {
            var cardDetail = _context.CardDetails.Find(id);
            _context.CardDetails.Remove(cardDetail);
            _context.SaveChanges();
        }

        public IEnumerable<CardDetail> GetAll()
        {
            return _context.CardDetails.ToList();
        }

        public CardDetail GetById(object id)
        {
            var cardDetail =  _context.CardDetails.Find(id);
            return cardDetail;
        }

        public void Insert(CardDetail obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(CardDetail obj)
        {
            _context.Update(obj);
            _context.SaveChangesAsync();
        }
    }
}
