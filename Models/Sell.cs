using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobiles_MVC.Models
{
    public class Sell
    {

        public int id { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }

        public int StaffsId { get; set; }
        public Staffs Staffs { get; set; }
    }
}
