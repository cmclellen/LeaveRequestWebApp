using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyABC.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetByIds(IEnumerable<int> entityIds);
        IEnumerable<T> GetAll();
        IEnumerable<T> Save(IEnumerable<T> entities);
    }
}