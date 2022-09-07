using MediatR;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageByAlbumId
{
    public class GetImagesByAlbumIdQuery : IRequest<ImagesViewModel>
    {
        public Guid AlbumId { get; set; }
    }
}
