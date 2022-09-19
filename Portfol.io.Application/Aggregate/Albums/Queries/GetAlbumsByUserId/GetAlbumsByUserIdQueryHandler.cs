using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQueryHandler : IRequestHandler<GetAlbumsByUserIdQuery, AlbumsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAlbumsByUserIdQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<AlbumsViewModel> Handle(GetAlbumsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Albums.Include(u => u.Photos).Include(u => u.AlbumLikes!)
                .Where(u => u.UserId == request.UserId).ToListAsync(cancellationToken);

            var albumDtos = new UserLikeChecker<AlbumLookupDto>(_mapper).Check(request.AUserId, entities);

            if (entities.Count == 0) throw new NotFoundException(nameof(Album), request.UserId);

            return new AlbumsViewModel { Albums = albumDtos };
        }
    }
}
