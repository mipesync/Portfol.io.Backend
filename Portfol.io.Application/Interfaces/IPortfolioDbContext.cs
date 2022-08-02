using Microsoft.EntityFrameworkCore;
using Portfol.io.Domain;
using System.Threading;

namespace Portfol.io.Application.Interfaces
{
    public interface IPortfolioDbContext
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Credential> Credentials { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<User> Users { get; set; } 
        DbSet<AlbumTag> AlbumTags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
