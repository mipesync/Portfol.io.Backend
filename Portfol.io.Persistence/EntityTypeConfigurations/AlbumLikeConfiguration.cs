using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class AlbumLikeConfiguration : IEntityTypeConfiguration<AlbumLike>
    {
        public void Configure(EntityTypeBuilder<AlbumLike> builder)
        {
            builder.ToTable("AlbumLikes");

            builder.HasKey(p => new
            {
                p.AlbumId,
                p.UserId
            });
        }
    }
}
