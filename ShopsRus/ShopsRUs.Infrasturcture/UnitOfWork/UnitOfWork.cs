using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Domain.Repositories;
using ShopsRUs.Domain.UnitOfWork;
using ShopsRUs.Infrastructure.Repositories;
using ShopsRUs.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopsRUsDbContext _dbContext;
        private IDiscountRepository discountRepository;
        public IGenericRepository<Customer> CustomerRepository { get; set; }

        public UnitOfWork(ShopsRUsDbContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepository = new GenericRepository<Customer>(_dbContext);
        }


        public IDiscountRepository DiscountRepository
        {
            get { return discountRepository = discountRepository ?? new DiscountRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
