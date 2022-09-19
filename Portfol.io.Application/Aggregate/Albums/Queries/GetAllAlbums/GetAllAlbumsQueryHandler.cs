using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, AlbumsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllAlbumsQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AlbumsViewModel> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Albums.Include(u => u.Photos).Include(u => u.AlbumLikes!).ToListAsync(cancellationToken);

            var albumDtos = new UserLikeChecker<AlbumLookupDto>(_mapper).Check(request.UserId, entities);

            if (entities.Count == 0) throw new NotFoundException(nameof(Album), null!);

            return new AlbumsViewModel { Albums = albumDtos };
        }
    }
}
