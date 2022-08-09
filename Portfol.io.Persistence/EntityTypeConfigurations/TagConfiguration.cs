using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
