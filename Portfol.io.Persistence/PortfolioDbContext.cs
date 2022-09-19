using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;
using System.Reflection;

namespace Portfol.io.Persistence
{
    public class PortfolioDbContext : DbContext, IPortfolioDbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }


        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<AlbumTag> AlbumTags { get; set; } = null!;
        public DbSet<AlbumLike> AlbumLikes { get; set; } = null!;
        public DbSet<AlbumBookmark> AlbumBookmarks { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
