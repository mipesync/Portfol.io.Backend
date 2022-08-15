using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum
{
    public class RemoveAlbumCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
