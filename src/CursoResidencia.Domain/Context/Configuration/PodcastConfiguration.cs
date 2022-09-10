using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class PodcastConfiguration : IEntityTypeConfiguration<Podcast>
{
    public void Configure(EntityTypeBuilder<Podcast> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Titulo)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(p => p.Modulo)
            .WithMany(m => m.Podcasts);

        builder.Property(p => p.Arquivo)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Situacao)
            .IsRequired();
    }
}
