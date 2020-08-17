using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}
