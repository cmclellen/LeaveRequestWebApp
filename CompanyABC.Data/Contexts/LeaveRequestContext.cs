using System;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.DbMigrations;
using CompanyABC.Data.Models.LeaveRequest;

namespace CompanyABC.Data.Contexts
{
    [DbConfigurationType(typeof (DefaultDbConfiguration))]
    public class LeaveRequestContext : DbContext, ILeaveRequestContext
    {
        public LeaveRequestContext()
            : base("name=CompanyABC")
        {
        }

        public DbSet<Reason> Reasons { get; set; }
    }
}