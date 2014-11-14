using System;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CompanyABC.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}