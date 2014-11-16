using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class UserRepository : BaseRepository<ILeaveRequestContext, User>, IUserRepository
    {
        public UserRepository(ILeaveRequestContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<User> GetAll()
        {
            return Set.Include(s=>s.ManagerUser);
        }
    }
}