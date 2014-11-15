using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyABC.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Save(IEnumerable<T> entities);
    }
}