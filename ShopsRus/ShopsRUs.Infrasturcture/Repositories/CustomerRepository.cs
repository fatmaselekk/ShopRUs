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
  
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopsRUsDbContext dbContext) : base(dbContext)
        {
        }

    }
}
