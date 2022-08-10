using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<Unit>
    {
        public UpdateAlbumViewModel Model { get; set; } = null!;
    }
}
