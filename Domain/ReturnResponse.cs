using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReturnResponse
    {
        public bool? IsSuccess { get; set; }

        public string Code { get; set; }

        public int NewInt { get; set; }

        public Status Status { get; set; }

        public string Message { get; set; }
    }   
    public enum Status
    {
        Success,
        Error,

    }
}
