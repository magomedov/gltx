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
        public IHttpActionResult Peers(string country, string lineOfBusiness, int numberOfPeers)
        {
            var result = _gwpService.GetPeers(country, lineOfBusiness, numberOfPeers);
            return Ok(result);
        }
    }
}