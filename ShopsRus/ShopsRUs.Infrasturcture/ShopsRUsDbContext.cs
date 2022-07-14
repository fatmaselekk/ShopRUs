using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Infrastructure
{
    public class ShopsRUsDbContext:DbContext
    {
        public ShopsRUsDbContext(DbContextOptions<ShopsRUsDbContext> options) : base(options) { }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
