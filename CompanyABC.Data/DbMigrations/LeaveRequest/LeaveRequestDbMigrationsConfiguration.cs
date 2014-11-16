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

                User manager1, manager2;
                context.Users.AddRange(new[]
                {
                    manager1 = new User {Username = "Manager1", UserRole = managerUserRole, EmailAddress = "Manager1@CompanyABC.com"},
                    manager2 = new User {Username = "Manager2", UserRole = managerUserRole, EmailAddress = "Manager2@CompanyABC.com"},
                    new User {Username = "NonManager1", UserRole = nonManagerUserRole, ManagerUser = manager1, EmailAddress = "NonManager1@CompanyABC.com"},
                    new User {Username = "NonManager2", UserRole = nonManagerUserRole, ManagerUser = manager2, EmailAddress = "NonManager2@CompanyABC.com"},
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