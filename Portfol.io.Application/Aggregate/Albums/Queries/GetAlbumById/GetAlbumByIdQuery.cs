using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class GetAlbumByIdQuery : IRequest<GetAlbumLookupDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
