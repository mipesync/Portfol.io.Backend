using MediatR;
using Portfol.io.Application.Aggregate.Albums.DTO;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQuery : IRequest<GetAlbumsDto>
    {
        public Guid UserId { get; set; }
    }
}
