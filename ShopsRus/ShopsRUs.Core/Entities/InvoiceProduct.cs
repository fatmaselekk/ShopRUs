using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Entities
{
    public class InvoiceProduct : BaseEntity
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }


    }
}
