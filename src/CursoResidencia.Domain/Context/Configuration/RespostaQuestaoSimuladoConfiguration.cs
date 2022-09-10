using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class RespostaQuestaoSimuladoConfiguration : IEntityTypeConfiguration<RespostaQuestaoSimulado>
{
    public void Configure(EntityTypeBuilder<RespostaQuestaoSimulado> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.HasOne(r => r.QuestaoProva).WithMany(qp => qp.RespostasQuestaoSimulado).IsRequired();
        builder.Property(r => r.AlternativaSelecionada).IsRequired();
    }
}