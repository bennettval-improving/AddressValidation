using System.Threading.Tasks;
using AddressValidation.Interfaces;
using AddressValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressValidation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IValidateAddresses _addressValidationService;

        public AddressController(IValidateAddresses addressValidationService)
        {
            _addressValidationService = addressValidationService;
        }

        [HttpPost]
        [Route("address/validate")]
        public async Task<IActionResult> Validate([FromBody] Address address)
        {
            var addressValidationResponse = await _addressValidationService.ValidateAddressAsync(address);
            if (addressValidationResponse == null) return BadRequest(); // change this to have message
            return Ok(addressValidationResponse);
        }
    }
}
