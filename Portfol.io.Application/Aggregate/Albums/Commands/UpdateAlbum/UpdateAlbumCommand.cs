using MediatR;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
