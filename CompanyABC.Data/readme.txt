In the Package Manager Console, set the "CompanyABC.Data" project as the "Default project"
Set the "CompanyABC.WebApi" project as the startup project

Add-Migration -Force Initial -ConfigurationTypeName LeaveRequestDbMigrationsConfiguration

update-database -ConfigurationTypeName LeaveRequestDbMigrationsConfiguration