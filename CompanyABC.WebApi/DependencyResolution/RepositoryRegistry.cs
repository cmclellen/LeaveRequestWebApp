using System;
using System.Linq;

using CompanyABC.Data.Contexts;
using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Repositories.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace CompanyABC.WebApi.DependencyResolution
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            ConfigureRepositories();
            ConfigureDbContexts();
        }

        private void ConfigureDbContexts()
        {
            For<ILeaveRequestContext>().HttpContextScoped().Use<LeaveRequestContext>();
        }

        private void ConfigureRepositories()
        {
            For<IReasonRepository>().Use<ReasonRepository>();
        }
    }
}