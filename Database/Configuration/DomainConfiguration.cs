using ControleMinutas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMinutas.Database.Configuration;

public class MinutaConfiguration : IEntityTypeConfiguration<Minuta>
{
    public void Configure(EntityTypeBuilder<Minuta> builder)
    {
        builder.ToTable("Minutas");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(m => m.Data).HasConversion(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        );

        builder.HasOne(m => m.Trabalho)
            .WithMany()
            .HasForeignKey(m => m.TrabalhoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.Valor)
             .HasColumnType("TEXT")
             .IsRequired();

        builder.Property(m => m.ValorTotal)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasIndex(m => new { m.TrabalhoId, m.Data, m.Status });
    }
}

public class TrabalhoConfiguration : IEntityTypeConfiguration<Trabalho>
{
    public void Configure(EntityTypeBuilder<Trabalho> builder)
    {
        builder.ToTable("Trabalhos");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Valor)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasOne(t => t.Empresa)
            .WithMany()
            .HasForeignKey(t => t.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Entrega)
            .WithMany()
            .HasForeignKey(t => t.EntregaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Saida)
            .WithMany()
            .HasForeignKey(s => s.SaidaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired();

        builder.Property(e => e.TaxaTroca)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(e => e.TaxaAbastecimento)
            .HasColumnType("TEXT")
            .IsRequired();
    }
}

public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
{
    public void Configure(EntityTypeBuilder<Terminal> builder)
    {
        builder.ToTable("Terminais");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired();

        builder.HasIndex(e => e.Nome).IsUnique();
    }
}