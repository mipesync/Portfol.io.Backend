using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQuery : IRequest<GetAlbumsDto>
    {
        public Guid UserId { get; set; }
        public Guid AUserId { get; set; }
    }
}
