using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Entities;
using ShopsRUs.Domain.Repositories;
using ShopsRUs.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Infrastructure.Repositories
{
  
    public class DiscountRepository : GenericRepository<Customer>, IDiscountRepository
    {
        public DiscountRepository(ShopsRUsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Discount> GetByCustomerId(int customerId)
        {
            return await _appContext.Discount.Include(l => l.CustomerType).Where(l => l.CustomerTypeId == customerId)
                .FirstOrDefaultAsync();
        }
    }
}
