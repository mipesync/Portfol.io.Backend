using MediatR;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageById
{
    public class GetImageByIdQuery : IRequest<ImageLookupDto>
    {
        public Guid Id { get; set; }
    }
}
