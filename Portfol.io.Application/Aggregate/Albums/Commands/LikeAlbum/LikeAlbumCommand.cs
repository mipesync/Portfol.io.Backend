using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum
{
    public class LikeAlbumCommand : IRequest<Unit>
    {
        public int AlbumId { get; set; }
        public Guid UserId { get; set; }
    }
}
