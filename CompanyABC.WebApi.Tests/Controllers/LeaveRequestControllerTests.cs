using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

using CompanyABC.Core.Config;
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
        private IReasonRepository ReasonRepository { get; set; }
        
        [TestInitialize]
        public void TestInitialize()
        {
            Mocks = new MockRepository();
            ApplicationSettings = Mocks.Stub<IApplicationSettings>();
            Mapper = AssemblyInitialize.Mapper;
            ReasonRepository = Mocks.Stub<IReasonRepository>();
        }

        [TestMethod]
        public void GetReasons_RetrievalOf_AllReasonsToBeReturned()
        {
            // ARRANGE
            var controller = new LeaveRequestController(ApplicationSettings, Mapper, ReasonRepository);
            ReasonRepository.Expect(mock => mock.GetAll()).Return(new[]
            {
                new Reason {DisplayName = "Annual"},
                new Reason {DisplayName = "Personal"},
                new Reason {DisplayName = "Compassionate"},
                new Reason {DisplayName = "Parental"}
            });

            // ACT
            Mocks.ReplayAll();
            var getReasonsResponse = controller.GetReasons() as OkNegotiatedContentResult<GetReasonsResponse>;

            // ASSERT
            Mocks.VerifyAll();
            var expected = new List<DTOs.Reason>(new[]
            {
                new DTOs.Reason {DisplayName = "Annual"},
                new DTOs.Reason {DisplayName = "Personal"},
                new DTOs.Reason {DisplayName = "Compassionate"},
                new DTOs.Reason {DisplayName = "Parental"}
            });
            List<DTOs.Reason> actual = getReasonsResponse.Content.Reasons.ToList();
            CollectionAssert.AreEqual(expected, actual, "Expected reasons not returned.");
        }
    }
}