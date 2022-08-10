using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<Unit>
    {
        public CreateAlbumViewModel Model { get; set; } = null!;
    }
}
