using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using CompanyABC.Core.Config;
using CompanyABC.Core.Mappers;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;
using CompanyABC.WebApi.DTOs;
using CompanyABC.WebApi.DTOs.Responses;

using Utils;

using Reason = CompanyABC.Data.Models.LeaveRequest.Reason;

namespace CompanyABC.WebApi.Controllers
{
    [AllowAnonymous]
    public class LeaveRequestController : ApiController
    {
        public LeaveRequestController(IApplicationSettings applicationSettings, IMapper mapper,
            IReasonRepository reasonRepository, IUserRepository userRepository)
        {
            Guard.NotNull(() => mapper, mapper);
            Guard.NotNull(() => applicationSettings, applicationSettings);
            Guard.NotNull(() => userRepository, userRepository);
            Guard.NotNull(() => reasonRepository, reasonRepository);

            Mapper = mapper;
            ApplicationSettings = applicationSettings;

            // Repositories
            UserRepository = userRepository;
            ReasonRepository = reasonRepository;
        }

        private IUserRepository UserRepository { get; set; }
        private IMapper Mapper { get; set; }
        private IReasonRepository ReasonRepository { get; set; }
        private IApplicationSettings ApplicationSettings { get; set; }

        [HttpGet]
        public IHttpActionResult GetReasons()
        {
            IEnumerable<Reason> reasons = ReasonRepository.GetAll();
            var response = new GetReasonsResponse
            {
                Reasons = reasons.Select(reason => Mapper.Map<Reason, DTOs.Reason>(reason)).ToList()
            };
            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var allUsers = UserRepository.GetAll();
            return Ok(allUsers);
        }

        [HttpPost]
        public IHttpActionResult SaveLeaveRequests(IList<LeaveRequest> leaveRequests)
        {
            Guard.NotNull(() => leaveRequests, leaveRequests);

            //ReasonRepository.Save();

            return Ok();
        }
    }
}