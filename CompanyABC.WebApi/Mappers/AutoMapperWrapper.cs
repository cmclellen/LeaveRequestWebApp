using CompanyABC.Core.Mappers;
using System;
using System.Linq;

using CompanyABC.Data.Models.LeaveRequest;

namespace CompanyABC.WebApi.Mappers
{
    public class AutoMapperWrapper : IMapper
    {
        public AutoMapperWrapper()
        {
            ConfigureMappings();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        private void ConfigureMappings()
        {
            AutoMapper.Mapper.CreateMap<Reason, DTOs.Reason>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination = default(TDestination))
        {
            return AutoMapper.Mapper.Map(source, destination);
        }
    }
}