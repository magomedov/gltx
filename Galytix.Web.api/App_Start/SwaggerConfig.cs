using System.Web.Http;
using WebActivatorEx;
using Galytix.Web.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Galytix.Web.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "Galytix.API"); })
                .EnableSwaggerUi(c => { });
        }
    }
}
