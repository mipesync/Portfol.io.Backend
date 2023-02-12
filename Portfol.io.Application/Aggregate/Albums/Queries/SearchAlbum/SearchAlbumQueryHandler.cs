using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum
{
    public class SearchAlbumQueryHandler : IRequestHandler<SearchAlbumQuery, GetAlbumsDto>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchAlbumQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GetAlbumsDto> Handle(SearchAlbumQuery request, CancellationToken cancellationToken)
        {
            var albums = await _dbContext.Albums
                .AsNoTracking()
                .Include(u => u.AlbumLikes)
                .Where(x => x.SearchVector.Matches(request.Query!))
                .ToListAsync(cancellationToken);

            var lookUps = new UserLikeChecker<GetAlbumLookupDto>(_mapper)
                .Check(request.UserId, albums.ToList());

            return new GetAlbumsDto { Albums = lookUps };
        }
    }
}
