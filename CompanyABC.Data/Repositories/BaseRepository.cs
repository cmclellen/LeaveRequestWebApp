using System;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;

using Utils;

namespace CompanyABC.Data.Repositories
{
    public abstract class BaseRepository<TDbContext> : IDisposable
        where TDbContext : class, IDbContext
    {
        protected BaseRepository(TDbContext dbContext)
        {
            Guard.NotNull(() => dbContext, dbContext);
            DbContext = dbContext;
        }

        protected TDbContext DbContext { get; set; }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
        }
    }
}