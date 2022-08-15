using MediatR;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageById
{
    public class GetImageByIdQuery : IRequest<ImageViewModel>
    {
        public int Id { get; set; }
    }
}
