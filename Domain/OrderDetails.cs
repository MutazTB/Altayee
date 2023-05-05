using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetails
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Orders Orders { get; set; }

        public Guid ProductId { get; set; }

        public Products Products { get; set; }

        public int ProductQuantity { get; set; }

        public double UnitPrice { get; set; }


    }
}
