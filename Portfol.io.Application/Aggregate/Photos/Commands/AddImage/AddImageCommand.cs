using MediatR;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Photos.Commands.AddImage
{
    public class AddImageCommand : IRequest<ICollection<Guid>>
    {
        public ICollection<IFormFile> Files { get; set; } = null!;
        public string WebRootPath { get; set; } = null!;
        public Guid AlbumId { get; set; }
    }
}
