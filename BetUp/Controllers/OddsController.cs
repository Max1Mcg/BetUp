using BetUp.DbModels;
using Microsoft.AspNetCore.Mvc;
using BetUp.DbContexts;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.Json;
using System;
using BetUp.Models;

namespace WebApiBetsBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OddsController : ControllerBase
    {

        public IBaseRepository<Role> _baseRepTest;
        public OddsController(IBaseRepository<Role> baseRepTest)
        {
            _baseRepTest = baseRepTest;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<string> GetOdds()
        {
            var baseAddress = "https://line02.pb06e2-resources.com/line/desktop/topEvents3?place=live&sysId=1&lang=ru&salt=d18uahshv2lrxncnd5&supertop=4&scopeMarket=2300";
            var sharedClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
            //sharedClient.DefaultRequestHeaders.Add("Accept", "*/*");
            //sharedClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            //sharedClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            //sharedClient.DefaultRequestHeaders.Add("Host", "line02.pb06e2-resources.com");
            //sharedClient.DefaultRequestHeaders.Add("Cookie", "_egb_session=eERMbXJHZEhFZDZrdGk4dWNvZ0kwZnNZY0cyTUJFRTJlSTVVOGhSaTVEcW9kVTdVVE1KZDduUllNdUFOYmpxc3Y3VlFrQldpMjFlYisxNUhSaXZPeHJiLytYWUdwMzRFbGZMbWN1T0NYMWJmdWdUMEpwaVhRZndSajRDYUJ5cHM1UnZPakplSEpOZyt4M1JUdy96M1RnODhHWmY2eDR1R3hRWlM2c0tmNmp6ZnVha3dOc2VPQ2xMeEcwVWhac3ZOVVJuS3lnT0NtTTZaNlcvcGtaV090THRNM2dQUjRLTElRblVhNGZQM1h2MUc3T0hZZ3hNaG5aSU9ScGljTitkc0NDYlJrOHNmalZjOTdkaWIzYzVzbXc5M3dMeUJaN3NVYjlqM1hxOXczMCtzOENlbmk0R1A1RUVlMFdGZWtGT2hCTTZieEN1S2xMeVArQXE1M1Voc1RBPT0tLTk0YVdpd0IycnZsZEJPYkhwM2tCUUE9PQ%3D%3D--2cf0b1535e943054a31310ff1eaa4e5f46fa163b; cloudflare_uid=MoEbA1oyg--Kfy32CRSeYx-2QaPSbFyyGN2azc4j; is_first_time=1; referer=");
            //sharedClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            return await sharedClient.GetAsync("baseAddress").Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetOBettingMatch()
        {
            var baseAddress = "https://jsonplaceholder.typicode.com/todos/1";
            var sharedClient = new HttpClient();
            var result = await sharedClient.GetAsync(baseAddress);
            var obj = result.Content.ReadFromJsonAsync<TestResult>();
            return Ok(obj.Result);
        }

        [Route("test")]
        [HttpGet]
        public IActionResult GetTest()
        {
            /*var baseAddress = "http://ip.jsontest.com/?callback=showMyIP";
            var sharedClient = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
            };
            return await sharedClient.GetAsync("baseAddress").Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();*/
            var _context = new BetUpContext();
            var result = String.Empty;
            foreach (var role in _context.Roles)
            {
                result += role.Name.Trim() + role.Description;
            }
            return Ok(new{ result = result});
        }

        public class Data
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        [Route("test")]
        [HttpPost]
        public IActionResult PostTest(Data data)
        {
            return Ok(new { inputArg = new { x = data.x, y = data.y } });
        }

        [Route("testRepository")]
        [HttpPost]
        public IActionResult PostTest()
        {
            //br.Create(new Role { Id = Guid.NewGuid(), Name = "Admin"});
            var r = _baseRepTest.Get(new Guid("c7dac36c-620d-4bfe-9cfc-c937f26eafcc"));
            return Ok();
        }
    }
}