using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetFirst8();
        T GetById(int id);
        void Create(T item);
        void Update(T id);
        void Remove(int id);
    }

}
