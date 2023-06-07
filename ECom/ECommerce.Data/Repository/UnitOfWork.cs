using ECommerce.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext dbContext;

        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
            CategoryRepository = new CategoryRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
