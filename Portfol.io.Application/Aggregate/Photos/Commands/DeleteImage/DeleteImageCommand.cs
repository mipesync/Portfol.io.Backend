using MediatR;

namespace Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest<Unit>
    {
        public Guid AlbumId { get; set; }
        public Guid ImageId { get; set; }
        public string WebRootPath { get; set; } = null!;
    }
}
