using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class CursoAulaConfiguration : IEntityTypeConfiguration<CursoAula>
{
    public void Configure(EntityTypeBuilder<CursoAula> builder)
    {
        builder.HasKey(ca => new {ca.CursoId, ca.AulaId});

        builder.HasOne(ca => ca.Curso)
            .WithMany(c => c.CursoAulas)
            .HasForeignKey(ca => ca.CursoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ca => ca.Aula)
            .WithMany(a => a.CursoAulas)
            .HasForeignKey(ca => ca.AulaId);

        builder.Property(ca => ca.Data)
            .HasColumnType("date")
            .IsRequired();
    }
}