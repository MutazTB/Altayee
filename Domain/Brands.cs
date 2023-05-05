using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brands
    {
        public Guid Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Image { get; set; }

        public List<Products> Products { get; set; }

    }
}
