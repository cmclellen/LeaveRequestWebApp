using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyABC.WebClient.Startup))]
namespace CompanyABC.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
