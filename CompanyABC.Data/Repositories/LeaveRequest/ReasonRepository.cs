using System;
using System.Collections.Generic;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class ReasonRepository : BaseRepository<ILeaveRequestContext>, IReasonRepository
    {
        public ReasonRepository(ILeaveRequestContext leaveRequestContext)
            : base(leaveRequestContext)
        {
        }

        public IEnumerable<Reason> GetAll()
        {
            return DbContext.Reasons;
        }
    }
}