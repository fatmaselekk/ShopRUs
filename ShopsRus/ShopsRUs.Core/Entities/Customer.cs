using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

    }
}
