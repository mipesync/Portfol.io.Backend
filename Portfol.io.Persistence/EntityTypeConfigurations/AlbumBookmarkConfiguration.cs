using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class AlbumBookmarkConfiguration : IEntityTypeConfiguration<AlbumBookmark>
    {
        public void Configure(EntityTypeBuilder<AlbumBookmark> builder)
        {
            builder.ToTable("AlbumBookmarks");

            builder.HasKey(p => new
            {
                p.UserId,
                p.AlbumId
            });
        }
    }
}
