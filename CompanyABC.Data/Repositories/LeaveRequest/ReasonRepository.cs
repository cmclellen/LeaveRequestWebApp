﻿using System;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;

namespace CompanyABC.Data.Repositories.LeaveRequest
{
    public class ReasonRepository : BaseRepository<ILeaveRequestContext, Reason>, IReasonRepository
    {
        public ReasonRepository(ILeaveRequestContext dbContext)
            : base(dbContext)
        {
        }
    }
}