using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class AulaConfiguration : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(a => a.Modulo)
            .WithMany(m => m.Aulas);

        builder.Property(a => a.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Descricao)
            .HasMaxLength(500);

        builder.Property(a => a.CodigoVimeo)
            .HasMaxLength(20);

        builder.Property(a => a.Situacao)
            .IsRequired();

        builder.Property(a => a.Ordem)
            .HasDefaultValue(0);

        builder.Property(a => a.OrdemTrial)
            .HasDefaultValue(0);
    }
}
