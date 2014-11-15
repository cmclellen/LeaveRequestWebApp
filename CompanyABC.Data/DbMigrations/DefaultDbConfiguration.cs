using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;
using System.Linq;

namespace CompanyABC.Data.DbMigrations
{
    public class DefaultDbConfiguration : DbConfiguration
    {
        public DefaultDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0"));

            SetProviderServices("System.Data.SqlServerCe.4.0", SqlCeProviderServices.Instance);

            SetMigrationSqlGenerator("System.Data.SqlServerCe.4.0", () => new SqlCeMigrationSqlGenerator());
        }
    }
}