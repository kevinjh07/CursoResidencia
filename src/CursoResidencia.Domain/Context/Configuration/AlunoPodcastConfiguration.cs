using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class AlunoPodcastConfiguration : IEntityTypeConfiguration<AlunoPodcast>
{
    public void Configure(EntityTypeBuilder<AlunoPodcast> builder)
    {
        builder.HasKey(ap => new { ap.AlunoId, ap.PodcastId });

        builder.HasOne(ap => ap.Aluno)
            .WithMany(a => a.AlunoPodcasts)
            .HasForeignKey(ap => ap.AlunoId);

        builder.HasOne(ap => ap.Podcast)
            .WithMany(p => p.AlunoPodcasts)
            .HasForeignKey(ap => ap.PodcastId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(pa => pa.Data)
            .HasColumnType("date")
            .IsRequired();
    }
}