using System;
using System.Linq;

using CompanyABC.Data.Contexts;
using CompanyABC.Data.Helpers;
using CompanyABC.Data.Models.LeaveRequest;
using System.Data.Entity.Validation;

namespace CompanyABC.Data.DbMigrations.LeaveRequest
{
    public class LeaveRequestDbMigrationsConfiguration : BaseDbMigrationsConfiguration<LeaveRequestContext>
    {
        public LeaveRequestDbMigrationsConfiguration() : base("LeaveRequest")
        {
        }

        protected override void Seed(LeaveRequestContext context)
        {
            base.Seed(context);

            try
            {
                context.Reasons.AddRange(new[]
                {
                    new Reason {DisplayName = "Annual"},
                    new Reason {DisplayName = "Parental"},
                    new Reason {DisplayName = "Personal"},
                    new Reason {DisplayName = "Compassionate"},
                });

                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex.AddDetails();
            }
        }
    }
}