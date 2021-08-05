using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressValidation.Models
{
    public class AddressValidationResponse
    {
        public AddressValidationResponse(AddressValidateResponseXML xml)
        {
            MapToSelf(xml);
        }

        public Address Address { get; set; }
        public bool ErrorOccurred { get; set; }
        public string ErrorDescription { get; set; }

        private void MapToSelf(AddressValidateResponseXML xml)
        {
            if (xml != null && xml.Address != null)
            {
                if (xml.Address.Error != null)
                {
                    ErrorOccurred = true;
                    ErrorDescription = xml.Address.Error?.Description;
                }
                else
                {
                    Address = new Address
                    {
                        Line1 = xml.Address?.Address2,
                        Line2 = xml.Address?.Address1,
                        City = xml.Address?.City,
                        State = xml.Address?.State,
                        PostalCode = string.IsNullOrWhiteSpace(xml.Address?.Zip4) ? 
                            xml.Address?.Zip5 : 
                            $"{xml.Address?.Zip5}-{xml.Address?.Zip4}",
                        ReturnText = xml.Address?.ReturnText
                    };
                }
            }
        }
    }
}
