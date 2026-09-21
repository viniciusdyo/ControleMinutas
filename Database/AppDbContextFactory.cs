using Microsoft.EntityFrameworkCore.Design;

namespace ControleMinutas.Database;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ControleMinutas.db");
     
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
