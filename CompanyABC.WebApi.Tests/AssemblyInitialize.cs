using System;
using System.Linq;

using CompanyABC.WebApi.Mappers;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompanyABC.Core.Mappers;

namespace CompanyABC.WebApi.Tests
{   
    [TestClass]
    public class AssemblyInitialize
    {
        internal static IMapper Mapper;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Mapper = new AutoMapperWrapper();
        }
    }
}