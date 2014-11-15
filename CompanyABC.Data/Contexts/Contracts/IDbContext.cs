using System;
using System.Data.Entity;
using System.Linq;

namespace CompanyABC.Data.Contexts.Contracts
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}