using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;

namespace CompanyABC.Data.DbMigrations
{
    public class CustomSqlServerCEMigrationSqlGenerator : System.Data.Entity.SqlServerCompact.SqlCeMigrationSqlGenerator
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
                // TODO: Due to limitations of SqlCE, can't use GetUtcDate() - if used across timezones, this would be required, so SqlCE would be unsuitable
                column.DefaultValueSql = "GETDATE()";
            }
        }
    }
}