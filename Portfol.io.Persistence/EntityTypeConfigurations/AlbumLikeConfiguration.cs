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
    public class AlbumLikeConfiguration : IEntityTypeConfiguration<AlbumLike>
    {
        public void Configure(EntityTypeBuilder<AlbumLike> builder)
        {
            builder.ToTable("AlbumLikes");
        }
    }
}
