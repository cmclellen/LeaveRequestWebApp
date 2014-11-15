using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using CompanyABC.Core.Config;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;
using CompanyABC.WebApi.DTOs.Responses;

using Utils;
using CompanyABC.Core.Mappers;

namespace CompanyABC.WebApi.Controllers
{
    [AllowAnonymous]
    public class LeaveRequestController : ApiController
    {
        public LeaveRequestController(IApplicationSettings applicationSettings, IMapper mapper, IReasonRepository reasonRepository)
        {
            Guard.NotNull(() => applicationSettings, applicationSettings);
            Guard.NotNull(() => reasonRepository, reasonRepository);
            Guard.NotNull(() => mapper, mapper);
            
            Mapper = mapper;
            ApplicationSettings = applicationSettings;
            ReasonRepository = reasonRepository;
        }

        IMapper Mapper { get; set; }
        private IReasonRepository ReasonRepository { get; set; }
        private IApplicationSettings ApplicationSettings { get; set; }

        [HttpGet]
        public IHttpActionResult GetReasons()
        {
            IEnumerable<Reason> reasons = ReasonRepository.GetAll();
            var response = new GetReasonsResponse
            {
                Reasons = reasons.Select(reason=>Mapper.Map<Reason, DTOs.Reason>(reason)).ToList()
            };
            return Ok(response);
        }
    }
}