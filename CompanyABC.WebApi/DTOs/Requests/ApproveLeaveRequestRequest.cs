using System;
using System.Linq;

namespace CompanyABC.WebApi.DTOs.Requests
{
    public class ApproveLeaveRequestRequest
    {
        public int LeaveRequestId { get; set; }
        public int LeaveRequestStatusId { get; set; }
    }
}