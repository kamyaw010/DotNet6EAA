# Fork from EnLabSoftware's HRManagement
*A SOLID+DDD based .net framework migrated to .NET 6 based on EnLabSoftware's HRManagement template
### Author: Michael Leung from Hong Kong
## Intro
I have a SOLID+DDD+Specflow based .net framework and would like to migrate to .NET 6. I selected EnLabSoftware's HRManagement template as the base for migration. I refactor the solution to align with the original .net framework and add EF Migration & SpecFlow test project.

## Step to run
* First, View, SQL Server Object Explorer and note down your SQL server instance name e.g. <br>(localdb)\\ProjectsV13
* Replace the SQL server instance in API project's appsettings.json file e.g. <br> "DDDConnectionString": "Server=(localdb)\\ProjectsV13;Database=DDDSample;Trusted_Connection=True;MultipleActiveResultSets=true"
* Build the project, ensure all 6 success
* cd DOS to current folder "Data"
* Create first migration:<br>dotnet ef migrations add ver2 --context Data.EF.EFContext --startup-project ..\API\P1.API.csproj
* Create DB: <br>dotnet ef database update  --startup-project ..\API\P1.API.csproj

## Changes to made EF Migration work
* public abstract class RootEntity
* return services.AddDbContext<EFContext>(options => <br> options.UseSqlServer(configuration.GetConnectionString("DDDConnectionString"), b => b.MigrationsAssembly("Data")));
* modelBuilder.Ignore<RootEntity>().Ignore<BaseDomainEvent>();

## More EF Migration commmands
* dotnet ef migrations remove --context Data.EF.EFContext --startup-project ..\API\P1.API.csproj
* dotnet ef migrations script --context Data.EF.EFContext --startup-project ..\API\P1.API.csproj --output Migrations\script.sql