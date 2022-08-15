using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Photos.Queries.GetImageById
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetImageByIdQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ImageViewModel> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Photos.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id) throw new NotFoundException(nameof(Photo), request.Id);

            return _mapper.Map<ImageViewModel>(entity);
        }
    }
}
