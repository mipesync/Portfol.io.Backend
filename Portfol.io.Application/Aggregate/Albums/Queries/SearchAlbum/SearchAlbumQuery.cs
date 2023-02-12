using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQuery : IRequest<GetAlbumsDto>
    {
        public string? Query { get; set; }
        public Guid UserId { get; set; }
    }
}
