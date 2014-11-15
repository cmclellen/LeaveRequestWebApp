using System;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.DbMigrations;

namespace CompanyABC.Data.Contexts
{
    [DbConfigurationType(typeof(DefaultDbConfiguration))]
    public class LeaveRequestContext : DbContext
    {
        public LeaveRequestContext()
            : base("name=CompanyABC")
        {
            
        }

        public DbSet<Reason> Reasons { get; set; }
    }
}