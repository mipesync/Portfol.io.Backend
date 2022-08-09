using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.ToTable("Credentials");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Username)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("PassHash")
                .IsRequired();
        }
    }
}
