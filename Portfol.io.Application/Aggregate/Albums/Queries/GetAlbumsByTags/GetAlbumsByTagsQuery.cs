using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags
{
    public class GetAlbumsByTagsQuery : IRequest<GetAlbumsDto>
    {
        public IEnumerable<Guid> TagIds { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
