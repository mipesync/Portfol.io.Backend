using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
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
            var entity = await _dbContext.Albums.Include(u => u.Photos).Include(u => u.Tags)
                .Include(u => u.AlbumLikes).ProjectTo<AlbumLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            if (entity.Count == 0) throw new NotFoundException(nameof(Album), null!);

            return new AlbumsViewModel { Albums = entity };
        }
    }
}
