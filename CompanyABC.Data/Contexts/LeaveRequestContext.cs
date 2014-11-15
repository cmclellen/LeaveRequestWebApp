using System;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Models.LeaveRequest;

namespace CompanyABC.Data.Contexts
{
    public class LeaveRequestContext : DbContext
    {
        public LeaveRequestContext()
            : base("name=CompanyABC")
        {
            
        }

        public DbSet<Reason> Reasons { get; set; }
    }
}