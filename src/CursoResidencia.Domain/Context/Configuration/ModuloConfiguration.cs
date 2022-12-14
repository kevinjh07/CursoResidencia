using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(m => m.Situacao)
            .IsRequired();

        builder.HasOne(m => m.Curso)
            .WithMany(m => m.Modulos);

        builder.Property(c => c.DataCadastro)
            .HasColumnType("Date");
    }
}
