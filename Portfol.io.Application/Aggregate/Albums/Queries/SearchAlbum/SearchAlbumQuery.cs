using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQuery : IRequest<AlbumsViewModel>
    {
        public string? Query { get; set; }
        public Guid UserId { get; set; }
    }
}
