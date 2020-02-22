using System.Collections.Generic;
using System.Web.Http;
using Galytix.Services.Interfaces;

namespace galytix.web.api.Controllers
{
    [RoutePrefix("server/api/gwp")]
    public class CountryGwpController : ApiController
    {
        private readonly IGwpService _gwpService;

        public CountryGwpController(IGwpService gwpService)
        {
            _gwpService = gwpService;
        }

        [Route("peers")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var jopa = _gwpService.DoSomething();
            return new List<string> { "xxx", "yyy", "zzz", jopa };
        }
    }
}