using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace CompanyABC.Data.DbMigrations
{
    public class BaseDbMigrationsConfiguration<T> : DbMigrationsConfiguration<T>
        where T : DbContext
    {
        public BaseDbMigrationsConfiguration(string contextName)
        {
            MigrationsDirectory = Path.Combine("DbMigrations", contextName);
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            //SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
            SetSqlGenerator("System.Data.SqlServerCe.4.0", new CustomSqlServerMigrationSqlGenerator());
        }
    }
}