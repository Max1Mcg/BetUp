using System.Net;

namespace BetUp.Services.IServices
{
    public interface IRequestService
    {
        public Task<string> GetResponseDataAsync(string baseUrl);
    }
}
