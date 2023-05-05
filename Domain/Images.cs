using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Images
    {
        public Guid Id { get; set; }

        public string ImageName { get; set; }

        public Guid ProductId { get; set; }

        public Products Products { get; set; }


    }
}
