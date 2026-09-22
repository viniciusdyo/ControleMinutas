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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<EntidadeBase>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CriadoEm = DateTime.UtcNow;
                entry.Entity.EditadoEm = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.EditadoEm = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
