using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Relateds
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid RelatedToProductId { get; set; }

    }
}
