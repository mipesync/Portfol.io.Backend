using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQuery : IRequest<AlbumsViewModel>
    {
        public Guid UserId { get; set; }
    }
}
