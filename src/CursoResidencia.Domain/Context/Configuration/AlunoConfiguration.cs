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

        builder.Property(a => a.Cep)
            .HasMaxLength(8);

        builder.Property(a => a.Endereco)
            .HasMaxLength(200);

        builder.Property(a => a.Complemento)
            .HasMaxLength(200);

        builder.Property(a => a.Numero)
            .HasMaxLength(6);

        builder.Property(a => a.Bairro)
            .HasMaxLength(200);

        builder.Property(a => a.Cidade)
            .HasMaxLength(200);

        builder.Property(a => a.Telefone)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Estado)
            .IsRequired();


        builder.Property(a => a.Cpf)
            .HasMaxLength(11);

        builder.Property(a => a.Imagem)
            .HasMaxLength(200);

        builder.Property(a => a.CadastroCompleto)
            .HasDefaultValue(true);

        builder.Property(a => a.Crm)
            .HasMaxLength(10);

        builder
            .HasOne(p => p.Usuario)
            .WithOne(u => u.Aluno)
            .HasForeignKey<Aluno>(p => p.UsuarioId);

        builder.Property(a => a.DeviceId)
            .HasMaxLength(100);
    }
}