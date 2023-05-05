using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactUs
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; }

        public string UserName { get; set; }

        public string Enquiry { get; set; }
    }
}
