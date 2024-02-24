using BetUp.Services.IServices;
using System.Net;

namespace BetUp.Services
{
    public class RequestService: IRequestService
    {
        HttpClient _sharedClient = new HttpClient(new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }, AutomaticDecompression = DecompressionMethods.GZip }) { Timeout = TimeSpan.FromSeconds(10) };
        public async Task<string> GetResponseDataAsync(string baseURL)
        {
            return await _sharedClient.GetAsync(baseURL).Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
    }
}
