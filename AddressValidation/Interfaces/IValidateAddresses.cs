using System.Threading.Tasks;
using AddressValidation.Models;

namespace AddressValidation.Interfaces
{
    public interface IValidateAddresses
    {
        //Task<AddressValidationResponse> ValidateAddressAsync(Address address);
        Task<AddressValidationResponse> ValidateAddressAsync(Address address);
    }
}
