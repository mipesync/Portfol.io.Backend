using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.CreationDate)
                .IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(u => u.Albums)
                .HasForeignKey(u => u.UserId);

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
