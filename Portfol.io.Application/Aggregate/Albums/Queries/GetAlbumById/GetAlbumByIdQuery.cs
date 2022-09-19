using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQuery : IRequest<AlbumLookupDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
