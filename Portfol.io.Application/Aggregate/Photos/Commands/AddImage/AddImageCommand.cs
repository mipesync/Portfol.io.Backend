using MediatR;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Photos.Commands.AddImage
{
    public class AddImageCommand : IRequest<int>
    {
        public IFormFile ImageFile { get; set; } = null!;
        public string WebRootPath { get; set; } = null!;
        public string HostUrl { get; set; } = null!;
        public int AlbumId { get; set; }
    }
}
