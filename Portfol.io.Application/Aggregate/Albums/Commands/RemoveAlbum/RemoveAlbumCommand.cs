using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    public class RemoveAlbumCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
