using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQuery : IRequest<AlbumsViewModel>
    {
        public Guid UserId { get; set; }
    }
}
