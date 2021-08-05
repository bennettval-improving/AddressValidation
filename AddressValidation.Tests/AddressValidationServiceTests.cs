using AddressValidation.Models;
using AddressValidation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressValidation.Tests
{
    [TestClass]
    public class AddressValidationServiceTests
    {
        [TestMethod]
        public void AddressValidationService_ValidateAddress_ShouldDoSomething()
        {
            // arrange
            var address = new Address();
            var target = new AddressValidationService();

            // act
            var result = target.ValidateAddressAsync(address);

            // assert
        }
    }
}
