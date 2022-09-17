using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(c => c.Nome)
            .IsUnique();

        builder.Property(c => c.Situacao)
            .IsRequired();

        builder.Property(c => c.DataCadastro)
            .HasColumnType("Date");
    }
}
