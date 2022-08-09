using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class AlbumTagConfiguration : IEntityTypeConfiguration<AlbumTag>
    {
        public void Configure(EntityTypeBuilder<AlbumTag> builder)
        {
            builder.ToTable("AlbumTags");
        }
    }
}
