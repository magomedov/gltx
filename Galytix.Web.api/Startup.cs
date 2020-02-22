using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Galytix.Compute;
using Galytix.Compute.Interfaces;
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
            var config = new HttpConfiguration();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "server/api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            
            SwaggerConfig.Register(config);


            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.Register<GwpRecordsCsvLoader>(x => new GwpRecordsCsvLoader("Data\\gwpByCountry.csv")).As<IGwpRecordsProvider>();
            builder.RegisterType<GwpService>().As<IGwpService>();
            builder.RegisterType<DefaultParametersConfigProvider>().As<IComputationalParametersProvider>();
            builder.RegisterType<GrowthRateCalculator>().As<IGrowthRateCalculator>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}