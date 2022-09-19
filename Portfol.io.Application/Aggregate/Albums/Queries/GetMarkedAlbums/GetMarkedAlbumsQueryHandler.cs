using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Common.Services.LikeCheck;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums
{
    public class GetMarkedAlbumsQueryHandler : IRequestHandler<GetMarkedAlbumsQuery, AlbumsViewModel>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMarkedAlbumsQueryHandler(IPortfolioDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AlbumsViewModel> Handle(GetMarkedAlbumsQuery request, CancellationToken cancellationToken)
        {
            var albumBookmarks = _dbContext.AlbumBookmarks.Where(u => u.UserId == request.UserId).ToList();

            var albums = new List<Album>();

            foreach (var albumBookmark in albumBookmarks)
            {
                #pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                albums.Add(await _dbContext.Albums.Include(u => u.Photos)
                    .Include(u => u.AlbumLikes!).FirstOrDefaultAsync(u => u.Id == albumBookmark.AlbumId, cancellationToken));

                #pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            }

            var albumDtos = new UserLikeChecker<AlbumLookupDto>(_mapper).Check(request.UserId, albums);

            if (albums.Count == 0) throw new NotFoundException(nameof(Album), null!);

            return new AlbumsViewModel { Albums = albumDtos };
        }
    }
}
