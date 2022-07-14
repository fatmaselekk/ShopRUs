using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Entities
{
    public class Discount : BaseEntity
    {
        [Required] 
        public decimal Percentage { get; set; }

        [Required]
        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }
    }
}
