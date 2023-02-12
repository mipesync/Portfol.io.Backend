using MediatR;
using Portfol.io.Application.Aggregate.Photos.DTO;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageByAlbumId
{
    public class GetImagesByAlbumIdQuery : IRequest<GetImagesByAlbumIdDto>
    {
        public Guid AlbumId { get; set; }
    }
}
