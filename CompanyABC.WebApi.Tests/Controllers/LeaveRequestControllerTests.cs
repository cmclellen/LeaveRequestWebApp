using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

using CompanyABC.Core.Config;
using CompanyABC.Core.Email;
using CompanyABC.Core.Mappers;
using CompanyABC.Data.Models.LeaveRequest;
using CompanyABC.Data.Repositories.LeaveRequest.Contracts;
using CompanyABC.WebApi.Controllers;
using CompanyABC.WebApi.DTOs.Responses;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rhino.Mocks;

namespace CompanyABC.WebApi.Tests.Controllers
{
    [TestClass]
    public class LeaveRequestControllerTests
    {
        private IApplicationSettings ApplicationSettings { get; set; }
        private MockRepository Mocks { get; set; }
        private IMapper Mapper { get; set; }
        IEmailSender EmailSender { get; set; }
        private IReasonRepository ReasonRepository { get; set; }
        private IUserRepository UserRepository { get; set; }
        private IUserRoleRepository UserRoleRepository { get; set; }
        private ILeaveRequestRepository LeaveRequestRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Mocks = new MockRepository();
            ApplicationSettings = Mocks.Stub<IApplicationSettings>();
            Mapper = AssemblyInitialize.Mapper;
            EmailSender = Mocks.Stub<IEmailSender>();
            UserRepository = Mocks.Stub<IUserRepository>();
            ReasonRepository = Mocks.Stub<IReasonRepository>();
            UserRoleRepository = Mocks.Stub<IUserRoleRepository>();
            LeaveRequestRepository = Mocks.Stub<ILeaveRequestRepository>();
        }

        [TestMethod]
        public void GetReasons_RetrievalOf_AllReasonsToBeReturned()
        {
            // ARRANGE
            var controller = new LeaveRequestController(ApplicationSettings, Mapper, EmailSender, ReasonRepository, UserRepository,
                UserRoleRepository, LeaveRequestRepository);
            ReasonRepository.Expect(mock => mock.GetAll()).Return(new[]
            {
                new Reason {Name = "Annual"},
                new Reason {Name = "Personal"},
                new Reason {Name = "Compassionate"},
                new Reason {Name = "Parental"}
            });

            // ACT
            Mocks.ReplayAll();
            var getReasonsResponse = controller.GetReasons() as OkNegotiatedContentResult<GetReasonsResponse>;

            // ASSERT
            Mocks.VerifyAll();
            var expected = new List<DTOs.Reason>(new[]
            {
                new DTOs.Reason {Name = "Annual"},
                new DTOs.Reason {Name = "Personal"},
                new DTOs.Reason {Name = "Compassionate"},
                new DTOs.Reason {Name = "Parental"}
            });
            List<DTOs.Reason> actual = getReasonsResponse.Content.Reasons.ToList();
            CollectionAssert.AreEqual(expected, actual, "Expected reasons not returned.");
        }
    }
}