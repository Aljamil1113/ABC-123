# ABC-123
ABC-123 Payment Provider


# NOTES:
# Database Firts ASP.NET Core Command

Scaffold-DbContext "Server=DESKTOP-KGQRUI1;Database=Payment123;Trusted_Connection=True;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

# OR

dotnet ef dbcontext scaffold "Server=DESKTOP-KGQRUI1;Database=Payment123;Trusted_Connection=True;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models
