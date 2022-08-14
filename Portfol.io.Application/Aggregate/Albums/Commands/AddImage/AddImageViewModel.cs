using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Albums.Commands.AddImage
{
    public class AddImageViewModel
    {
        public IFormFile ImageFile { get; set; } = null!;
        public string WebRootPath { get; set; } = null!;
        public string HostUrl { get; set; } = null!;
        public int AlbumId { get; set; }
    }
}
