using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddressValidation.Models
{
    [XmlRoot("AddressValidateResponse")]
    public class AddressValidateResponseXML
    {
        public AddressXML Address { get; set; }
    }
}
