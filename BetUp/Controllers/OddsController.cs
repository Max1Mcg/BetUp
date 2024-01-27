using Microsoft.AspNetCore.Mvc;

namespace WebApiBetsBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OddsController : ControllerBase
    {
        public OddsController()
        {

        }

        [Route("[action]")]
        [HttpGet]
        public async Task<string> GetOdds()
        {
            var baseAddress = "https://egamingbet.net/bets?active=true&st=0&ut=0";
            var sharedClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
            sharedClient.DefaultRequestHeaders.Add("Accept", "application/json");
            sharedClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            sharedClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            sharedClient.DefaultRequestHeaders.Add("Host", "egamingbet.net");
            //sharedClient.DefaultRequestHeaders.Add("Cookie", "_egb_session=eERMbXJHZEhFZDZrdGk4dWNvZ0kwZnNZY0cyTUJFRTJlSTVVOGhSaTVEcW9kVTdVVE1KZDduUllNdUFOYmpxc3Y3VlFrQldpMjFlYisxNUhSaXZPeHJiLytYWUdwMzRFbGZMbWN1T0NYMWJmdWdUMEpwaVhRZndSajRDYUJ5cHM1UnZPakplSEpOZyt4M1JUdy96M1RnODhHWmY2eDR1R3hRWlM2c0tmNmp6ZnVha3dOc2VPQ2xMeEcwVWhac3ZOVVJuS3lnT0NtTTZaNlcvcGtaV090THRNM2dQUjRLTElRblVhNGZQM1h2MUc3T0hZZ3hNaG5aSU9ScGljTitkc0NDYlJrOHNmalZjOTdkaWIzYzVzbXc5M3dMeUJaN3NVYjlqM1hxOXczMCtzOENlbmk0R1A1RUVlMFdGZWtGT2hCTTZieEN1S2xMeVArQXE1M1Voc1RBPT0tLTk0YVdpd0IycnZsZEJPYkhwM2tCUUE9PQ%3D%3D--2cf0b1535e943054a31310ff1eaa4e5f46fa163b; cloudflare_uid=MoEbA1oyg--Kfy32CRSeYx-2QaPSbFyyGN2azc4j; is_first_time=1; referer=");
            //sharedClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            return await sharedClient.GetAsync("baseAddress").Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
        [Route("test")]
        [HttpGet]
        public async Task<string> GetTest()
        {
            var baseAddress = "http://ip.jsontest.com/?callback=showMyIP";
            var sharedClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
            //sharedClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return await sharedClient.GetAsync("baseAddress").Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
    }
}