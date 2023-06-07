using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T? GetById(int? id);
        IEnumerable<T> GetAll(Func<T, bool> filter = null,string ? includeProperties = null);
        void AddRange(IEnumerable<T> items);
        void UpdateRange(IEnumerable<T> items);
        void DeleteRange(IEnumerable<T> items);

    }
}
