using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

using CompanyABC.Core.Config;
using CompanyABC.WebApi.Controllers;
using CompanyABC.WebApi.DTOs.Responses;
using CompanyABC.WebApi.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rhino.Mocks;

namespace CompanyABC.WebApi.Tests.Controllers
{
    [TestClass]
    public class LeaveRequestControllerTests
    {
        private IApplicationSettings ApplicationSettings { get; set; }
        private MockRepository Mocks { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Mocks = new MockRepository();
            ApplicationSettings = Mocks.Stub<IApplicationSettings>();
        }

        [TestMethod]
        public void GetReasons_RetrievalOf_AllReasonsToBeReturned()
        {
            // ARRANGE
            var controller = new LeaveRequestController(ApplicationSettings);

            // ACT
            Mocks.ReplayAll();
            var getReasonsResponse = controller.GetReasons() as OkNegotiatedContentResult<GetReasonsResponse>;

            // ASSERT
            Mocks.VerifyAll();
            var expected = new List<Reason>(new[]
            {
                new Reason {DisplayName = "Annual"},
                new Reason {DisplayName = "Personal"},
                new Reason {DisplayName = "Compassionate"},
                new Reason {DisplayName = "Parental"},
            });
            List<Reason> actual = getReasonsResponse.Content.Reasons.ToList();
            CollectionAssert.AreEqual(expected, actual, "Expected reasons not returned.");
        }
    }
}