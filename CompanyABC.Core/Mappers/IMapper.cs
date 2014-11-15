using System;
using System.Linq;

namespace CompanyABC.Core.Mappers
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination = default(TDestination));
    }
}