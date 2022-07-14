using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDiscountRepository DiscountRepository { get; }
        IGenericRepository<Customer> CustomerRepository{ get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
