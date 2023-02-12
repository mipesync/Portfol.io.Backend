using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQuery : IRequest<GetAlbumsDto>
    {
        public Guid UserId { get; set; }
    }
}
