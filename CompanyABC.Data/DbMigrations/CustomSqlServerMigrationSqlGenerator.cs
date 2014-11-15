using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace CompanyABC.Data.DbMigrations
{
    public class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        private const string CreatedDateColumnName = "CreatedDate";

        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedDateColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedDateColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetCreatedDateColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (ColumnModel columnModel in columns)
            {
                SetCreatedDateColumn(columnModel);
            }
        }

        private static void SetCreatedDateColumn(PropertyModel column)
        {
            if (column.Name == CreatedDateColumnName)
            {
                column.DefaultValueSql = "GETDATE()";

                // TODO: if used across timezones, to use this instead - wasn't able to use because of limitations by SqlServerCE
                //column.DefaultValueSql = "GETUTCDATE()";
            }
        }
    }
}