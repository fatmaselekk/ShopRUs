using ShopsRUs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Model
{
    public class InvoiceRequestModel
    {
        public int CustomerId { get; set; }

        public List<InvoiceProductRequestModel> ProductList{ get; set; }

    }
}
