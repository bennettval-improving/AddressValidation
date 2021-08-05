using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressValidation.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string ReturnText { get; set; }
    }
}
