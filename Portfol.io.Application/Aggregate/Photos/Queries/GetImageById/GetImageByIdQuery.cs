using MediatR;
using Portfol.io.Application.Aggregate.Photos.DTO;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageById
{
    public class GetImageByIdQuery : IRequest<ImageLookupDto>
    {
        public Guid Id { get; set; }
    }
}
