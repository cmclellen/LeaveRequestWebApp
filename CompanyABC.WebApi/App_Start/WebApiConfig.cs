using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

using CompanyABC.WebApi.DependencyResolution;

using Newtonsoft.Json.Serialization;

namespace CompanyABC.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}", new {id = RouteParameter.Optional}
                );

            config.Services
                  .Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}