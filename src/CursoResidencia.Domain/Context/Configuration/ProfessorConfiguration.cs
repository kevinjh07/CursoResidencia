using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .HasMaxLength(200).IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(p => p.Email)
            .IsUnique();

        builder.Property(p => p.MiniCurriculo)
            .HasColumnType("text")
            .HasMaxLength(3000);

        builder.Property(p => p.PermiteTutoria).IsRequired();

        builder.Property(p => p.Situacao)
            .IsRequired();

        builder.Property(p => p.Imagem)
            .HasMaxLength(200);

        builder
            .HasOne(p => p.Usuario)
            .WithOne(u => u.Professor)
            .HasForeignKey<Professor>(p => p.UsuarioId)
            .IsRequired(false);
    }
}
