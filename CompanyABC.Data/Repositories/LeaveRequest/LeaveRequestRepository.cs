using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class LeaveRequestRepository : BaseRepository<ILeaveRequestContext, Models.LeaveRequest.LeaveRequest>,
        ILeaveRequestRepository
    {
        public LeaveRequestRepository(ILeaveRequestContext dbContext)
            : base(dbContext)
        {
        }

        public override IEnumerable<Models.LeaveRequest.LeaveRequest> GetAll()
        {
            return Set
                .Include(entity => entity.User)
                .Include(entity => entity.LeaveRequestStatus);
        }
    }
}