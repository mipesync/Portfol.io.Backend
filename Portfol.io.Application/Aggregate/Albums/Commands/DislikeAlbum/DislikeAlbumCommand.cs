using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum
{
    public class DislikeAlbumCommand : IRequest<Unit>
    {
        public int AlbumId { get; set; }
        public Guid UserId { get; set; }
    }
}
