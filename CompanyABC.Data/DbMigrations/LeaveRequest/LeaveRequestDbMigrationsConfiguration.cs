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
                context.LeaveRequestStatuses.AddRange(new[]
                {
                    new LeaveRequestStatus {Name = "Approved"},
                    new LeaveRequestStatus {Name = "Rejected"},
                });
                context.SaveChanges();
                
                context.Reasons.AddRange(new[]
                {
                    new Reason {Name = "Annual"},
                    new Reason {Name = "Parental"},
                    new Reason {Name = "Personal"},
                    new Reason {Name = "Compassionate"},
                });
                context.SaveChanges();

                UserRole nonManagerUserRole, managerUserRole;
                context.UserRoles.AddRange(new[]
                {
                    nonManagerUserRole = new UserRole {Name = "NonManager"},
                    managerUserRole = new UserRole {Name = "Manager"},
                });
                context.SaveChanges();

                User manager1;
                context.Users.AddRange(new[]
                {
                    manager1 = new User {Username = "Manager1", UserRole = managerUserRole, EmailAddress = "Manager1@CompanyABC.com"},
                    new User {Username = "NonManager1", UserRole = nonManagerUserRole, ManagerUser = manager1, EmailAddress = "NonManager1@CompanyABC.com"},
                    new User {Username = "NonManager2", UserRole = nonManagerUserRole, ManagerUser = manager1, EmailAddress = "NonManager2@CompanyABC.com"},
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