using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Types
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Guid ProductId { get; set; }

        public Products Products { get; set; }
    }
}
