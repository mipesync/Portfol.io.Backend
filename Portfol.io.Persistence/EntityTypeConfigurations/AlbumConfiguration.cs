using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder.HasGeneratedTsVectorColumn(
                p => p.SearchVector,
                "russian",
                p => new { p.Name, p.Description })
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN");

            builder.Property(p => p.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Cover)
                .HasMaxLength(255);

            builder.Property(p => p.CreationDate)
                .IsRequired();

            builder.HasMany(u => u.Tags)
                .WithMany(u => u.Albums)
                .UsingEntity<AlbumTag>(
                j => j
                    .HasOne(u => u.Tag)
                    .WithMany(u => u.AlbumTags)
                    .HasForeignKey(u => u.TagId),
                o => o
                    .HasOne(u => u.Album)
                    .WithMany(u => u.AlbumTags)
                    .HasForeignKey(u => u.AlbumId),
                p =>
                {
                    p.HasKey(new string[] { "AlbumId", "TagId" });
                    p.ToTable("AlbumTags");
                });
        }
    }
}
