using ControleMinutas.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleMinutas.Database;

public class AppDbContext : DbContext
{

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Terminal> Terminais { get; set; }
    public DbSet<Trabalho> Trabalhos { get; set; }
    public DbSet<Minuta> Minutas { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
