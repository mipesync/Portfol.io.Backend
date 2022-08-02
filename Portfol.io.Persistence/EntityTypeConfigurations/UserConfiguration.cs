using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfol.io.Domain;

namespace Portfol.io.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);

            builder.HasOne(u => u.Credential)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.CredentialsId);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.ProfileImagePath)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.DateOfCreation)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .IsRequired();
        }
    }
}
