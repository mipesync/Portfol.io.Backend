using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQuery : IRequest<AlbumsViewModel>
    {
        public Guid UserId { get; set; }
    }
}
