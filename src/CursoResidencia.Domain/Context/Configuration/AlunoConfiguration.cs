using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.DataDeCadastro)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(a => a.NomeCompleto)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Cpf)
            .HasMaxLength(11);

        builder.Property(a => a.Crm)
            .HasMaxLength(10);

        builder
            .HasOne(p => p.Usuario)
            .WithOne(u => u.Aluno)
            .HasForeignKey<Aluno>(p => p.UsuarioId);
    }
}
