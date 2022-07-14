using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Entities
{
        public class Invoice : BaseEntity
        {
            [Required]  
            public string Number { get; set; }

            [Required]
            public decimal TotalAmount { get; set; }
            [Required]
            public decimal DiscountedTotalAmount { get; set; }
            [Required]
            public int CustomerId { get; set; }


            [ForeignKey("CustomerId")]
            public Customer Customer { get; set; }
        }
    
}
