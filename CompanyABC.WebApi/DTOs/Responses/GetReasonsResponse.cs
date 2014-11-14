using System;
using System.Collections.Generic;
using System.Linq;

using CompanyABC.WebApi.Models;

namespace CompanyABC.WebApi.DTOs.Responses
{
    public class GetReasonsResponse
    {
        public IList<Reason> Reasons { get; set; }
    }
}