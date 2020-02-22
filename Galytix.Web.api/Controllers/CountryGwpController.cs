using System.Collections.Generic;
using System.Web.Http;

namespace galytix.web.api.Controllers
{
    public class CountryGwpController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new List<string> { "xxx", "yyy", "zzz" };
        }
    }
}