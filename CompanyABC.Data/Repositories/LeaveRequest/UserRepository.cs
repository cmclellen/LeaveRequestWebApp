using System;
using System.Collections.Generic;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class UserRepository : BaseRepository<ILeaveRequestContext>, IUserRepository
    {
        public UserRepository(ILeaveRequestContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return DbContext.Users;
        }
    }
}