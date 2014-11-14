using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using CompanyABC.Core.Config;
using CompanyABC.WebApi.Models;

using Utils;

namespace CompanyABC.WebApi.Controllers
{
    [AllowAnonymous]
    public class LeaveRequestController : ApiController
    {
        //public LeaveRequestController(IApplicationSettings applicationSettings)
        //{
        //    Guard.NotNull(() => applicationSettings, applicationSettings);
        //    ApplicationSettings = applicationSettings;
        //}

        IApplicationSettings ApplicationSettings { get; set; }

        [HttpGet]
        public IHttpActionResult GetReasons()
        {
            IList<Reason> reasons = new[]
            {
                new Reason {DisplayName = "Annual"},
                new Reason {DisplayName = "Personal"},
                new Reason {DisplayName = "Compassionate"},
                new Reason {DisplayName = "Parental"},
            };

            return Ok(new
            {
                Reasons = reasons
            });
        }
    }
}