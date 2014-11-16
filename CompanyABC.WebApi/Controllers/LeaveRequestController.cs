using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;

using CompanyABC.Core.Config;
using CompanyABC.Core.Email;
using CompanyABC.Core.Mappers;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;
using CompanyABC.WebApi.DTOs.Responses;

using Utils;

namespace CompanyABC.WebApi.Controllers
{
    [AllowAnonymous]
    public class LeaveRequestController : ApiController
    {
        public LeaveRequestController(IApplicationSettings applicationSettings, IMapper mapper, IEmailSender emailSender,
            IReasonRepository reasonRepository, IUserRepository userRepository, IUserRoleRepository userRoleRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            Guard.NotNull(() => emailSender, emailSender);
            Guard.NotNull(() => mapper, mapper);
            Guard.NotNull(() => applicationSettings, applicationSettings);
            Guard.NotNull(() => userRepository, userRepository);
            Guard.NotNull(() => reasonRepository, reasonRepository);
            Guard.NotNull(() => userRoleRepository, userRoleRepository);
            Guard.NotNull(() => leaveRequestRepository, leaveRequestRepository);

            Mapper = mapper;
            ApplicationSettings = applicationSettings;
            EmailSender = emailSender;

            // Repositories
            UserRepository = userRepository;
            ReasonRepository = reasonRepository;
            UserRoleRepository = userRoleRepository;
            LeaveRequestRepository = leaveRequestRepository;
        }

        private IEmailSender EmailSender { get; set; }
        private IUserRepository UserRepository { get; set; }
        private IMapper Mapper { get; set; }
        private IUserRoleRepository UserRoleRepository { get; set; }
        private IReasonRepository ReasonRepository { get; set; }
        private ILeaveRequestRepository LeaveRequestRepository { get; set; }
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
        public IHttpActionResult GetUserRoles()
        {
            IEnumerable<UserRole> userRoles = UserRoleRepository.GetAll();
            return Ok(userRoles);
        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            IEnumerable<User> allUsers = UserRepository.GetAll();
            return Ok(allUsers);
        }

        [HttpPost]
        public IHttpActionResult SaveLeaveRequests(IList<LeaveRequest> leaveRequests)
        {
            Guard.NotNull(() => leaveRequests, leaveRequests);
            leaveRequests = LeaveRequestRepository.Save(leaveRequests).ToList();
            var mailMessages = GetMailMessages(leaveRequests).ToList();
            EmailSender.SendMessages(mailMessages);
            return Ok();
        }

        // TODO: To be refactored using templating engine (e.g. Razor) to generate body of email
        private IEnumerable<MailMessage> GetMailMessages(IEnumerable<LeaveRequest> leaveRequests)
        {
            Guard.NotNull(() => leaveRequests, leaveRequests);

            var userIds = leaveRequests.Select(request => request.UserId);
            IList<User> users = UserRepository.GetByIds(userIds).ToList();
            
            foreach (var leaveRequest in leaveRequests)
            {
                var foundUser = users.Single(user => user.Id == leaveRequest.UserId);
                var message = new MailMessage
                {
                    Subject = string.Format("Leave Request Notification from {0}", foundUser.Username),
                    Body = string.Format("A leave request for {0} awaits your approval.", foundUser.Username)
                };
                message.To.Add(new MailAddress("cmclellen@gmail.com"));
                yield return message;
            }
        }
    }
}