using ControleMinutas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMinutas.Database.Configuration;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CriadoEm)
            .IsRequired();
        builder.Property(e => e.EditadoEm)
            .IsRequired();

        builder.HasIndex(e => e.CriadoEm);
        builder.HasIndex(e => e.EditadoEm);
    }
}

public class MinutaConfiguration : BaseEntityConfiguration<Minuta>
{
    public override void Configure(EntityTypeBuilder<Minuta> builder)
    {
        base.Configure(builder);
        builder.ToTable("Minutas");

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

        builder.HasIndex(m => m.Data);
        builder.HasIndex(m => m.Status);
    }
}

public class TrabalhoConfiguration : BaseEntityConfiguration<Trabalho>
{
    public override void Configure(EntityTypeBuilder<Trabalho> builder)
    {
        base.Configure(builder);
        builder.ToTable("Trabalhos");

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

public class EmpresaConfiguration : BaseEntityConfiguration<Empresa>
{
    public override void Configure(EntityTypeBuilder<Empresa> builder)
    {
        base.Configure(builder);
        builder.ToTable("Empresas");

        builder.Property(e => e.Nome)
            .IsRequired();

        builder.Property(e => e.TaxaTroca)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(e => e.TaxaAbastecimento)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.HasIndex(e => e.Nome).IsUnique();
    }
}

public class TerminalConfiguration : BaseEntityConfiguration<Terminal>
{
    public override void Configure(EntityTypeBuilder<Terminal> builder)
    {
        base.Configure(builder);
        builder.ToTable("Terminais");        

        builder.Property(e => e.Nome)
            .IsRequired();

        builder.HasIndex(e => e.Nome).IsUnique();
    }
}