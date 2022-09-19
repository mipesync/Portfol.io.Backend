using Microsoft.EntityFrameworkCore;
using Portfol.io.Domain;

namespace Portfol.io.Application.Interfaces
{
    public interface IPortfolioDbContext
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<AlbumTag> AlbumTags { get; set; }
        DbSet<AlbumLike> AlbumLikes { get; set; }
        DbSet<AlbumBookmark> AlbumBookmarks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
