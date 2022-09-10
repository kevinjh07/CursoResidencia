using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoResidencia.Domain.Context.Configuration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => new {rt.UserId, rt.Token});

        builder.Property(rt => rt.Token)
            .IsRequired();

        builder.Property(rt => rt.Expiration)
            .IsRequired();
    }
}
