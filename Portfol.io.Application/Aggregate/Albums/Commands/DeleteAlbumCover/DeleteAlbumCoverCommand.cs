using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover
{
    public class DeleteAlbumCoverCommand : IRequest<Unit>
    {
        public Guid AlbumId { get; set; }
        public Guid UserId { get; set; }
        public string WebRootPath { get; set; } = null!;
    }
}
