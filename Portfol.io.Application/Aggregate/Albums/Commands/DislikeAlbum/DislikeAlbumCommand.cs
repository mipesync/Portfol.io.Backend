using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DislikeAlbum
{
    public class DislikeAlbumCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
    }
}
