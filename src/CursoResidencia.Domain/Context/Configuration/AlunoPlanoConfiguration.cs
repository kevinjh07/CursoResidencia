using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class AlunoPlanoConfiguration : IEntityTypeConfiguration<AlunoPlano>
{
    public void Configure(EntityTypeBuilder<AlunoPlano> builder)
    {
        builder.HasKey(pc => new { pc.AlunoId, pc.PlanoId });

        builder.HasOne(ac => ac.Aluno)
            .WithMany(a => a.AlunoPlanos)
            .HasForeignKey(ac => ac.AlunoId);

        builder.HasOne(ac => ac.Plano)
            .WithMany(c => c.AlunoPlanos)
            .HasForeignKey(ac => ac.PlanoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ap => ap.DataCompra)
            .IsRequired();

        builder.Property(ap => ap.Situacao)
            .IsRequired();

        builder.Property(ap => ap.TipoPagamento)
            .IsRequired();
    }
}
