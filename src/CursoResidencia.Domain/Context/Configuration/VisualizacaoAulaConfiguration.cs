using CursoResidencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class VisualizacaoAulaConfiguration : IEntityTypeConfiguration<VisualizacaoAula>
{
    public void Configure(EntityTypeBuilder<VisualizacaoAula> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.HasOne(p => p.Curso)
            .WithMany(p => p.VisualizacaoAulas)
            .HasForeignKey(f => f.CursoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Aluno)
            .WithMany(p => p.VisualizacaoAula)
            .HasForeignKey(f => f.AlunoId);

        builder.HasOne(p => p.Aula)
            .WithMany(p => p.VisualizacaoAulas)
            .HasForeignKey(f => f.AulaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
