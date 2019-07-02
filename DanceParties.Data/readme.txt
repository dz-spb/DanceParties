How to generate entities and context: 
menu Tools->NuGet Package Manager->Package Manager Console->execute command
Scaffold-DbContext "Server=<path_to_server>;Database=DanceParties;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -project DanceParties.Data -Force