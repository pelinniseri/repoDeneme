using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        public string Mail { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
