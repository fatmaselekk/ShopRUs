using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Customer>
    {
        Task<Discount> GetByCustomerId(int customerId);
    }
}
