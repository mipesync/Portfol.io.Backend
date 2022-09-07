using MediatR;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class GetAlbumsByTagsQuery : IRequest<AlbumsViewModel>
    {
        public IEnumerable<Guid> TagIds { get; set; } = null!;
    }
}
