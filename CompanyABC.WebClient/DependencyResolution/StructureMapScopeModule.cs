using System;
using System.Linq;
using System.Web;

using CompanyABC.WebClient.App_Start;

using StructureMap.Web.Pipeline;

namespace CompanyABC.WebClient.DependencyResolution
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }
    }
}