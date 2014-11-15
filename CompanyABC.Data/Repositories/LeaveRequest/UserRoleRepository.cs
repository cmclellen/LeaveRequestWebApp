using System;
using System.Collections.Generic;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class UserRoleRepository : BaseRepository<ILeaveRequestContext>, IUserRoleRepository
    {
        public UserRoleRepository(ILeaveRequestContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<UserRole> GetAll()
        {
            return DbContext.UserRoles;
        }
    }
}