using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageByAlbumId
{
    public class GetImagesByAlbumIdQueryHandler : IRequestHandler<GetImagesByAlbumIdQuery, ImagesViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetImagesByAlbumIdQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<ImagesViewModel> Handle(GetImagesByAlbumIdQuery request, CancellationToken cancellationToken)
        {
            var entities = _dbContext.Photos.Where(u => u.AlbumId == request.AlbumId).ProjectTo<ImageLookupDto>(_mapper.ConfigurationProvider).ToList();

            if (entities.Count == 0) throw new NotFoundException(nameof(List<Photo>), request.AlbumId);

            return Task.FromResult(new ImagesViewModel { Images = entities });
        }
    }
}
