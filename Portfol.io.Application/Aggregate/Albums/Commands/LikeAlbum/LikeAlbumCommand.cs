using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum
{
    public class LikeAlbumCommand : IRequest<Unit>
    {
        public Guid AlbumId { get; set; }
        public Guid UserId { get; set; }
    }
}
