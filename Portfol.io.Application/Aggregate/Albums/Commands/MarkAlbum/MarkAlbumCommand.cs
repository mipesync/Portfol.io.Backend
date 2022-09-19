using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum
{
    public class MarkAlbumCommand : IRequest<Unit>
    {
        public Guid AlbumId { get; set; }
        public Guid UserId { get; set; }
    }
}
