using System;
using System.Linq;

namespace CompanyABC.WebApi.DTOs
{
    public class LeaveRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReasonId { get; set; }
        public string Comment { get; set; }
    }
}