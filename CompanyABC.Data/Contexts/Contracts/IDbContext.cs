using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CompanyABC.Data.Contexts.Contracts
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() 
            where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) 
            where TEntity : class;
        int SaveChanges();
    }
}