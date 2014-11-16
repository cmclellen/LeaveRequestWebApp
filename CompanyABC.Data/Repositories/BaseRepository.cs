using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CompanyABC.Data.Contexts.Contracts;

using Utils;
using CompanyABC.Data.Models;

namespace CompanyABC.Data.Repositories
{
    public abstract class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>, IDisposable
        where TDbContext : class, IDbContext
        where TEntity : class, IAuditableEntity
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

        protected DbSet<TEntity> Set
        {
            get { return DbContext.Set<TEntity>(); }
        } 

        public IEnumerable<TEntity> GetAll()
        {
            return Set;
        }

        public IEnumerable<TEntity> GetByIds(IEnumerable<int> entityIds)
        {
            return Set.Where(entity => entityIds.Contains(entity.Id));
        }

        public IEnumerable<TEntity> Save(IEnumerable<TEntity> entities)
        {
            entities = Set.AddRange(entities);
            DbContext.SaveChanges();
            return entities;
        }
    }
}