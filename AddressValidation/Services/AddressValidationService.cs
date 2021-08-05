using System;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using AddressValidation.Interfaces;
using AddressValidation.Models;

namespace AddressValidation.Services
{
    public class AddressValidationService : IValidateAddresses
    {
        private readonly string _uspsUserId;
        private readonly string _uspsUrl;
        private readonly IMakeHttpCalls _httpClient;

        public AddressValidationService(IMakeHttpCalls httpClient)
        {
            _uspsUserId = Environment.GetEnvironmentVariable("USPS_USERID");
            _uspsUrl = Environment.GetEnvironmentVariable("USPS_URL");
            _httpClient = httpClient;
        }

        public async Task<AddressValidationResponse> ValidateAddressAsync(Address address)
        {
            // refactor to use object instead of string
            var xml = $@"<AddressValidateRequest USERID='{_uspsUserId}'> 
                        <Revision> 1 </Revision>
                        <Address ID = '0'>
                        <Address1>{address.Line2}</Address1>
                        <Address2>{address.Line1}</Address2>
                        <City>{address.City}</City>
                        <State>{address.State}</State>
                        <Zip5>{address.PostalCode}</Zip5>
                        <Zip4 />
                        </Address>
                        </AddressValidateRequest>";
            var encodedXML = HttpUtility.UrlEncode(xml);

            var response = await _httpClient.GetAsync($"{_uspsUrl}?API=VERIFY&XML={encodedXML}");
            var contentStream = await response.Content.ReadAsStreamAsync();

            // deserialize xml instead
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AddressValidateResponseXML));
            AddressValidateResponseXML addressValidateResponse = xmlSerializer.Deserialize(contentStream) as AddressValidateResponseXML;

            return new AddressValidationResponse(addressValidateResponse);
        }
    }
}
