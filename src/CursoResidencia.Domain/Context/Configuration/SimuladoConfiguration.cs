using CursoResidencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class SimuladoConfiguration : IEntityTypeConfiguration<Simulado>
{
    public void Configure(EntityTypeBuilder<Simulado> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(s => s.Modulo)
            .WithMany(m => m.Simulados)
            .IsRequired(false);

        builder.HasOne(s => s.Curso)
            .WithMany(c => c.Simulados);

        builder.Property(s => s.DataCriacao)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

        builder.HasMany(a => a.RespostasQuestaoSimulado)
            .WithOne(r => r.Simulado);

        builder.Property(s => s.SituacaoProva)
            .HasDefaultValue(SituacaoProva.NaoRealizada)
            .IsRequired();
    }
}
