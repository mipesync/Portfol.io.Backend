using MediatR;
using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover
{
    public class UpdateAlbumCoverCommand : IRequest<Unit>
    {
        public IFormFile Image { get; set; } = null!;
        public Guid AlbumId { get; set; }
        public string WebRootPath { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
