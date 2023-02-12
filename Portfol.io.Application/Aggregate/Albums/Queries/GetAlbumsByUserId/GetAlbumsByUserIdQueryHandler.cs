using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQueryHandler : IRequestHandler<GetAlbumsByUserIdQuery, GetAlbumsDto>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlbumsByUserIdQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetAlbumsDto> Handle(GetAlbumsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Albums
                .AsNoTracking()
                .Include(u => u.Photos)
                .Include(u => u.AlbumLikes!)
                .Where(u => u.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            var albumDtos = new UserLikeChecker<GetAlbumLookupDto>(_mapper)
                .Check(request.AUserId, entities);

            if (entities.Count == 0)
                throw new NotFoundException(nameof(Album), request.UserId);

            return new GetAlbumsDto { Albums = albumDtos };
        }
    }
}
