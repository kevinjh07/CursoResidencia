using CursoResidencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class SimuladoQuestaoProvaConfiguration : IEntityTypeConfiguration<SimuladoQuestaoProva>
{
    public void Configure(EntityTypeBuilder<SimuladoQuestaoProva> builder)
    {
        builder.HasKey(pc => new {pc.SimuladoId, pc.QuestaoProvaId});

        builder.HasOne(ac => ac.Simulado)
            .WithMany(a => a.SimuladoQuestoesProva)
            .HasForeignKey(ac => ac.SimuladoId);

        builder.HasOne(ac => ac.QuestaoProva)
            .WithMany(c => c.SimuladoQuestoesProva)
            .HasForeignKey(ac => ac.QuestaoProvaId);
    }
}
