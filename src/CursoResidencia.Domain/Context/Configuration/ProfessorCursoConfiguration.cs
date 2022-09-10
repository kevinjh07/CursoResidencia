using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class ProfessorCursoConfiguration : IEntityTypeConfiguration<ProfessorCurso>
{
    public void Configure(EntityTypeBuilder<ProfessorCurso> builder)
    {
        builder.HasKey(pc => new {pc.ProfessorId, pc.CursoId});

        builder.HasOne(pc => pc.Professor)
            .WithMany(p => p.ProfessorCursos)
            .HasForeignKey(pc => pc.ProfessorId);

        builder.HasOne(pc => pc.Curso)
            .WithMany(c => c.ProfessorCursos)
            .HasForeignKey(pc => pc.CursoId);
    }
}
