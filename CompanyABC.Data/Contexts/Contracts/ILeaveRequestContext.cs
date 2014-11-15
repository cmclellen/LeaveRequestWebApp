using System;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Models.LeaveRequest;

namespace CompanyABC.Data.Contexts.Contracts
{
    public interface ILeaveRequestContext : IDbContext
    {
        DbSet<Reason> Reasons { get; set; }
    }
}