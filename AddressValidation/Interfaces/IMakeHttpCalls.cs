using System.Net.Http;
using System.Threading.Tasks;

namespace AddressValidation.Interfaces
{
    public interface IMakeHttpCalls
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
