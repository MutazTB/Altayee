using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Orders
    {
        public Guid Id { get; set; }               

        public List<OrderDetails> OrderDetails { get; set; }

        public double TotalPrice { get; set; }

        public int Status { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
    }

    public enum OrderStatus
    {
        Rejected = 1,
        Pending = 2,
        Completed = 3
    }
}
