using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Entities
{
    public class CustomerType : BaseEntity
    {
        [Required] 
        public string Type { get; set; }

        public Discount Discount { get; set; }
    }
}
