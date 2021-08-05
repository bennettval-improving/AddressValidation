using System.Net.Http;
using System.Threading.Tasks;
using AddressValidation.Interfaces;

namespace AddressValidation.Services
{
    public class HttpService : IMakeHttpCalls
    {
        public HttpService() { }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                return response;
            }
        }
    }
}
