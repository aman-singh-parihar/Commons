using ECommerce.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ECommerceDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _dbSet.AddRange(items);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter).AsQueryable();
            }
            if (includeProperties != null)
            {
                foreach (var include in includeProperties.Split(",", StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(include);
                }
                return query.ToList();
            }
            return query.ToList();

        }

        public T? GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _dbSet.UpdateRange(items);
        }
    }
}
