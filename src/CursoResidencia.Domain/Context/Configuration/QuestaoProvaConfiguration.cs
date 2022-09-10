using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class QuestaoProvaConfiguration : IEntityTypeConfiguration<QuestaoProva>
{
    public void Configure(EntityTypeBuilder<QuestaoProva> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .ValueGeneratedOnAdd();

        builder.Property(q => q.Enunciado)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(q => q.AlternativaA)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(q => q.AlternativaB)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(q => q.AlternativaC)
            .HasColumnType("text");

        builder.Property(q => q.AlternativaD)
            .HasColumnType("text");

        builder.Property(q => q.AlternativaE)
            .HasColumnType("text");

        builder.Property(q => q.AlternativaCorreta)
            .IsRequired();

        builder.Property(q => q.Anexo)
            .HasMaxLength(200);

        builder.Property(q => q.Comentario)
            .HasColumnType("text");

        builder.Property(q => q.CodigoVimeo)
            .HasMaxLength(20);

        builder.Property(q => q.Situacao)
            .HasDefaultValue(Situacao.Ativo)
            .IsRequired();

        builder.Property(q => q.Anulada)
            .IsRequired();
    }
}