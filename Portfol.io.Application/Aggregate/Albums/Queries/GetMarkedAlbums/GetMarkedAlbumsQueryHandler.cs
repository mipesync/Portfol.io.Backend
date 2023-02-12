using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Aggregate.Albums.DTO;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQueryHandler : IRequestHandler<GetMarkedAlbumsQuery, GetAlbumsDto>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMarkedAlbumsQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAlbumsDto> Handle(GetMarkedAlbumsQuery request, CancellationToken cancellationToken)
        {
            var albumBookmarks = await _dbContext.AlbumBookmarks
                .AsNoTracking()
                .Where(u => u.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            var albums = new List<Album>();

            foreach (var albumBookmark in albumBookmarks)
            {
                var album = await _dbContext.Albums
                    .AsNoTracking()
                    .Include(u => u.Photos)
                    .Include(u => u.AlbumLikes!)
                    .FirstOrDefaultAsync(u => u.Id == albumBookmark.AlbumId, cancellationToken);
                albums.Add(album!);
            }

            var albumDtos = new UserLikeChecker<GetAlbumLookupDto>(_mapper)
                .Check(request.UserId, albums);

            if (albums.Count == 0)
                throw new NotFoundException(nameof(Album), null!);

            return new GetAlbumsDto { Albums = albumDtos };
        }
    }
}
