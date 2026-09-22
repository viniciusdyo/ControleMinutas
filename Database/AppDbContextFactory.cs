using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleMinutas.Database;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
       
        optionsBuilder.UseSqlite($"Data Source=design_time.db");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
