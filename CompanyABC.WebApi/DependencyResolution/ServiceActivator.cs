using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

using CompanyABC.WebApi.App_Start;

using StructureMap;

namespace CompanyABC.WebApi.DependencyResolution
{
    public class ServiceActivator : IHttpControllerActivator
    {
        public ServiceActivator(HttpConfiguration configuration)
        {
        }

        private IContainer Container
        {
            get { return StructuremapMvc.StructureMapDependencyScope.Container; }
        }

        public IHttpController Create(HttpRequestMessage request
            , HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = Container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}