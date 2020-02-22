using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Galytix.Data;
using Galytix.Data.Interfaces;
using Galytix.Services;
using Galytix.Services.Interfaces;
using Owin;

namespace Galytix.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "server/api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.Register<GwpRecordsCsvLoader>(x => new GwpRecordsCsvLoader("Data\\gwpByCountry.csv")).As<IGwpRecordsProvider>();
            builder.RegisterType<GwpService>().As<IGwpService>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}