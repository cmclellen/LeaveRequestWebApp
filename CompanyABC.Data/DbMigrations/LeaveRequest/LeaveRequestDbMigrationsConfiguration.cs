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
                    new Reason {Name = "Annual"},
                    new Reason {Name = "Parental"},
                    new Reason {Name = "Personal"},
                    new Reason {Name = "Compassionate"},
                });

                UserRole nonManagerUserRole, managerUserRole;
                context.UserRoles.AddRange(new[]
                {
                    nonManagerUserRole = new UserRole {Name = "NonManager"},
                    managerUserRole = new UserRole {Name = "Manager"},
                });

                context.Users.AddRange(new[]
                {
                    new User {Username = "NonManager1", UserRole = nonManagerUserRole},
                    new User {Username = "NonManager2", UserRole = nonManagerUserRole},
                    new User {Username = "Manager1", UserRole = managerUserRole},
                    new User {Username = "Manager2", UserRole = managerUserRole},
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