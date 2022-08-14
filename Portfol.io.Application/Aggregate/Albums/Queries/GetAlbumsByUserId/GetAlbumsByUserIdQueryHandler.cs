using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
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
            var entity = await _dbContext.Albums.Include(u => u.Photos).Include(u => u.Tags)
                .Include(u => u.AlbumLikes).Where(u => u.UserId == request.UserId)
                .ProjectTo<AlbumLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            if (entity is null) throw new NotFoundException(nameof(Album), request.UserId);

            return new AlbumsViewModel { Albums = entity };
        }
    }
}
